using Franquias.Api.DTOs;

namespace Franquias.Api.Services;

public interface IRoyaltyService
{
    Task<List<RoyaltyDto>> GetAllAsync();
    Task<RoyaltyDto?> GetByIdAsync(int id);
    Task<RoyaltyDto> CalcularAsync(RoyaltyCalcularDto dto);
    Task<(bool Sucesso, string? Erro)> MarcarComoPagoAsync(int royaltyId);
}