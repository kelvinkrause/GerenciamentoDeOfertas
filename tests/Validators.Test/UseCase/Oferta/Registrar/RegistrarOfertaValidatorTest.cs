using CommonTestUtilities.Requests;
using FluentAssertions;
using GerenciamentoDeOfertas.Application.Validator;

namespace Validators.Test.UseCase.Oferta.Registrar
{
    public class RegistrarOfertaValidatorTest
    {

        [Fact]
        public void Success()
        {
            var request = RequestRegistrarOfertaJsonBuilder.Build();

            var validator = new RegistrarOfertaValidator();

            var result = validator.Validate(request);

            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeEmpty();

        }
    }
}
