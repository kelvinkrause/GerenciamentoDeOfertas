using GerenciamentoDeOfertas.Application.Interfaces;
using GerenciamentoDeOfertas.Application.UseCase.Oferta;
using Microsoft.Extensions.DependencyInjection;

namespace GerenciamentoDeOfertas.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddUseCases(services);
        }

        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<IRegistrarOfertaUseCase, RegistrarOfertaUseCase>();
        }
    }
}
