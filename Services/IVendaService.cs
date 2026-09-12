using Franquias.Api.DTOs;

namespace Franquias.Api.Services;

public interface IVendaService
{
    Task<List<VendaDto>> GetAllAsync();
    Task<VendaDto?> GetByIdAsync(int id);
    Task<(bool Sucesso, string? Erro, VendaDto? Dto)> CreateAsync(VendaCreateDto dto);
}