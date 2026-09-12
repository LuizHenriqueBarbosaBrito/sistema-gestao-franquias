using Franquias.Api.DTOs;

namespace Franquias.Api.Services;

public interface IAuthService
{
    Task<(bool Sucesso, string? Erro, LoginResponseDto? Resultado)> LoginAsync(LoginDto dto);
    Task<(bool Sucesso, string? Erro)> RegistrarAsync(UsuarioCreateDto dto);
}