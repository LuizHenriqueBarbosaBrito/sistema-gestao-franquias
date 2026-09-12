using Microsoft.EntityFrameworkCore;
using Franquias.Api.Models;

namespace Franquias.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Perfil> Perfis { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Franqueadora> Franqueadoras { get; set; }
    public DbSet<UnidadeFranqueada> UnidadesFranqueadas { get; set; }
    public DbSet<Responsavel> Responsaveis { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<ProdutoServico> ProdutosServicos { get; set; }
    public DbSet<Fornecedor> Fornecedores { get; set; }
    public DbSet<Estoque> Estoques { get; set; }
    public DbSet<MovimentacaoEstoque> MovimentacoesEstoque { get; set; }
    public DbSet<Venda> Vendas { get; set; }
    public DbSet<ItemVenda> ItensVenda { get; set; }
    public DbSet<Royalty> Royalties { get; set; }
    public DbSet<ChamadoSuporte> ChamadosSuporte { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Regra: não permitir duas unidades com o mesmo CNPJ
        modelBuilder.Entity<UnidadeFranqueada>()
            .HasIndex(u => u.Cnpj)
            .IsUnique();

        // Regra: não permitir usuários com e-mail duplicado
        modelBuilder.Entity<Usuario>()
            .HasIndex(u => u.Email)
            .IsUnique();

        // CNPJ da franqueadora e do fornecedor também únicos, por consistência
        modelBuilder.Entity<Franqueadora>()
            .HasIndex(f => f.Cnpj)
            .IsUnique();

        modelBuilder.Entity<Fornecedor>()
            .HasIndex(f => f.Cnpj)
            .IsUnique();

        // Uma unidade só pode ter um registro de estoque por produto
        modelBuilder.Entity<Estoque>()
            .HasIndex(e => new { e.UnidadeFranqueadaId, e.ProdutoServicoId })
            .IsUnique();
    }
}