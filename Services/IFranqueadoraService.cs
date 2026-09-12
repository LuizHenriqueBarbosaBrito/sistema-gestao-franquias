using Franquias.Api.DTOs;

namespace Franquias.Api.Services;

public interface IFranqueadoraService
{
    Task<List<FranqueadoraDto>> GetAllAsync();
    Task<FranqueadoraDto?> GetByIdAsync(int id);
    Task<(bool Sucesso, string? Erro, FranqueadoraDto? Dto)> CreateAsync(FranqueadoraCreateDto dto);
}