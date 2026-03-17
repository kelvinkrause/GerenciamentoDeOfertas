using AutoMapper;
using GerenciamentoDeOfertas.Application.Services.AutoMapper;
using Microsoft.Extensions.Logging;

namespace CommonTestUtilities.Mapper
{
    public static class MapperBuilder
    {
        public static IMapper Build()
        {
            var loggerFactory = LoggerFactory.Create(builder => { });

            var configuration = new MapperConfiguration(options =>
            {
                options.AddProfile(new AutoMapping());
            }, loggerFactory);

            return configuration.CreateMapper();}
    }
}
