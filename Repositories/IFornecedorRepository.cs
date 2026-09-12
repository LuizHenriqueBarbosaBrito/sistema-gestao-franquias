using Franquias.Api.Models;

namespace Franquias.Api.Repositories;

public interface IFornecedorRepository
{
    Task<List<Fornecedor>> GetAllAsync();
    Task<Fornecedor?> GetByIdAsync(int id);
    Task<bool> CnpjExisteAsync(string cnpj);
    Task AddAsync(Fornecedor fornecedor);
    Task<bool> SaveChangesAsync();
    void Update(Fornecedor fornecedor);
}