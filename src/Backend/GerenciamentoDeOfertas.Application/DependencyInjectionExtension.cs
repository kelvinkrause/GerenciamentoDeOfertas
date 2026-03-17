using AutoMapper;
using FluentValidation;
using GerenciamentoDeOfertas.Application.Interfaces;
using GerenciamentoDeOfertas.Application.Services.AutoMapper;
using GerenciamentoDeOfertas.Application.UseCase.Oferta.Registrar;
using GerenciamentoDeOfertas.Application.Validator;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

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

        private static void AddValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<RegistrarOfertaValidator>();
        }

        private static void AddAutoMapper(this IServiceCollection services)
        {
            //services.AddScoped(option => new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile(new AutoMapping());
            //}).CreateMapper());

            // Versão AutoMapper: 16.1.1. 
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile(new AutoMapping());
            });
        }
    }
}
