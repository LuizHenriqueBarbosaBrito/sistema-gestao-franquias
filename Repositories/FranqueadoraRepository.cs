using Microsoft.EntityFrameworkCore;
using Franquias.Api.Data;
using Franquias.Api.Models;

namespace Franquias.Api.Repositories;

public class FranqueadoraRepository : IFranqueadoraRepository
{
    private readonly AppDbContext _context;

    public FranqueadoraRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Franqueadora>> GetAllAsync()
    {
        return await _context.Franqueadoras.ToListAsync();
    }

    public async Task<Franqueadora?> GetByIdAsync(int id)
    {
        return await _context.Franqueadoras.FindAsync(id);
    }

    public async Task<bool> CnpjExisteAsync(string cnpj)
    {
        return await _context.Franqueadoras.AnyAsync(f => f.Cnpj == cnpj);
    }

    public async Task AddAsync(Franqueadora franqueadora)
    {
        await _context.Franqueadoras.AddAsync(franqueadora);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}