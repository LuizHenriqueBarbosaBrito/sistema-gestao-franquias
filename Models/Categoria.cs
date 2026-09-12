using System.ComponentModel.DataAnnotations;

namespace Franquias.Api.Models;

public class Categoria
{
    public int Id {get; set;}

    [Required]
    [MaxLength(100)]
    public string Nome {get; set;} = string.Empty;

    //Uma categoria pode ter vários produtos 
    public ICollection<ProdutoServico> Produtos {get; set;} = new List<ProdutoServico>();
}
