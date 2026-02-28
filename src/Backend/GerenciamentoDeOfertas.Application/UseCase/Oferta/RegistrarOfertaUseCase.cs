using FluentValidation;
using GerenciamentoDeOfertas.Application.Interfaces;
using GerenciamentoDeOfertas.Communication.Requests;
using GerenciamentoDeOfertas.Communication.Responses;

namespace GerenciamentoDeOfertas.Application.UseCase.Oferta
{
    public class RegistrarOfertaUseCase : IRegistrarOfertaUseCase
    {
        private readonly IValidator<RequestRegistrarOfertaJson> _validator;
        public RegistrarOfertaUseCase(
            IValidator<RequestRegistrarOfertaJson> validator)
        {
            _validator = validator;
        }
        public ResponseRegistradoOfertaJson Execute(RequestRegistrarOfertaJson request)
        {

            Validate(request);

            var response = new ResponseRegistradoOfertaJson
            {
                Nome = request.Nome,
                Descricao = request.Descricao,
                Preco = request.Preco
            };

            return response;
        }

        private void Validate(RequestRegistrarOfertaJson request)
        {
            var result = _validator.Validate(request);

            if (!result.IsValid)
            {
                var erros = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ValidationException(result.Errors);
            }
        }
    }
}
