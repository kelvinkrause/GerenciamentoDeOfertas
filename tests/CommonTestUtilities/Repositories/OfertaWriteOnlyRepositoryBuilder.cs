using GerenciamentoDeOfertas.Domain.Repositories.Oferta;
using Moq;

namespace CommonTestUtilities.Repositories
{
    public static class OfertaWriteOnlyRepositoryBuilder
    {
        public static IOfertaWriteOnlyRepository Build()
        {
            var mock = new Mock<IOfertaWriteOnlyRepository>();

            return mock.Object;

        }
    }
}
