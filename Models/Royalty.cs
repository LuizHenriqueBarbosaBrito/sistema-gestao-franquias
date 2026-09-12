using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Franquias.Api.Models;

public enum StatusPagamento
{
    Pendente,
    Pago,
    Atrasado
}

public class Royalty
{
    public int Id {get; set;}

    public int UnidadeFranqueadaId {get; set;}
    public UnidadeFranqueada UnidadeFranqueada {get; set;} = null!;

    //formato de data: AAAA-MM.
    public string Periodo {get; set;} = string.Empty;

    [Column(TypeName = "decimal(5,2)")]
    public decimal PercentualAplicado {get; set;}

    [Column(TypeName = "decimal(10,2)")]
    public decimal Faturamento {get; set;}

    [Column(TypeName = "decimal(10,2)")]
    public decimal ValorRoyalty {get; set;}
    public StatusPagamento Status {get; set;} = StatusPagamento.Pendente;

    public DateTime? DataPagamento {get; set;}  
}