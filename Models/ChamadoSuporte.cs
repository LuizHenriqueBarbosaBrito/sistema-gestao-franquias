namespace Franquias.Api.Models;

public enum PrioridadeChamado
{
    Baixa,
    Media,
    Alta
}

public enum StatusChamado
{
    Aberto,
    EmAndamento,
    Encerrado
}

public class ChamadoSuporte
{
    public int Id {get; set;}

    public int UnidadeFranqueadaId {get; set;}
    public UnidadeFranqueada UnidadeFranqueada {get; set; } = null!;

    public int UsuarioId {get; set;}
    public Usuario Usuario {get; set;} = null!;

    public string Categoria {get; set;} = string.Empty;

    public PrioridadeChamado Prioridade {get; set;} 

    public string Descricao {get; set;} = string.Empty;

    public StatusChamado Status {get; set;} = StatusChamado.Aberto;

    public DateTime DataAbertura {get; set;} = DateTime.Now;

    public DateTime? DataEncerramento {get; set;}
}