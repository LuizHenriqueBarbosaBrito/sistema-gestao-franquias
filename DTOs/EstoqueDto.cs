namespace Franquias.Api.DTOs;

public class EstoqueDto
{
    public int Id { get; set; }
    public int UnidadeFranqueadaId { get; set; }
    public int ProdutoServicoId { get; set; }
    public int SaldoAtual { get; set; }
    public int EstoqueMinimo { get; set; }
}

public class EstoqueCreateDto
{
    public int UnidadeFranqueadaId { get; set; }
    public int ProdutoServicoId { get; set; }
    public int EstoqueMinimo { get; set; }
}

public class MovimentacaoEstoqueDto
{
    public int EstoqueId { get; set; }
    public string Tipo { get; set; } = string.Empty; // "Entrada" ou "Saida"
    public int Quantidade { get; set; }
    public string? Motivo { get; set; }
}