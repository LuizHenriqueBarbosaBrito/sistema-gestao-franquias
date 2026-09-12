using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Franquias.Api.Repositories;

namespace Franquias.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class RelatoriosController : ControllerBase
{
    private readonly IRelatorioRepository _repository;

    public RelatoriosController(IRelatorioRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("faturamento-por-unidade")]
    public async Task<IActionResult> FaturamentoPorUnidade()
    {
        var resultado = await _repository.GetFaturamentoPorUnidadeAsync();
        return Ok(resultado);
    }

    [HttpGet("ranking-unidades")]
    public async Task<IActionResult> RankingUnidades()
    {
        // Mesmo dado do faturamento, já vem ordenado do maior para o menor
        var resultado = await _repository.GetFaturamentoPorUnidadeAsync();
        return Ok(resultado);
    }

    [HttpGet("produtos-mais-vendidos")]
    public async Task<IActionResult> ProdutosMaisVendidos()
    {
        var resultado = await _repository.GetProdutosMaisVendidosAsync();
        return Ok(resultado);
    }

    [HttpGet("estoque-critico")]
    public async Task<IActionResult> EstoqueCritico()
    {
        var resultado = await _repository.GetEstoqueCriticoAsync();
        return Ok(resultado);
    }

    [HttpGet("chamados-por-status")]
    public async Task<IActionResult> ChamadosPorStatus()
    {
        var resultado = await _repository.GetChamadosPorStatusAsync();
        return Ok(resultado);
    }
}