using System.ComponentModel.DataAnnotations;

namespace Franquias.Api.Models;

public class Perfil
{
    public int id {get; set;}

    [Required]
    [MaxLength(50)]
    public string Nome {get; set;} = string.Empty;

// um perfil pode ter vários usuários
public ICollection<Usuario> Usuarios { get;set; } = new List<Usuario>();
}