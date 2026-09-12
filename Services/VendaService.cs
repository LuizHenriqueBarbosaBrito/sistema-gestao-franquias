using Franquias.Api.DTOs;
using Franquias.Api.Models;
using Franquias.Api.Repositories;

namespace Franquias.Api.Services;

public class VendaService : IVendaService
{
    private readonly IVendaRepository _repository;

    public VendaService(IVendaRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<VendaDto>> GetAllAsync()
    {
        var vendas = await _repository.GetAllAsync();
        return vendas.Select(ParaDto).ToList();
    }

    public async Task<VendaDto?> GetByIdAsync(int id)
    {
        var venda = await _repository.GetByIdAsync(id);
        return venda is null ? null : ParaDto(venda);
    }

    public async Task<(bool Sucesso, string? Erro, VendaDto? Dto)> CreateAsync(VendaCreateDto dto)
    {
        // Regra: venda precisa de pelo menos um item
        if (dto.Itens is null || dto.Itens.Count == 0)
        {
            return (false, "A venda precisa ter pelo menos um item.", null);
        }

        // Regra: unidade precisa existir e estar ativa
        var unidade = await _repository.GetUnidadeAsync(dto.UnidadeFranqueadaId);
        if (unidade is null)
        {
            return (false, "Unidade não encontrada.", null);
        }
        if (!unidade.Ativo)
        {
            return (false, "Unidade inativa não pode registrar vendas.", null);
        }

        // Monta os itens, validando produto e estoque de cada um
        var itensVenda = new List<ItemVenda>();
        var estoquesParaAtualizar = new List<(Estoque Estoque, int Quantidade)>();

        foreach (var itemDto in dto.Itens)
        {
            var produto = await _repository.GetProdutoAsync(itemDto.ProdutoServicoId);
            if (produto is null)
            {
                return (false, $"Produto {itemDto.ProdutoServicoId} não encontrado.", null);
            }

            var estoque = await _repository.GetEstoqueAsync(dto.UnidadeFranqueadaId, itemDto.ProdutoServicoId);
            if (estoque is null)
            {
                return (false, $"Não há registro de estoque para o produto '{produto.Nome}' nesta unidade.", null);
            }

            // Regra: estoque não pode ficar negativo
            if (estoque.SaldoAtual - itemDto.Quantidade < 0)
            {
                return (false, $"Estoque insuficiente para o produto '{produto.Nome}'.", null);
            }

            itensVenda.Add(new ItemVenda
            {
                ProdutoServicoId = produto.Id,
                Quantidade = itemDto.Quantidade,
                PrecoUnitario = produto.PrecoBase
            });

            estoquesParaAtualizar.Add((estoque, itemDto.Quantidade));
        }

        // Regra: valor total calculado a partir dos itens
        var valorTotal = itensVenda.Sum(i => i.Quantidade * i.PrecoUnitario);

        var venda = new Venda
        {
            UnidadeFranqueadaId = dto.UnidadeFranqueadaId,
            UsuarioId = dto.UsuarioId,
            DataVenda = DateTime.Now,
            ValorTotal = valorTotal,
            Itens = itensVenda
        };

        await _repository.AddAsync(venda);

        // Regra: baixa de estoque após confirmação da venda
        foreach (var (estoque, quantidade) in estoquesParaAtualizar)
        {
            estoque.SaldoAtual -= quantidade;
            await _repository.AddMovimentacaoAsync(new MovimentacaoEstoque
            {
                EstoqueId = estoque.Id,
                Tipo = TipoMovimentacao.Saida,
                Quantidade = quantidade,
                Motivo = "Venda",
                Data = DateTime.Now
            });
        }

        await _repository.SaveChangesAsync();

        return (true, null, ParaDto(venda));
    }

    private static VendaDto ParaDto(Venda v) => new()
    {
        Id = v.Id,
        UnidadeFranqueadaId = v.UnidadeFranqueadaId,
        UsuarioId = v.UsuarioId,
        DataVenda = v.DataVenda,
        ValorTotal = v.ValorTotal,
        Itens = v.Itens.Select(i => new ItemVendaDto
        {
            ProdutoServicoId = i.ProdutoServicoId,
            Quantidade = i.Quantidade,
            PrecoUnitario = i.PrecoUnitario,
            Subtotal = i.Quantidade * i.PrecoUnitario
        }).ToList()
    };
}