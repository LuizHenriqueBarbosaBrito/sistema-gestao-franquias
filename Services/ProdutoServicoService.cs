using Franquias.Api.DTOs;
using Franquias.Api.Models;
using Franquias.Api.Repositories;

namespace Franquias.Api.Services;

public class ProdutoServicoService : IProdutoServicoService
{
    private readonly IProdutoServicoRepository _repository;

    public ProdutoServicoService(IProdutoServicoRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ProdutoServicoDto>> GetAllAsync()
    {
        var produtos = await _repository.GetAllAsync();
        return produtos.Select(ParaDto).ToList();
    }

    public async Task<ProdutoServicoDto?> GetByIdAsync(int id)
    {
        var produto = await _repository.GetByIdAsync(id);
        return produto is null ? null : ParaDto(produto);
    }

    public async Task<ProdutoServicoDto> CreateAsync(ProdutoServicoCreateDto dto)
    {
        var produto = new ProdutoServico
        {
            Nome = dto.Nome,
            Descricao = dto.Descricao,
            PrecoBase = dto.PrecoBase,
            CategoriaId = dto.CategoriaId,
            FornecedorId = dto.FornecedorId,
            Ativo = true
        };

        await _repository.AddAsync(produto);
        await _repository.SaveChangesAsync();

        return ParaDto(produto);
    }

    public async Task<(bool Sucesso, string? Erro)> UpdateAsync(int id, ProdutoServicoCreateDto dto)
    {
        var produto = await _repository.GetByIdAsync(id);
        if (produto is null) return (false, "Produto não encontrado.");

        produto.Nome = dto.Nome;
        produto.Descricao = dto.Descricao;
        produto.PrecoBase = dto.PrecoBase;
        produto.CategoriaId = dto.CategoriaId;
        produto.FornecedorId = dto.FornecedorId;

        _repository.Update(produto);
        await _repository.SaveChangesAsync();

        return (true, null);
    }

    public async Task<(bool Sucesso, string? Erro)> InativarAsync(int id)
    {
        var produto = await _repository.GetByIdAsync(id);
        if (produto is null) return (false, "Produto não encontrado.");

        produto.Ativo = false;
        _repository.Update(produto);
        await _repository.SaveChangesAsync();

        return (true, null);
    }

    private static ProdutoServicoDto ParaDto(ProdutoServico p) => new()
    {
        Id = p.Id,
        Nome = p.Nome,
        Descricao = p.Descricao,
        PrecoBase = p.PrecoBase,
        Ativo = p.Ativo,
        CategoriaId = p.CategoriaId,
        FornecedorId = p.FornecedorId
    };
}