using Microsoft.EntityFrameworkCore;
using Franquias.Api.Data;
using Franquias.Api.DTOs;

namespace Franquias.Api.Repositories;

public class RelatorioRepository : IRelatorioRepository
{
    private readonly AppDbContext _context;

    public RelatorioRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<FaturamentoUnidadeDto>> GetFaturamentoPorUnidadeAsync()
    {
        return await _context.Vendas
            .GroupBy(v => new { v.UnidadeFranqueadaId, v.UnidadeFranqueada.Nome })
            .Select(g => new FaturamentoUnidadeDto
            {
                UnidadeFranqueadaId = g.Key.UnidadeFranqueadaId,
                NomeUnidade = g.Key.Nome,
                Faturamento = g.Sum(v => v.ValorTotal)
            })
            .OrderByDescending(f => f.Faturamento)
            .ToListAsync();
    }

    public async Task<List<ProdutoMaisVendidoDto>> GetProdutosMaisVendidosAsync()
    {
        return await _context.ItensVenda
            .GroupBy(i => new { i.ProdutoServicoId, i.ProdutoServico.Nome })
            .Select(g => new ProdutoMaisVendidoDto
            {
                ProdutoServicoId = g.Key.ProdutoServicoId,
                NomeProduto = g.Key.Nome,
                QuantidadeVendida = g.Sum(i => i.Quantidade)
            })
            .OrderByDescending(p => p.QuantidadeVendida)
            .ToListAsync();
    }

    public async Task<List<EstoqueCriticoDto>> GetEstoqueCriticoAsync()
    {
        return await _context.Estoques
            .Where(e => e.SaldoAtual < e.EstoqueMinimo)
            .Select(e => new EstoqueCriticoDto
            {
                EstoqueId = e.Id,
                NomeProduto = e.ProdutoServico.Nome,
                NomeUnidade = e.UnidadeFranqueada.Nome,
                SaldoAtual = e.SaldoAtual,
                EstoqueMinimo = e.EstoqueMinimo
            })
            .ToListAsync();
    }

    public async Task<List<ChamadosPorStatusDto>> GetChamadosPorStatusAsync()
    {
        return await _context.ChamadosSuporte
            .GroupBy(c => c.Status)
            .Select(g => new ChamadosPorStatusDto
            {
                Status = g.Key.ToString(),
                Quantidade = g.Count()
            })
            .ToListAsync();
    }
}