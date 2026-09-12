using Franquias.Api.DTOs;
using Franquias.Api.Models;
using Franquias.Api.Repositories;

namespace Franquias.Api.Services;

public class EstoqueService : IEstoqueService
{
    private readonly IEstoqueRepository _repository;

    public EstoqueService(IEstoqueRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<EstoqueDto>> GetAllAsync()
    {
        var estoques = await _repository.GetAllAsync();
        return estoques.Select(ParaDto).ToList();
    }

    public async Task<EstoqueDto?> GetByIdAsync(int id)
    {
        var estoque = await _repository.GetByIdAsync(id);
        return estoque is null ? null : ParaDto(estoque);
    }

    public async Task<List<EstoqueDto>> GetAbaixoDoMinimoAsync()
    {
        var estoques = await _repository.GetAbaixoDoMinimoAsync();
        return estoques.Select(ParaDto).ToList();
    }

    public async Task<(bool Sucesso, string? Erro, EstoqueDto? Dto)> CreateAsync(EstoqueCreateDto dto)
    {
        if (await _repository.ExisteParaUnidadeProdutoAsync(dto.UnidadeFranqueadaId, dto.ProdutoServicoId))
        {
            return (false, "Já existe um registro de estoque para esta unidade e produto.", null);
        }

        var estoque = new Estoque
        {
            UnidadeFranqueadaId = dto.UnidadeFranqueadaId,
            ProdutoServicoId = dto.ProdutoServicoId,
            EstoqueMinimo = dto.EstoqueMinimo,
            SaldoAtual = 0
        };

        await _repository.AddAsync(estoque);
        await _repository.SaveChangesAsync();

        return (true, null, ParaDto(estoque));
    }

    public async Task<(bool Sucesso, string? Erro)> MovimentarAsync(MovimentacaoEstoqueDto dto)
    {
        var estoque = await _repository.GetByIdAsync(dto.EstoqueId);
        if (estoque is null)
        {
            return (false, "Estoque não encontrado.");
        }

        if (!Enum.TryParse<TipoMovimentacao>(dto.Tipo, true, out var tipo))
        {
            return (false, "Tipo de movimentação inválido. Use 'Entrada' ou 'Saida'.");
        }

        if (tipo == TipoMovimentacao.Saida && estoque.SaldoAtual - dto.Quantidade < 0)
        {
            return (false, "Estoque insuficiente para esta saída.");
        }

        estoque.SaldoAtual += tipo == TipoMovimentacao.Entrada ? dto.Quantidade : -dto.Quantidade;
        _repository.Update(estoque);

        var movimentacao = new MovimentacaoEstoque
        {
            EstoqueId = dto.EstoqueId,
            Tipo = tipo,
            Quantidade = dto.Quantidade,
            Motivo = dto.Motivo,
            Data = DateTime.Now
        };
        await _repository.AddMovimentacaoAsync(movimentacao);

        await _repository.SaveChangesAsync();

        return (true, null);
    }

    private static EstoqueDto ParaDto(Estoque e) => new()
    {
        Id = e.Id,
        UnidadeFranqueadaId = e.UnidadeFranqueadaId,
        ProdutoServicoId = e.ProdutoServicoId,
        SaldoAtual = e.SaldoAtual,
        EstoqueMinimo = e.EstoqueMinimo
    };
}