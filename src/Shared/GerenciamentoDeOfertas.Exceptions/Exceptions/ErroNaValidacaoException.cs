using System.Net;

namespace GerenciamentoDeOfertas.Exceptions.Exceptions
{
    public class ErroNaValidacaoException : GerenciamentoDeOfertasException
    {
        private readonly IList<string> _errosMessage;
        public ErroNaValidacaoException(IList<string> errosMessage) => _errosMessage = errosMessage;
        public IList<string> ErroMessages => _errosMessage;
        public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
    }
}
