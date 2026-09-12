using Franquias.Api.Models;

namespace Franquias.Api.Repositories;

public interface ICategoriaRepository
{
    Task<List<Categoria>> GetAllAsync();
    Task<Categoria?> GetByIdAsync(int id);
    Task AddAsync(Categoria categoria);
    Task<bool> SaveChangesAsync();
}
