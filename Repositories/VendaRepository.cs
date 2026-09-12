using Microsoft.EntityFrameworkCore;
using Franquias.Api.Data;
using Franquias.Api.Models;

namespace Franquias.Api.Repositories;

public class VendaRepository : IVendaRepository
{
    private readonly AppDbContext _context;

    public VendaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Venda>> GetAllAsync() =>
        await _context.Vendas.Include(v => v.Itens).ToListAsync();

    public async Task<Venda?> GetByIdAsync(int id) =>
        await _context.Vendas.Include(v => v.Itens).FirstOrDefaultAsync(v => v.Id == id);

    public async Task<UnidadeFranqueada?> GetUnidadeAsync(int unidadeId) =>
        await _context.UnidadesFranqueadas.FindAsync(unidadeId);

    public async Task<ProdutoServico?> GetProdutoAsync(int produtoId) =>
        await _context.ProdutosServicos.FindAsync(produtoId);

    public async Task<Estoque?> GetEstoqueAsync(int unidadeId, int produtoId) =>
        await _context.Estoques.FirstOrDefaultAsync(e =>
            e.UnidadeFranqueadaId == unidadeId && e.ProdutoServicoId == produtoId);

    public async Task AddAsync(Venda venda) =>
        await _context.Vendas.AddAsync(venda);

    public async Task AddMovimentacaoAsync(MovimentacaoEstoque movimentacao) =>
        await _context.MovimentacoesEstoque.AddAsync(movimentacao);

    public async Task<bool> SaveChangesAsync() =>
        await _context.SaveChangesAsync() > 0;
}