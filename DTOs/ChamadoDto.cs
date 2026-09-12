namespace Franquias.Api.DTOs;

public class ChamadoDto
{
    public int Id { get; set; }
    public int UnidadeFranqueadaId { get; set; }
    public int UsuarioId { get; set; }
    public string Categoria { get; set; } = string.Empty;
    public string Prioridade { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime DataAbertura { get; set; }
    public DateTime? DataEncerramento { get; set; }
}

public class ChamadoCreateDto
{
    public int UnidadeFranqueadaId { get; set; }
    public int UsuarioId { get; set; }
    public string Categoria { get; set; } = string.Empty;
    public string Prioridade { get; set; } = string.Empty; // "Baixa", "Media", "Alta"
    public string Descricao { get; set; } = string.Empty;
}