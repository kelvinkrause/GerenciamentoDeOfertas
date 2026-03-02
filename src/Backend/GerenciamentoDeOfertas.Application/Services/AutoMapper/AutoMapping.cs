using AutoMapper;
using GerenciamentoDeOfertas.Communication.Requests;
using GerenciamentoDeOfertas.Domain.Entities;

namespace GerenciamentoDeOfertas.Application.Services.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            RequestToDoamin();
        }
        private void RequestToDoamin()
        {
            CreateMap<RequestRegistrarOfertaJson, Oferta>();
        }
    }
}
