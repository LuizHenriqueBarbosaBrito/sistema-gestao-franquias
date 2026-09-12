using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Franquias.Api.Models;

public class Venda
{
    public int Id {get; set;}

    public int UnidadeFranqueadaId {get; set;}
    public UnidadeFranqueada UnidadeFranqueada {get; set;} = null!;

    public int UsuarioId {get; set;}
    public Usuario Usuario {get; set;} = null!;

    public DateTime DataVenda {get; set;} = DateTime.Now;

    [Column(TypeName = "decimal(10,2)")] 
    public decimal ValorTotal {get; set;}
    
    //toda venda precisa de pelo menos um item de venda
    public ICollection<ItemVenda> Itens {get; set;} = new List<ItemVenda>();
}