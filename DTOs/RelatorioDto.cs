namespace Franquias.Api.DTOs;

public class FaturamentoUnidadeDto
{
    public int UnidadeFranqueadaId { get; set; }
    public string NomeUnidade { get; set; } = string.Empty;
    public decimal Faturamento { get; set; }
}

public class ProdutoMaisVendidoDto
{
    public int ProdutoServicoId { get; set; }
    public string NomeProduto { get; set; } = string.Empty;
    public int QuantidadeVendida { get; set; }
}

public class EstoqueCriticoDto
{
    public int EstoqueId { get; set; }
    public string NomeProduto { get; set; } = string.Empty;
    public string NomeUnidade { get; set; } = string.Empty;
    public int SaldoAtual { get; set; }
    public int EstoqueMinimo { get; set; }
}

public class ChamadosPorStatusDto
{
    public string Status { get; set; } = string.Empty;
    public int Quantidade { get; set; }
}