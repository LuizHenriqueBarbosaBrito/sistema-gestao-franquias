using Franquias.Api.Models;

namespace Franquias.Api.Repositories;

public interface IEstoqueRepository
{
    Task<List<Estoque>> GetAllAsync();
    Task<Estoque?> GetByIdAsync(int id);
    Task<List<Estoque>> GetAbaixoDoMinimoAsync();
    Task<bool> ExisteParaUnidadeProdutoAsync(int unidadeId, int produtoId);
    Task AddAsync(Estoque estoque);
    Task AddMovimentacaoAsync(MovimentacaoEstoque movimentacao);
    Task<bool> SaveChangesAsync();
    void Update(Estoque estoque);
}