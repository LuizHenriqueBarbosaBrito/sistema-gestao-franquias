using Franquias.Api.Models;

namespace Franquias.Api.Repositories;

public interface IUnidadeFranqueadaRepository
{
    Task<List<UnidadeFranqueada>> GetAllAsync();
    Task<UnidadeFranqueada?> GetByIdAsync(int id);
    Task<bool> CnpjExisteAsync(string cnpj);
    Task AddAsync(UnidadeFranqueada unidade);
    Task<bool> SaveChangesAsync();
    void Update(UnidadeFranqueada unidade);
}