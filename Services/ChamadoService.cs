using Franquias.Api.DTOs;
using Franquias.Api.Models;
using Franquias.Api.Repositories;

namespace Franquias.Api.Services;

public class ChamadoService : IChamadoService
{
    private readonly IChamadoRepository _repository;

    public ChamadoService(IChamadoRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ChamadoDto>> GetAllAsync()
    {
        var chamados = await _repository.GetAllAsync();
        return chamados.Select(ParaDto).ToList();
    }

    public async Task<ChamadoDto?> GetByIdAsync(int id)
    {
        var chamado = await _repository.GetByIdAsync(id);
        return chamado is null ? null : ParaDto(chamado);
    }

    public async Task<List<ChamadoDto>> GetAbertosAsync()
    {
        var chamados = await _repository.GetAbertosAsync();
        return chamados.Select(ParaDto).ToList();
    }

    public async Task<(bool Sucesso, string? Erro, ChamadoDto? Dto)> CreateAsync(ChamadoCreateDto dto)
    {
        if (!Enum.TryParse<PrioridadeChamado>(dto.Prioridade, true, out var prioridade))
        {
            return (false, "Prioridade inválida. Use 'Baixa', 'Media' ou 'Alta'.", null);
        }

        var chamado = new ChamadoSuporte
        {
            UnidadeFranqueadaId = dto.UnidadeFranqueadaId,
            UsuarioId = dto.UsuarioId,
            Categoria = dto.Categoria,
            Prioridade = prioridade,
            Descricao = dto.Descricao,
            Status = StatusChamado.Aberto,
            DataAbertura = DateTime.Now
        };

        await _repository.AddAsync(chamado);
        await _repository.SaveChangesAsync();

        return (true, null, ParaDto(chamado));
    }

    public async Task<(bool Sucesso, string? Erro)> EncerrarAsync(int id)
    {
        var chamado = await _repository.GetByIdAsync(id);
        if (chamado is null) return (false, "Chamado não encontrado.");

        chamado.Status = StatusChamado.Encerrado;
        chamado.DataEncerramento = DateTime.Now;

        _repository.Update(chamado);
        await _repository.SaveChangesAsync();

        return (true, null);
    }

    private static ChamadoDto ParaDto(ChamadoSuporte c) => new()
    {
        Id = c.Id,
        UnidadeFranqueadaId = c.UnidadeFranqueadaId,
        UsuarioId = c.UsuarioId,
        Categoria = c.Categoria,
        Prioridade = c.Prioridade.ToString(),
        Descricao = c.Descricao,
        Status = c.Status.ToString(),
        DataAbertura = c.DataAbertura,
        DataEncerramento = c.DataEncerramento
    };
}