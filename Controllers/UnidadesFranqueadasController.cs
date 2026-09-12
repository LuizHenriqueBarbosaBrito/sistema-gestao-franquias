using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Franquias.Api.DTOs;
using Franquias.Api.Services;

namespace Franquias.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UnidadesFranqueadasController : ControllerBase
{
    private readonly IUnidadeFranqueadaService _service;

    public UnidadesFranqueadasController(IUnidadeFranqueadaService service)
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
        var unidade = await _service.GetByIdAsync(id);
        if (unidade is null)
        {
            return NotFound(new { mensagem = "Unidade não encontrada." });
        }
        return Ok(unidade);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UnidadeFranqueadaCreateDto dto)
    {
        var (sucesso, erro, resultado) = await _service.CreateAsync(dto);
        if (!sucesso)
        {
            return BadRequest(new { mensagem = erro });
        }
        return CreatedAtAction(nameof(GetById), new { id = resultado!.Id }, resultado);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UnidadeFranqueadaCreateDto dto)
    {
        var (sucesso, erro) = await _service.UpdateAsync(id, dto);
        if (!sucesso)
        {
            return NotFound(new { mensagem = erro });
        }
        return NoContent();
    }

    [HttpPatch("{id}/inativar")]
    public async Task<IActionResult> Inativar(int id)
    {
        var (sucesso, erro) = await _service.InativarAsync(id);
        if (!sucesso)
        {
            return NotFound(new { mensagem = erro });
        }
        return NoContent();
    }
}