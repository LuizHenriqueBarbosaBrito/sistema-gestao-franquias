using Franquias.Api.Models;

namespace Franquias.Api.Repositories;

public interface IProdutoServicoRepository
{
    Task<List<ProdutoServico>> GetAllAsync();
    Task<ProdutoServico?> GetByIdAsync(int id);
    Task AddAsync(ProdutoServico produto);
    Task<bool> SaveChangesAsync();
    void Update(ProdutoServico produto);
}