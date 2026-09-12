using Microsoft.EntityFrameworkCore;
using Franquias.Api.Data;
using Franquias.Api.Models;

namespace Franquias.Api.Repositories;

public class UnidadeFranqueadaRepository : IUnidadeFranqueadaRepository
{
    private readonly AppDbContext _context;

    public UnidadeFranqueadaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<UnidadeFranqueada>> GetAllAsync()
    {
        return await _context.UnidadesFranqueadas.ToListAsync();
    }

    public async Task<UnidadeFranqueada?> GetByIdAsync(int id)
    {
        return await _context.UnidadesFranqueadas.FindAsync(id);
    }

    public async Task<bool> CnpjExisteAsync(string cnpj)
    {
        return await _context.UnidadesFranqueadas.AnyAsync(u => u.Cnpj == cnpj);
    }

    public async Task AddAsync(UnidadeFranqueada unidade)
    {
        await _context.UnidadesFranqueadas.AddAsync(unidade);
    }

    public void Update(UnidadeFranqueada unidade)
    {
        _context.UnidadesFranqueadas.Update(unidade);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}