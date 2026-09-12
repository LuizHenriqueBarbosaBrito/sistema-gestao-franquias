using Franquias.Api.DTOs;
using Franquias.Api.Models;
using Franquias.Api.Repositories;

namespace Franquias.Api.Services;

public class UnidadeFranqueadaService : IUnidadeFranqueadaService
{
    private readonly IUnidadeFranqueadaRepository _repository;

    public UnidadeFranqueadaService(IUnidadeFranqueadaRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<UnidadeFranqueadaDto>> GetAllAsync()
    {
        var unidades = await _repository.GetAllAsync();
        return unidades.Select(ParaDto).ToList();
    }

    public async Task<UnidadeFranqueadaDto?> GetByIdAsync(int id)
    {
        var unidade = await _repository.GetByIdAsync(id);
        return unidade is null ? null : ParaDto(unidade);
    }

    public async Task<(bool Sucesso, string? Erro, UnidadeFranqueadaDto? Dto)> CreateAsync(UnidadeFranqueadaCreateDto dto)
    {
        if (await _repository.CnpjExisteAsync(dto.Cnpj))
        {
            return (false, "Já existe uma unidade cadastrada com este CNPJ.", null);
        }

        var unidade = new UnidadeFranqueada
        {
            Nome = dto.Nome,
            Cnpj = dto.Cnpj,
            Cidade = dto.Cidade,
            Endereco = dto.Endereco,
            DataInicio = dto.DataInicio,
            FranqueadoraId = dto.FranqueadoraId,
            Ativo = true
        };

        await _repository.AddAsync(unidade);
        await _repository.SaveChangesAsync();

        return (true, null, ParaDto(unidade));
    }

    public async Task<(bool Sucesso, string? Erro)> UpdateAsync(int id, UnidadeFranqueadaCreateDto dto)
    {
        var unidade = await _repository.GetByIdAsync(id);
        if (unidade is null)
        {
            return (false, "Unidade não encontrada.");
        }

        unidade.Nome = dto.Nome;
        unidade.Cidade = dto.Cidade;
        unidade.Endereco = dto.Endereco;
        unidade.DataInicio = dto.DataInicio;
        // CNPJ não é alterado na edição, por segurança

        _repository.Update(unidade);
        await _repository.SaveChangesAsync();

        return (true, null);
    }

    public async Task<(bool Sucesso, string? Erro)> InativarAsync(int id)
    {
        var unidade = await _repository.GetByIdAsync(id);
        if (unidade is null)
        {
            return (false, "Unidade não encontrada.");
        }

        unidade.Ativo = false;
        _repository.Update(unidade);
        await _repository.SaveChangesAsync();

        return (true, null);
    }

    private static UnidadeFranqueadaDto ParaDto(UnidadeFranqueada u) => new()
    {
        Id = u.Id,
        Nome = u.Nome,
        Cnpj = u.Cnpj,
        Cidade = u.Cidade,
        Endereco = u.Endereco,
        DataInicio = u.DataInicio,
        Ativo = u.Ativo,
        FranqueadoraId = u.FranqueadoraId
    };
}