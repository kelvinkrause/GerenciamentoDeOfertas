using GerenciamentoDeOfertas.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeOfertas.Infrastructure.DataAccess
{
    public class GerenciamentoDeOfertasDbContext : DbContext
    {
        public GerenciamentoDeOfertasDbContext(DbContextOptions<GerenciamentoDeOfertasDbContext> options) : base(options) { }
        public DbSet<Oferta> Ofertas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GerenciamentoDeOfertasDbContext).Assembly);
        }
    }
}
