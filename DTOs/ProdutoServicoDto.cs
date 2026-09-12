namespace Franquias.Api.DTOs;

public class ProdutoServicoDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? Descricao { get; set; }
    public decimal PrecoBase { get; set; }
    public bool Ativo { get; set; }
    public int CategoriaId { get; set; }
    public int? FornecedorId { get; set; }
}

public class ProdutoServicoCreateDto
{
    public string Nome { get; set; } = string.Empty;
    public string? Descricao { get; set; }
    public decimal PrecoBase { get; set; }
    public int CategoriaId { get; set; }
    public int? FornecedorId { get; set; }
}