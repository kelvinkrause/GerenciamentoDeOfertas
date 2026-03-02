using GerenciamentoDeOfertas.Application.Interfaces;
using GerenciamentoDeOfertas.Application.UseCase.Oferta.Registrar;
using GerenciamentoDeOfertas.Application.Validator;
using Microsoft.Extensions.DependencyInjection;
using GerenciamentoDeOfertas.Application.Services.AutoMapper;
using FluentValidation;

namespace GerenciamentoDeOfertas.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddUseCases(services);
            AddAutoMapper(services);
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

        private static void AddAutoMapper(IServiceCollection services)
        {
            services.AddScoped(option => new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());
            }).CreateMapper());
        }
    }
}
