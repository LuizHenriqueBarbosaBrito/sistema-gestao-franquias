using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Franquias.Api.DTOs;
using Franquias.Api.Services;

namespace Franquias.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class FranqueadorasController : ControllerBase
{
    private readonly IFranqueadoraService _service;

    public FranqueadorasController(IFranqueadoraService service)
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
        var franqueadora = await _service.GetByIdAsync(id);
        if (franqueadora is null)
        {
            return NotFound(new {mensagem = "Franqueadora não encontrada."});
        }
        return Ok(franqueadora);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] FranqueadoraCreateDto dto)
    {
        var (sucesso, erro, resultado) = await _service.CreateAsync(dto);

        if (!sucesso)
        {
            return BadRequest(new { mensagem = erro});
        }
        return CreatedAtAction(nameof(GetById), new {id = resultado!.Id}, resultado);
    }
}