using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Franquias.Api.DTOs;
using Franquias.Api.Services;

namespace Franquias.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class VendasController : ControllerBase
{
    private readonly IVendaService _service;

    public VendasController(IVendaService service)
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
        var venda = await _service.GetByIdAsync(id);
        if (venda is null) return NotFound(new { mensagem = "Venda não encontrada." });
        return Ok(venda);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] VendaCreateDto dto)
    {
        var (sucesso, erro, resultado) = await _service.CreateAsync(dto);
        if (!sucesso) return BadRequest(new { mensagem = erro });
        return CreatedAtAction(nameof(GetById), new { id = resultado!.Id }, resultado);
    }
}