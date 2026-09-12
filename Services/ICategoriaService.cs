using Franquias.Api.DTOs;

namespace Franquias.Api.Services;

public interface ICategoriaService
{
    Task<List<CategoriaDto>> GetAllAsync();
    Task<CategoriaDto?> GetByIdAsync(int id);
    Task<CategoriaDto> CreateAsync(CategoriaCreateDto dto);
}