namespace GerenciamentoDeOfertas.Communication.Requests
{
    public class RequestAtualizarOfertaJson
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataRegistro { get; set; }
    }
}
