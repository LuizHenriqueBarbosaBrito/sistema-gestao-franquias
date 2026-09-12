using Franquias.Api.Models;

namespace Franquias.Api.Repositories;

public interface IFranqueadoraRepository
{
    Task<List<Franqueadora>> GetAllAsync();
    Task<Franqueadora?> GetByIdAsync(int id);
    Task<bool> CnpjExisteAsync(string cnpj);
    Task AddAsync(Franqueadora franqueadora);
    Task<bool> SaveChangesAsync();
}