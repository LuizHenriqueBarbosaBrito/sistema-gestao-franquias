using Franquias.Api.DTOs;

namespace Franquias.Api.Services;

public interface IProdutoServicoService
{
    Task<List<ProdutoServicoDto>> GetAllAsync();
    Task<ProdutoServicoDto?> GetByIdAsync(int id);
    Task<ProdutoServicoDto> CreateAsync(ProdutoServicoCreateDto dto);
    Task<(bool Sucesso, string? Erro)> UpdateAsync(int id, ProdutoServicoCreateDto dto);
    Task<(bool Sucesso, string? Erro)> InativarAsync(int id);
}