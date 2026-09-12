using Franquias.Api.DTOs;

namespace Franquias.Api.Services;

public interface IChamadoService
{
    Task<List<ChamadoDto>> GetAllAsync();
    Task<ChamadoDto?> GetByIdAsync(int id);
    Task<List<ChamadoDto>> GetAbertosAsync();
    Task<(bool Sucesso, string? Erro, ChamadoDto? Dto)> CreateAsync(ChamadoCreateDto dto);
    Task<(bool Sucesso, string? Erro)> EncerrarAsync(int id);
}