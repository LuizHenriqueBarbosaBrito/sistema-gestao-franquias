using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Franquias.Api.DTOs;
using Franquias.Api.Services;

namespace Franquias.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class RoyaltiesController : ControllerBase
{
    private readonly IRoyaltyService _service;

    public RoyaltiesController(IRoyaltyService service)
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
        var royalty = await _service.GetByIdAsync(id);
        if (royalty is null) return NotFound(new { mensagem = "Royalty não encontrado." });
        return Ok(royalty);
    }

    [HttpPost("calcular")]
    public async Task<IActionResult> Calcular([FromBody] RoyaltyCalcularDto dto)
    {
        var resultado = await _service.CalcularAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = resultado.Id }, resultado);
    }

    [HttpPut("{id}/pagar")]
    public async Task<IActionResult> Pagar(int id)
    {
        var (sucesso, erro) = await _service.MarcarComoPagoAsync(id);
        if (!sucesso) return NotFound(new { mensagem = erro });
        return NoContent();
    }
}