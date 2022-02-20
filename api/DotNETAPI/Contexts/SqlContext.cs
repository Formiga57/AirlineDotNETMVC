using Microsoft.EntityFrameworkCore;
using DotNETAPI.Models.DbModels;

namespace DotNETAPI.Contexts;

public class SqlContext : DbContext
{
    public SqlContext(DbContextOptions<SqlContext> options) : base(options)
    {
        
    }

    public DbSet<Usuário> Usuários { get; set; }
    public DbSet<UsuárioVoo> UsuáriosVoos { get; set; }
    public DbSet<Voo> Voos { get; set; }
    public DbSet<Aeroporto> Aeroportos { get; set; }
    public DbSet<Cidade> Cidades { get; set; }
    public DbSet<AeroportoCidade> AeroportosCidades { get; set; }
    public DbSet<Avião> Aviões { get; set; }
    public DbSet<Assento> Assentos { get; set; }
}