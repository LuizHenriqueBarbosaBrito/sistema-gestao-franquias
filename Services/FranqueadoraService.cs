using Franquias.Api.DTOs;
using Franquias.Api.Models;
using Franquias.Api.Repositories;

namespace Franquias.Api.Services;

public class FranqueadoraService : IFranqueadoraService
{
    private readonly IFranqueadoraRepository _repository;

    public FranqueadoraService(IFranqueadoraRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<FranqueadoraDto>> GetAllAsync()
    {
        var franqueadoras = await _repository.GetAllAsync();
        return franqueadoras.Select(ParaDto).ToList();
    }

    public async Task<FranqueadoraDto?> GetByIdAsync(int id)
    {
        var franqueadora = await _repository.GetByIdAsync(id);
        return franqueadora is null ? null : ParaDto(franqueadora);
    }

    public async Task<(bool Sucesso, string? Erro, FranqueadoraDto? Dto)> CreateAsync(FranqueadoraCreateDto dto)
    {
        if (await _repository.CnpjExisteAsync(dto.Cnpj))
        {
            return (false, "Já existe uma franqueadora cadastrada com este CNPJ.", null);
        }

        var franqueadora = new Franqueadora
        {
            RazaoSocial = dto.RazaoSocial,
            Cnpj = dto.Cnpj
        };

        await _repository.AddAsync(franqueadora);
        await _repository.SaveChangesAsync();

        return (true, null, ParaDto(franqueadora));
    }

    private static FranqueadoraDto ParaDto(Franqueadora f) => new()
    {
        Id = f.Id,
        RazaoSocial = f.RazaoSocial,
        Cnpj = f.Cnpj
    };
}