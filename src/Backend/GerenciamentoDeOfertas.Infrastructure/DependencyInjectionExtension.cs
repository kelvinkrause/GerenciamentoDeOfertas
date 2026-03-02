using GerenciamentoDeOfertas.Domain.Repositories;
using GerenciamentoDeOfertas.Domain.Repositories.Oferta;
using GerenciamentoDeOfertas.Infrastructure.DataAccess;
using GerenciamentoDeOfertas.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GerenciamentoDeOfertas.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            AddGerenciamentoDeOfertasDbContext(services, configuration);
            AddRepositories(services);
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IOfertaWriteOnlyRepository, OfertaRepository>();
            services.AddScoped<IOfertaReadOnlyRepository, OfertaRepository>();
        }

        private static void AddGerenciamentoDeOfertasDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GerenciamentoDeOfertasDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ConnectionSqlServer"));
            });
        }
    }
}
