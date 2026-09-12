using Franquias.Api.Models;

namespace Franquias.Api.Repositories;

public interface IUsuarioRepository
{
    Task<Usuario?> GetByEmailAsync(string email);
    Task<bool> EmailExisteAsync(string email);
    Task AddAsync(Usuario usuario);
    Task<bool> SaveChangesAsync();
}