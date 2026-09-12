namespace Franquias.Api.Models;
public enum TipoMovimentacao
{
    Entrada,
    Saida
}

public class MovimentacaoEstoque
{
    public int Id {get; set;}

    public int EstoqueId {get; set;}
    public Estoque Estoque {get; set;} = null!;

    public TipoMovimentacao Tipo {get; set;}

    public int Quantidade {get; set;}
    public DateTime Data {get; set;} = DateTime.Now;

    public string? Motivo {get; set;} = string.Empty;
}