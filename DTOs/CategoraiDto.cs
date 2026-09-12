namespace Franquias.Api.DTOs;

public class CategoriaDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
}

public class CategoriaCreateDto
{
    public string Nome { get; set; } = string.Empty;
}