namespace Franquias.Api.DTOs;

public class ItemVendaCreateDto
{
    public int ProdutoServicoId { get; set; }
    public int Quantidade { get; set; }
}

public class VendaCreateDto
{
    public int UnidadeFranqueadaId { get; set; }
    public int UsuarioId { get; set; }
    public List<ItemVendaCreateDto> Itens { get; set; } = new();
}

public class ItemVendaDto
{
    public int ProdutoServicoId { get; set; }
    public int Quantidade { get; set; }
    public decimal PrecoUnitario { get; set; }
    public decimal Subtotal { get; set; }
}

public class VendaDto
{
    public int Id { get; set; }
    public int UnidadeFranqueadaId { get; set; }
    public int UsuarioId { get; set; }
    public DateTime DataVenda { get; set; }
    public decimal ValorTotal { get; set; }
    public List<ItemVendaDto> Itens { get; set; } = new();
}