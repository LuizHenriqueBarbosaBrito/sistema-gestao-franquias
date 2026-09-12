using Franquias.Api.DTOs;

namespace Franquias.Api.Services;

public interface IFornecedorService
{
    Task<List<FornecedorDto>> GetAllAsync();
    Task<FornecedorDto?> GetByIdAsync(int id);
    Task<(bool Sucesso, string? Erro, FornecedorDto? Dto)> CreateAsync(FornecedorCreateDto dto);
    Task<(bool Sucesso, string? Erro)> InativarAsync(int id);
}