using GerenciamentoDeOfertas.Application.Interfaces;
using GerenciamentoDeOfertas.Communication.Requests;
using GerenciamentoDeOfertas.Communication.Responses;

namespace GerenciamentoDeOfertas.Application.UseCase.Oferta
{
    public class RegistrarOfertaUseCase : IRegistrarOfertaUseCase
    {
        public ResponseRegistradoOfertaJson Execute(RequestRegistrarOfertaJson request)
        {
            var response = new ResponseRegistradoOfertaJson
            {
                Nome = request.Nome,
                Descricao = request.Descricao,
                Preco = request.Preco
            };

            return response;
        }
    }
}
