using System.ComponentModel.DataAnnotations.Schema;

namespace Franquias.Api.Models;

public class ItemVenda
{
    public int Id {get; set; }

    public int VendaId {get; set;}
    public Venda Venda {get; set;} = null!;

    public int ProdutoServicoId {get; set;}
    public ProdutoServico ProdutoServico {get; set;} = null!;

    public int Quantidade {get; set;}

    [Column(TypeName = "decimal(10,2)")]
    public decimal PrecoUnitario {get; set;}

    //calcula automaticamente Quantidade * PrecoUnitario
    [NotMapped]
    public decimal SubTotal => Quantidade * PrecoUnitario;
}