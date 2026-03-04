using AutoMapper;
using FluentValidation;
using GerenciamentoDeOfertas.Application.Interfaces;
using GerenciamentoDeOfertas.Communication.Requests;
using GerenciamentoDeOfertas.Communication.Responses;
using GerenciamentoDeOfertas.Domain.Repositories;
using GerenciamentoDeOfertas.Domain.Repositories.Oferta;
using GerenciamentoDeOfertas.Exceptions.Exceptions;

namespace GerenciamentoDeOfertas.Application.UseCase.Oferta.Registrar
{
    public class RegistrarOfertaUseCase : IRegistrarOfertaUseCase
    {
        private readonly IOfertaWriteOnlyRepository _ofertaWriteOnlyRepository;
        private readonly IValidator<RequestRegistrarOfertaJson> _validator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RegistrarOfertaUseCase(
            IOfertaWriteOnlyRepository ofertaWriteOnlyRepository,
            IValidator<RequestRegistrarOfertaJson> validator,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _ofertaWriteOnlyRepository = ofertaWriteOnlyRepository;
            _validator = validator;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResponseRegistradoOfertaJson> Execute(RequestRegistrarOfertaJson request)
        {

            Validate(request);

            var oferta = _mapper.Map<Domain.Entities.Oferta>(request);

            await _ofertaWriteOnlyRepository.AddAsync(oferta);

            await _unitOfWork.CommitAsync();

            var response = new ResponseRegistradoOfertaJson
            {
                Id = oferta.Id,
                Nome = oferta.Nome,
                Descricao = oferta.Descricao,
                Valor = oferta.Valor,
                DataRegistro = oferta.DataRegistro

            };

            return response;
        }

        private void Validate(RequestRegistrarOfertaJson request)
        {
            var result = _validator.Validate(request);

            if (!result.IsValid)
            {
                var erros = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErroNaValidacaoException(erros);
            }
        }
    }
}
