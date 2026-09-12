namespace Franquias.Api.DTOs;

public class RoyaltyDto
{
    public int Id { get; set; }
    public int UnidadeFranqueadaId { get; set; }
    public string Periodo { get; set; } = string.Empty;
    public decimal PercentualAplicado { get; set; }
    public decimal Faturamento { get; set; }
    public decimal ValorRoyalty { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime? DataPagamento { get; set; }
}

public class RoyaltyCalcularDto
{
    public int UnidadeFranqueadaId { get; set; }
    public string Periodo { get; set; } = string.Empty; // formato "AAAA-MM"
    public decimal PercentualAplicado { get; set; }
}

public class RoyaltyPagarDto
{
    public int RoyaltyId { get; set; }
}