using System.ComponentModel.DataAnnotations;

namespace Franquias.Api.Models;

public class Franqueadora
{
  public int Id {get; set;}

  [Required]
  [MaxLength(150)]
  public string RazaoSocial {get; set;} = string.Empty;

  [Required]
  [MaxLength(18)]
  public  string Cnpj {get;set;} = string.Empty;

  // uma franqueadora pode ter várias unidades
  public ICollection<UnidadeFranqueada> UnidadesFranqueadas {get; set;} = new List<UnidadeFranqueada>();
}