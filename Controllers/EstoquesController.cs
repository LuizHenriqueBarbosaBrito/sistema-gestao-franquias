using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Franquias.Api.DTOs;
using Franquias.Api.Services;

namespace Franquias.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class EstoquesController : ControllerBase
{
    private readonly IEstoqueService _service;

    public EstoquesController(IEstoqueService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var lista = await _service.GetAllAsync();
        return Ok(lista);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var estoque = await _service.GetByIdAsync(id);
        if (estoque is null) return NotFound(new { mensagem = "Estoque não encontrado." });
        return Ok(estoque);
    }

    [HttpGet("abaixo-do-minimo")]
    public async Task<IActionResult> GetAbaixoDoMinimo()
    {
        var lista = await _service.GetAbaixoDoMinimoAsync();
        return Ok(lista);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] EstoqueCreateDto dto)
    {
        var (sucesso, erro, resultado) = await _service.CreateAsync(dto);
        if (!sucesso) return BadRequest(new { mensagem = erro });
        return CreatedAtAction(nameof(GetById), new { id = resultado!.Id }, resultado);
    }

    [HttpPost("movimentar")]
    public async Task<IActionResult> Movimentar([FromBody] MovimentacaoEstoqueDto dto)
    {
        var (sucesso, erro) = await _service.MovimentarAsync(dto);
        if (!sucesso) return BadRequest(new { mensagem = erro });
        return NoContent();
    }
}