namespace Franquias.Api.DTOs;

// o que Api devolve para o cliente quando ele requisita uma franqueadora
public class FranqueadoraDto
{
    public int Id {get; set;}
    public string RazaoSocial {get; set;} = string.Empty;
    public string Cnpj {get; set;} = string.Empty;
}

// o que Api recebe do cliente quando ele envia uma franqueadora
public class FranqueadoraCreateDto
{
    public string RazaoSocial {get; set;} = string.Empty;
    public string Cnpj {get; set;} = string.Empty;
}

