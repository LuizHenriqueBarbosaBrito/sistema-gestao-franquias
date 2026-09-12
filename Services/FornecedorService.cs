using Franquias.Api.DTOs;
using Franquias.Api.Models;
using Franquias.Api.Repositories;

namespace Franquias.Api.Services;

public class FornecedorService : IFornecedorService
{
    private readonly IFornecedorRepository _repository;

    public FornecedorService(IFornecedorRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<FornecedorDto>> GetAllAsync()
    {
        var fornecedores = await _repository.GetAllAsync();
        return fornecedores.Select(ParaDto).ToList();
    }

    public async Task<FornecedorDto?> GetByIdAsync(int id)
    {
        var fornecedor = await _repository.GetByIdAsync(id);
        return fornecedor is null ? null : ParaDto(fornecedor);
    }

    public async Task<(bool Sucesso, string? Erro, FornecedorDto? Dto)> CreateAsync(FornecedorCreateDto dto)
    {
        if (await _repository.CnpjExisteAsync(dto.Cnpj))
        {
            return (false, "Já existe um fornecedor cadastrado com este CNPJ.", null);
        }

        var fornecedor = new Fornecedor
        {
            Nome = dto.Nome,
            Cnpj = dto.Cnpj,
            Ativo = true
        };

        await _repository.AddAsync(fornecedor);
        await _repository.SaveChangesAsync();

        return (true, null, ParaDto(fornecedor));
    }

    public async Task<(bool Sucesso, string? Erro)> InativarAsync(int id)
    {
        var fornecedor = await _repository.GetByIdAsync(id);
        if (fornecedor is null)
        {
            return (false, "Fornecedor não encontrado.");
        }

        fornecedor.Ativo = false;
        _repository.Update(fornecedor);
        await _repository.SaveChangesAsync();

        return (true, null);
    }

    private static FornecedorDto ParaDto(Fornecedor f) => new()
    {
        Id = f.Id,
        Nome = f.Nome,
        Cnpj = f.Cnpj,
        Ativo = f.Ativo
    };
}