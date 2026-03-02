using GerenciamentoDeOfertas.Communication.Requests;
using GerenciamentoDeOfertas.Communication.Responses;

namespace GerenciamentoDeOfertas.Application.Interfaces
{
    public interface IRegistrarOfertaUseCase
    {
        Task<ResponseRegistradoOfertaJson> Execute(RequestRegistrarOfertaJson request);
    }
}
