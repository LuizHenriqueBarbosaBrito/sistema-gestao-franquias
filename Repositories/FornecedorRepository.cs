using Microsoft.EntityFrameworkCore;
using Franquias.Api.Data;
using Franquias.Api.Models;

namespace Franquias.Api.Repositories;

public class FornecedorRepository : IFornecedorRepository
{
    private readonly AppDbContext _context;

    public FornecedorRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Fornecedor>> GetAllAsync() =>
        await _context.Fornecedores.ToListAsync();

    public async Task<Fornecedor?> GetByIdAsync(int id) =>
        await _context.Fornecedores.FindAsync(id);

    public async Task<bool> CnpjExisteAsync(string cnpj) =>
        await _context.Fornecedores.AnyAsync(f => f.Cnpj == cnpj);

    public async Task AddAsync(Fornecedor fornecedor) =>
        await _context.Fornecedores.AddAsync(fornecedor);

    public void Update(Fornecedor fornecedor) =>
        _context.Fornecedores.Update(fornecedor);

    public async Task<bool> SaveChangesAsync() =>
        await _context.SaveChangesAsync() > 0;
}