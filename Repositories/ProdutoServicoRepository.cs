using Microsoft.EntityFrameworkCore;
using Franquias.Api.Data;
using Franquias.Api.Models;

namespace Franquias.Api.Repositories;

public class ProdutoServicoRepository : IProdutoServicoRepository
{
    private readonly AppDbContext _context;

    public ProdutoServicoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProdutoServico>> GetAllAsync() =>
        await _context.ProdutosServicos.ToListAsync();

    public async Task<ProdutoServico?> GetByIdAsync(int id) =>
        await _context.ProdutosServicos.FindAsync(id);

    public async Task AddAsync(ProdutoServico produto) =>
        await _context.ProdutosServicos.AddAsync(produto);

    public void Update(ProdutoServico produto) =>
        _context.ProdutosServicos.Update(produto);

    public async Task<bool> SaveChangesAsync() =>
        await _context.SaveChangesAsync() > 0;
}