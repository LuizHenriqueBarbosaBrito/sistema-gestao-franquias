using System.ComponentModel.DataAnnotations;

namespace Franquias.Api.Models;

public class Usuario
{
    public int Id { get; set; }

    [Required]
    [MaxLength(150)]
    public string Nome { get; set;} = string.Empty;

    [Required]
    [MaxLength(150)]
    public string Email { get; set;} = string.Empty;

    [Required]
    public string SenhaHash { get; set;} = string.Empty;

    public bool Ativo {get; set;} = true;

    //todo usário pertence a um perfil
    public int PerfilId {get; set;}
    public Perfil Perfil { get; set;} = null!;

    public int? UnidadeFranqueadaId {get; set; }
    public UnidadeFranqueada? UnidadeFranqueada {get; set;}
}