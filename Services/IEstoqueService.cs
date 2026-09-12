using Franquias.Api.DTOs;

namespace Franquias.Api.Services;

public interface IEstoqueService
{
    Task<List<EstoqueDto>> GetAllAsync();
    Task<EstoqueDto?> GetByIdAsync(int id);
    Task<List<EstoqueDto>> GetAbaixoDoMinimoAsync();
    Task<(bool Sucesso, string? Erro, EstoqueDto? Dto)> CreateAsync(EstoqueCreateDto dto);
    Task<(bool Sucesso, string? Erro)> MovimentarAsync(MovimentacaoEstoqueDto dto);
}