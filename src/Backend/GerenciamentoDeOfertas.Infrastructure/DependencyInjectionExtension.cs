using GerenciamentoDeOfertas.Domain.Repositories;
using GerenciamentoDeOfertas.Domain.Repositories.Oferta;
using GerenciamentoDeOfertas.Infrastructure.DataAccess;
using GerenciamentoDeOfertas.Infrastructure.Extension;
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
            AddRepositories(services);
            
            if (configuration.AmbienteDeTesteUnitario())
                return;

            AddGerenciamentoDeOfertasDbContext(services, configuration);
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
