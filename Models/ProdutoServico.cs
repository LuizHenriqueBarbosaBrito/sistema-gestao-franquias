using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Franquias.Api.Models;

public class ProdutoServico
{
    public int Id {get; set;}

    [Required]
    [MaxLength(150)]
    public string Nome {get; set;} = string.Empty;

    [MaxLength(500)]
    public string? Descricao {get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal PrecoBase { get; set; }

    public bool Ativo {get; set; } = true;

    //todo pruduto pertence a uma categoria 
    public int CategoriaId {get; set;}
    public Categoria Categoria {get; set;} = null!;

    //fornecedor principal do produto
    public int? FornecedorId {get; set;}
    public Fornecedor? Fornecedor {get; set;}

    // onde esse produto aparece pelo sistema
    public ICollection<Estoque> Estoques {get; set;} = new List<Estoque>();
    public ICollection<ItemVenda> ItensVenda {get; set;} = new List<ItemVenda>();
}
