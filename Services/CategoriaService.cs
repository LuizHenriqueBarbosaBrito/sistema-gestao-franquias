using Franquias.Api.DTOs;
using Franquias.Api.Models;
using Franquias.Api.Repositories;

namespace Franquias.Api.Services;

public class CategoriaService : ICategoriaService
{
    private readonly ICategoriaRepository _repository;

    public CategoriaService(ICategoriaRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<CategoriaDto>> GetAllAsync()
    {
        var categorias = await _repository.GetAllAsync();
        return categorias.Select(ParaDto).ToList();
    }

    public async Task<CategoriaDto?> GetByIdAsync(int id)
    {
        var categoria = await _repository.GetByIdAsync(id);
        return categoria is null ? null : ParaDto(categoria);
    }

    public async Task<CategoriaDto> CreateAsync(CategoriaCreateDto dto)
    {
        var categoria = new Categoria
        {
            Nome = dto.Nome
        };

        await _repository.AddAsync(categoria);
        await _repository.SaveChangesAsync();

        return ParaDto(categoria);
    }

    private static CategoriaDto ParaDto(Categoria c) => new()
    {
        Id = c.Id,
        Nome = c.Nome
    };
}