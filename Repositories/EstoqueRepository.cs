using Microsoft.EntityFrameworkCore;
using Franquias.Api.Data;
using Franquias.Api.Models;

namespace Franquias.Api.Repositories;

public class EstoqueRepository : IEstoqueRepository
{
    private readonly AppDbContext _context;

    public EstoqueRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Estoque>> GetAllAsync() =>
        await _context.Estoques.ToListAsync();

    public async Task<Estoque?> GetByIdAsync(int id) =>
        await _context.Estoques.FindAsync(id);

    public async Task<List<Estoque>> GetAbaixoDoMinimoAsync() =>
        await _context.Estoques.Where(e => e.SaldoAtual < e.EstoqueMinimo).ToListAsync();

    public async Task<bool> ExisteParaUnidadeProdutoAsync(int unidadeId, int produtoId) =>
        await _context.Estoques.AnyAsync(e => e.UnidadeFranqueadaId == unidadeId && e.ProdutoServicoId == produtoId);

    public async Task AddAsync(Estoque estoque) =>
        await _context.Estoques.AddAsync(estoque);

    public async Task AddMovimentacaoAsync(MovimentacaoEstoque movimentacao) =>
        await _context.MovimentacoesEstoque.AddAsync(movimentacao);

    public void Update(Estoque estoque) =>
        _context.Estoques.Update(estoque);

    public async Task<bool> SaveChangesAsync() =>
        await _context.SaveChangesAsync() > 0;
}