using GerenciamentoDeOfertas.Application.Interfaces;
using GerenciamentoDeOfertas.Application.UseCase.Oferta;
using GerenciamentoDeOfertas.Application.Validator;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

namespace GerenciamentoDeOfertas.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddUseCases(services);
            AddValidators(services);
        }

        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<IRegistrarOfertaUseCase, RegistrarOfertaUseCase>();
        }

        private static void AddValidators(IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<RegistrarOfertaValidator>();
        }
    }
}
