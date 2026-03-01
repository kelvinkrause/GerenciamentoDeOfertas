using AutoMapper;
using FluentValidation;
using GerenciamentoDeOfertas.Application.Interfaces;
using GerenciamentoDeOfertas.Communication.Requests;
using GerenciamentoDeOfertas.Communication.Responses;
using GerenciamentoDeOfertas.Domain.Entities;

namespace GerenciamentoDeOfertas.Application.UseCase.Oferta.Registrar
{
    public class RegistrarOfertaUseCase : IRegistrarOfertaUseCase
    {
        private readonly IValidator<RequestRegistrarOfertaJson> _validator;
        private readonly IMapper _mapper;
        public RegistrarOfertaUseCase(
            IValidator<RequestRegistrarOfertaJson> validator,
            IMapper mapper)
        {
            _validator = validator;
            _mapper = mapper;
        }
        public ResponseRegistradoOfertaJson Execute(RequestRegistrarOfertaJson request)
        {

            Validate(request);

            var oferta = _mapper.Map<Domain.Entities.Oferta>(request);

            var response = new ResponseRegistradoOfertaJson
            {
                Nome = oferta.Nome,
                Descricao = oferta.Descricao,
                Valor = oferta.Valor
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
