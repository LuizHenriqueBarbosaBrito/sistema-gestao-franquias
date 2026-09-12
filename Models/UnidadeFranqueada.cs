using System.ComponentModel.DataAnnotations;
using Microsoft.IdentityModel.Tokens;
namespace Franquias.Api.Models;

public class UnidadeFranqueada
{
 public int Id {get; set;}

[Required]
[MaxLength(150)]
public string Nome {get; set;} = string.Empty;

[Required]
[MaxLength(18)]
public string Cnpj {get; set;} = string.Empty;

[MaxLength(100)]
public string? Cidade {get; set;}

[MaxLength(255)]
public string? Endereco {get; set;}

public DateTime DataInicio {get; set;}

public bool Ativo {get; set;} = true;

//toda unidade pertence a uma franqueadora
public int FranqueadoraId {get; set;}
public Franqueadora Franqueadora {get; set;} = null;

//coleções do lado "muitos" do relacionamento
public ICollection<Usuario> Usuarios {get; set;} = new List<Usuario>();
public ICollection<Responsavel> Responsaveis {get; set;} = new List<Responsavel>();
public ICollection<Estoque> Estoques {get; set;} = new List<Estoque>();
public ICollection<Venda> Vendas {get; set;} = new List<Venda>();
public ICollection<Royalty> Royalties {get; set;} = new List<Royalty>();
public ICollection<ChamadoSuporte> ChamadosSuporte {get; set;} = new List<ChamadoSuporte>();
}