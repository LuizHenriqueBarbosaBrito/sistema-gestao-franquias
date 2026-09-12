using   System.ComponentModel.DataAnnotations;

namespace Franquias.Api.Models;

public class Responsavel
{
    public int Id {get; set;}

    [Required]
    [MaxLength(150)]
    public string Nome {get; set;} = string.Empty;

    [Required]
    [MaxLength(14)]
    public string Cpf {get; set;} = string.Empty;

    [MaxLength(20)]
    public string? Telefone {get; set;} 

    [MaxLength(150)]
    public string? Email {get; set;} 

    //todo responsavel pertence a uma unidade franqueada
    public int UnidadeFranqueadaId {get; set;}
    public UnidadeFranqueada UnidadeFranqueada {get; set;} = null!;
}