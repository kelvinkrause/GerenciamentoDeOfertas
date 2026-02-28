using CommonTestUtilities.Requests;
using FluentAssertions;
using GerenciamentoDeOfertas.Application.Validator;
using System.ComponentModel.DataAnnotations;

namespace Validators.Test.UseCase.Oferta.Registrar
{
    public class RegistrarOfertaValidatorTest
    {
        private readonly RegistrarOfertaValidator _validator;
        public RegistrarOfertaValidatorTest()
        {
            _validator = new RegistrarOfertaValidator();
        }

        [Fact]
        public void Sucesso()
        {
            var request = RequestRegistrarOfertaJsonBuilder.Build();

            var result = _validator.Validate(request);

            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeEmpty();

        }

        [Fact]
        public void Erro_Nome_Vazio()
        {
            var request = RequestRegistrarOfertaJsonBuilder.Build();

            request.Nome = string.Empty;

            var result = _validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle()
                .And.Contain(e => e.ErrorMessage.Equals("Nome não pode ser vazio."));
        }

        [Fact]
        public void Erro_Nome_Maior_Que_100_Caracteres()
        {
            var request = RequestRegistrarOfertaJsonBuilder.Build();

            request.Nome = new string('K', 101);

            var result = _validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle()
                .And.Contain(e => e.ErrorMessage.Equals("Nome não pode conter mais de 100 caracteres."));
        }

        [Fact]
        public void Erro_Descricao_Vazia()
        {
            var request = RequestRegistrarOfertaJsonBuilder.Build();

            request.Descricao = string.Empty;

            var result = _validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle()
                .And.Contain(e => e.ErrorMessage.Equals("Descrição não pode ser vazia."));
        }

        [Fact]
        public void Erro_Descricao_Maior_Que_500_Caracteres()
        {
            var request = RequestRegistrarOfertaJsonBuilder.Build();

            request.Descricao = new string('K', 501);

            var result = _validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle()
                .And.Contain(e => e.ErrorMessage.Equals("Descrição não pode conter mais de 500 caracteres."));
        }

        [Fact]
        public void Erro_Valor_Menor_Que_Zero()
        {
            var request = RequestRegistrarOfertaJsonBuilder.Build();

            request.Valor = -1.00m;

            var result = _validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle()
                .And.Contain(e => e.ErrorMessage.Equals("Preço deve ser maior que zero."));

        }
    }
}