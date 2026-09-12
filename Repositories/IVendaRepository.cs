using Franquias.Api.Models;

namespace Franquias.Api.Repositories;

public interface IVendaRepository
{
    Task<List<Venda>> GetAllAsync();
    Task<Venda?> GetByIdAsync(int id);
    Task<UnidadeFranqueada?> GetUnidadeAsync(int unidadeId);
    Task<ProdutoServico?> GetProdutoAsync(int produtoId);
    Task<Estoque?> GetEstoqueAsync(int unidadeId, int produtoId);
    Task AddAsync(Venda venda);
    Task AddMovimentacaoAsync(MovimentacaoEstoque movimentacao);
    Task<bool> SaveChangesAsync();
}