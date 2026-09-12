using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Franquias.Api.DTOs;
using Franquias.Api.Services;

namespace Franquias.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class FornecedoresController : ControllerBase
{
    private readonly IFornecedorService _service;

    public FornecedoresController(IFornecedorService service)
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
        var fornecedor = await _service.GetByIdAsync(id);
        if (fornecedor is null) return NotFound(new { mensagem = "Fornecedor não encontrado." });
        return Ok(fornecedor);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] FornecedorCreateDto dto)
    {
        var (sucesso, erro, resultado) = await _service.CreateAsync(dto);
        if (!sucesso) return BadRequest(new { mensagem = erro });
        return CreatedAtAction(nameof(GetById), new { id = resultado!.Id }, resultado);
    }

    [HttpPatch("{id}/inativar")]
    public async Task<IActionResult> Inativar(int id)
    {
        var (sucesso, erro) = await _service.InativarAsync(id);
        if (!sucesso) return NotFound(new { mensagem = erro });
        return NoContent();
    }
}