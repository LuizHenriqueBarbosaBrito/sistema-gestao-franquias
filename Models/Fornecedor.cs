using System.ComponentModel.DataAnnotations;

namespace Franquias.Api.Models; 

public class Fornecedor
{
    public int Id {get; set;}

    [Required]
    [MaxLength(150)]
    public string Nome {get; set;} = string.Empty;

    [Required]
    [MaxLength(18)]
    public string Cnpj {get; set; } = string.Empty;

    public bool Ativo {get; set;} = true;

    // um fornecedor pode ter vários produtos
    public ICollection<ProdutoServico> Produtos {get; set;} = new List<ProdutoServico>();
    }