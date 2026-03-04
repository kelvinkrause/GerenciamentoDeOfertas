using CommonTestUtilities.Mapper;
using CommonTestUtilities.Repositories;
using CommonTestUtilities.Requests;
using FluentAssertions;
using GerenciamentoDeOfertas.Application.UseCase.Oferta.Registrar;
using GerenciamentoDeOfertas.Application.Validator;

namespace UseCases.Test.Oferta.Registrar
{
    public class RegistrarOfertaUseCaseTest
    {
        [Fact]
        public async Task Registrar_Oferta_UseCase_Success()
        {
            var request = RequestRegistrarOfertaJsonBuilder.Build();

            var useCase = CreateUseCase();
            
            var result = await useCase.Execute(request);

            result.Should().NotBeNull();
            result.Nome.Should().Be(request.Nome);
        }

        private RegistrarOfertaUseCase CreateUseCase()
        {
            var ofertaWriteOnlyRepositoryBuilder = OfertaWriteOnlyRepositoryBuilder.Build();
            var validate = new RegistrarOfertaValidator();
            var unitOfWork = UnitOfWorkBuilder.Build();
            var mapper = MapperBuilder.Build();

            return new RegistrarOfertaUseCase(
                ofertaWriteOnlyRepositoryBuilder,
                validate,
                unitOfWork,
                mapper
            );
        }
    }
}
