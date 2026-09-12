using Franquias.Api.DTOs;
using Franquias.Api.Models;
using Franquias.Api.Repositories;

namespace Franquias.Api.Services;

public class RoyaltyService : IRoyaltyService
{
    private readonly IRoyaltyRepository _repository;

    public RoyaltyService(IRoyaltyRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<RoyaltyDto>> GetAllAsync()
    {
        var royalties = await _repository.GetAllAsync();
        return royalties.Select(ParaDto).ToList();
    }

    public async Task<RoyaltyDto?> GetByIdAsync(int id)
    {
        var royalty = await _repository.GetByIdAsync(id);
        return royalty is null ? null : ParaDto(royalty);
    }

    public async Task<RoyaltyDto> CalcularAsync(RoyaltyCalcularDto dto)
    {
        var faturamento = await _repository.GetFaturamentoDoPeriodoAsync(dto.UnidadeFranqueadaId, dto.Periodo);
        var valorRoyalty = faturamento * (dto.PercentualAplicado / 100);

        var royalty = new Royalty
        {
            UnidadeFranqueadaId = dto.UnidadeFranqueadaId,
            Periodo = dto.Periodo,
            PercentualAplicado = dto.PercentualAplicado,
            Faturamento = faturamento,
            ValorRoyalty = valorRoyalty,
            Status = StatusPagamento.Pendente
        };

        await _repository.AddAsync(royalty);
        await _repository.SaveChangesAsync();

        return ParaDto(royalty);
    }

    public async Task<(bool Sucesso, string? Erro)> MarcarComoPagoAsync(int royaltyId)
    {
        var royalty = await _repository.GetByIdAsync(royaltyId);
        if (royalty is null) return (false, "Royalty não encontrado.");

        royalty.Status = StatusPagamento.Pago;
        royalty.DataPagamento = DateTime.Now;

        _repository.Update(royalty);
        await _repository.SaveChangesAsync();

        return (true, null);
    }

    private static RoyaltyDto ParaDto(Royalty r) => new()
    {
        Id = r.Id,
        UnidadeFranqueadaId = r.UnidadeFranqueadaId,
        Periodo = r.Periodo,
        PercentualAplicado = r.PercentualAplicado,
        Faturamento = r.Faturamento,
        ValorRoyalty = r.ValorRoyalty,
        Status = r.Status.ToString(),
        DataPagamento = r.DataPagamento
    };
}