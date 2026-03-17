using Microsoft.Extensions.Configuration;

namespace GerenciamentoDeOfertas.Infrastructure.Extension
{
    public static class ConfigurationExtension
    {
        public static bool AmbienteDeTesteUnitario(this IConfiguration configuration)
        {
            return configuration.GetValue<bool>("InMemoryTest");
        }
    }
}
