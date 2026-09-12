using Franquias.Api.Models;

namespace Franquias.Api.Repositories;

public interface IChamadoRepository
{
    Task<List<ChamadoSuporte>> GetAllAsync();
    Task<ChamadoSuporte?> GetByIdAsync(int id);
    Task<List<ChamadoSuporte>> GetAbertosAsync();
    Task AddAsync(ChamadoSuporte chamado);
    Task<bool> SaveChangesAsync();
    void Update(ChamadoSuporte chamado);
}