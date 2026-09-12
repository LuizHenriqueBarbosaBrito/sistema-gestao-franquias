using Franquias.Api.Models;

namespace Franquias.Api.Repositories;

public interface IRoyaltyRepository
{
    Task<List<Royalty>> GetAllAsync();
    Task<Royalty?> GetByIdAsync(int id);
    Task<decimal> GetFaturamentoDoPeriodoAsync(int unidadeId, string periodo);
    Task AddAsync(Royalty royalty);
    Task<bool> SaveChangesAsync();
    void Update(Royalty royalty);
}