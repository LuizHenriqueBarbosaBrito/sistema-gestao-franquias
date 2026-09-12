using Microsoft.AspNetCore.Mvc;
using Franquias.Api.DTOs;
using Franquias.Api.Services;

namespace Franquias.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var (sucesso, erro, resultado) = await _authService.LoginAsync(dto);

        if (!sucesso)
        {
            return Unauthorized(new { mensagem = erro });
        }

        return Ok(resultado);
    }

    [HttpPost("registrar")]
    public async Task<IActionResult> Registrar([FromBody] UsuarioCreateDto dto)
    {
        var (sucesso, erro) = await _authService.RegistrarAsync(dto);

        if (!sucesso)
        {
            return BadRequest(new { mensagem = erro });
        }

        return Ok(new { mensagem = "Usuário criado com sucesso." });
    }
}