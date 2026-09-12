using Microsoft.EntityFrameworkCore;
using Franquias.Api.Data;
using Franquias.Api.Models;

namespace Franquias.Api.Repositories;

public class ChamadoRepository : IChamadoRepository
{
    private readonly AppDbContext _context;

    public ChamadoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ChamadoSuporte>> GetAllAsync() =>
        await _context.ChamadosSuporte.ToListAsync();

    public async Task<ChamadoSuporte?> GetByIdAsync(int id) =>
        await _context.ChamadosSuporte.FindAsync(id);

    public async Task<List<ChamadoSuporte>> GetAbertosAsync() =>
        await _context.ChamadosSuporte
            .Where(c => c.Status != StatusChamado.Encerrado)
            .ToListAsync();

    public async Task AddAsync(ChamadoSuporte chamado) =>
        await _context.ChamadosSuporte.AddAsync(chamado);

    public void Update(ChamadoSuporte chamado) =>
        _context.ChamadosSuporte.Update(chamado);

    public async Task<bool> SaveChangesAsync() =>
        await _context.SaveChangesAsync() > 0;
}