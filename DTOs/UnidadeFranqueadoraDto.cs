namespace Franquias.Api.DTOs;

public class UnidadeFranqueadaDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;
    public string? Cidade { get; set; }
    public string? Endereco { get; set; }
    public DateTime DataInicio { get; set; }
    public bool Ativo { get; set; }
    public int FranqueadoraId { get; set; }
}

public class UnidadeFranqueadaCreateDto
{
    public string Nome { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;
    public string? Cidade { get; set; }
    public string? Endereco { get; set; }
    public DateTime DataInicio { get; set; }
    public int FranqueadoraId { get; set; }
}