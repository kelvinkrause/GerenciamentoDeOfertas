namespace GerenciamentoDeOfertas.Communication.Responses
{
    public class ResponseRegistradoOfertaJson
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataRegistro { get; set; }
    }
}
