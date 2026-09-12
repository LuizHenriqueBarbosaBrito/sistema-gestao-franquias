using Franquias.Api.DTOs;

namespace Franquias.Api.Services;

public interface IUnidadeFranqueadaService
{
    Task<List<UnidadeFranqueadaDto>> GetAllAsync();
    Task<UnidadeFranqueadaDto?> GetByIdAsync(int id);
    Task<(bool Sucesso, string? Erro, UnidadeFranqueadaDto? Dto)> CreateAsync(UnidadeFranqueadaCreateDto dto);
    Task<(bool Sucesso, string? Erro)> UpdateAsync(int id, UnidadeFranqueadaCreateDto dto);
    Task<(bool Sucesso, string? Erro)> InativarAsync(int id);
}