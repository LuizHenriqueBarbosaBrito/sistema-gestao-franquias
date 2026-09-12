using Microsoft.EntityFrameworkCore;
using Franquias.Api.Data;
using Franquias.Api.Models;

namespace Franquias.Api.Repositories;

public class RoyaltyRepository : IRoyaltyRepository
{
    private readonly AppDbContext _context;

    public RoyaltyRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Royalty>> GetAllAsync() =>
        await _context.Royalties.ToListAsync();

    public async Task<Royalty?> GetByIdAsync(int id) =>
        await _context.Royalties.FindAsync(id);

    public async Task<decimal> GetFaturamentoDoPeriodoAsync(int unidadeId, string periodo)
    {
        // periodo no formato "AAAA-MM", ex: "2026-09"
        var partes = periodo.Split('-');
        var ano = int.Parse(partes[0]);
        var mes = int.Parse(partes[1]);

        return await _context.Vendas
            .Where(v => v.UnidadeFranqueadaId == unidadeId
                     && v.DataVenda.Year == ano
                     && v.DataVenda.Month == mes)
            .SumAsync(v => (decimal?)v.ValorTotal) ?? 0;
    }

    public async Task AddAsync(Royalty royalty) =>
        await _context.Royalties.AddAsync(royalty);

    public void Update(Royalty royalty) =>
        _context.Royalties.Update(royalty);

    public async Task<bool> SaveChangesAsync() =>
        await _context.SaveChangesAsync() > 0;
}