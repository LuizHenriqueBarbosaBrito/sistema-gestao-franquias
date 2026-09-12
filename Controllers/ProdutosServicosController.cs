using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Franquias.Api.DTOs;
using Franquias.Api.Services;

namespace Franquias.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProdutosServicosController : ControllerBase
{
    private readonly IProdutoServicoService _service;

    public ProdutosServicosController(IProdutoServicoService service)
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
        var produto = await _service.GetByIdAsync(id);
        if (produto is null) return NotFound(new { mensagem = "Produto não encontrado." });
        return Ok(produto);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProdutoServicoCreateDto dto)
    {
        var resultado = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = resultado.Id }, resultado);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ProdutoServicoCreateDto dto)
    {
        var (sucesso, erro) = await _service.UpdateAsync(id, dto);
        if (!sucesso) return NotFound(new { mensagem = erro });
        return NoContent();
    }

    [HttpPatch("{id}/inativar")]
    public async Task<IActionResult> Inativar(int id)
    {
        var (sucesso, erro) = await _service.InativarAsync(id);
        if (!sucesso) return NotFound(new { mensagem = erro });
        return NoContent();
    }
}