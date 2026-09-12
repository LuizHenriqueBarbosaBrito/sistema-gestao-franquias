using Franquias.Api.DTOs;

namespace Franquias.Api.Repositories;

public interface IRelatorioRepository
{
    Task<List<FaturamentoUnidadeDto>> GetFaturamentoPorUnidadeAsync();
    Task<List<ProdutoMaisVendidoDto>> GetProdutosMaisVendidosAsync();
    Task<List<EstoqueCriticoDto>> GetEstoqueCriticoAsync();
    Task<List<ChamadosPorStatusDto>> GetChamadosPorStatusAsync();
}