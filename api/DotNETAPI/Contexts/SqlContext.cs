using Microsoft.EntityFrameworkCore;
using DotNETAPI.Models.DbModels;

namespace DotNETAPI.Contexts;

public class SqlContext : DbContext
{
    public SqlContext(DbContextOptions<SqlContext> options) : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Assento>()
            .Property(b => b.Reservado)
            .HasDefaultValue(false);
        modelBuilder.Entity<Usuário>()
            .Property(b => b.Administrador)
            .HasDefaultValue(false);
        modelBuilder.Entity<Cidade>().HasData(new Cidade[] {
            new Cidade {Id = 1,Nome = "São Paulo",UF="SP"},
            new Cidade {Id = 2,Nome = "Belo Horizonte",UF="BH"},
            new Cidade {Id = 3,Nome = "Rio de Janeiro",UF="RJ"},
            new Cidade {Id = 4,Nome = "Navegantes",UF="SC"},
            new Cidade {Id = 5,Nome = "Foz do Iguaçu",UF="PR"},
            new Cidade {Id = 6,Nome = "Fortaleza",UF="CE"}
        });
        modelBuilder.Entity<Aeroporto>().HasData(new Aeroporto[] {
            new Aeroporto {Id = 1,Nome = "Guarulhos",Cód = "GRU"},
            new Aeroporto {Id = 2,Nome = "Congonhas",Cód = "CGH"},
            new Aeroporto {Id = 3,Nome = "Santos Dumont",Cód = "SDU"},
            new Aeroporto {Id = 4,Nome = "Confins",Cód = "CNF"},
            new Aeroporto {Id = 5,Nome = "Navegantes",Cód = "NVT"},
            new Aeroporto {Id = 6,Nome = "Foz do Iguaçu",Cód = "IGR"},
            new Aeroporto {Id = 7,Nome = "Fortaleza",Cód = "FOR"}
        });
        modelBuilder.Entity<AeroportoCidade>().HasData(new AeroportoCidade[] {
            new AeroportoCidade{Id=1,CidadeFk = 1,AeroportoFk = 1},
            new AeroportoCidade{Id=2,CidadeFk = 1,AeroportoFk = 2},
            new AeroportoCidade{Id=3,CidadeFk = 2,AeroportoFk = 4},
            new AeroportoCidade{Id=4,CidadeFk = 3,AeroportoFk = 3},
            new AeroportoCidade{Id=5,CidadeFk = 4,AeroportoFk = 5},
            new AeroportoCidade{Id=6,CidadeFk = 5,AeroportoFk = 6},
            new AeroportoCidade{Id=7,CidadeFk = 6,AeroportoFk = 7},
        });
    }
    public DbSet<Usuário> Usuários { get; set; }
    public DbSet<Voo> Voos { get; set; }
    public DbSet<Aeroporto> Aeroportos { get; set; }
    public DbSet<Cidade> Cidades { get; set; }
    public DbSet<AeroportoCidade> AeroportosCidades { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<Avião> Aviões { get; set; }
    public DbSet<Assento> Assentos { get; set; }
}
