using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Franquias.Api.DTOs;
using Franquias.Api.Services;

namespace Franquias.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ChamadosController : ControllerBase
{
    private readonly IChamadoService _service;

    public ChamadosController(IChamadoService service)
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
        var chamado = await _service.GetByIdAsync(id);
        if (chamado is null) return NotFound(new { mensagem = "Chamado não encontrado." });
        return Ok(chamado);
    }

    [HttpGet("abertos")]
    public async Task<IActionResult> GetAbertos()
    {
        var lista = await _service.GetAbertosAsync();
        return Ok(lista);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ChamadoCreateDto dto)
    {
        var (sucesso, erro, resultado) = await _service.CreateAsync(dto);
        if (!sucesso) return BadRequest(new { mensagem = erro });
        return CreatedAtAction(nameof(GetById), new { id = resultado!.Id }, resultado);
    }

    [HttpPut("{id}/encerrar")]
    public async Task<IActionResult> Encerrar(int id)
    {
        var (sucesso, erro) = await _service.EncerrarAsync(id);
        if (!sucesso) return NotFound(new { mensagem = erro });
        return NoContent();
    }
}