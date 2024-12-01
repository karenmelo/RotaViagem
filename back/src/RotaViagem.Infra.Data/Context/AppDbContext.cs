using Microsoft.EntityFrameworkCore;
using RotaViagem.Domain.Entities;

namespace RotaViagem.Infra.Data.Context;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Rota> Rotas { get; set; }
}
