namespace GerenciamentoDeOfertas.Communication.Responses
{
    public class ResponseErroJson
    {
        public IList<string> ErrosMessage { get; set; }
        public ResponseErroJson(IList<string> errosMessage) => ErrosMessage = errosMessage;
        public ResponseErroJson(string erroMessage) => ErrosMessage = [ erroMessage ];
    }
}
