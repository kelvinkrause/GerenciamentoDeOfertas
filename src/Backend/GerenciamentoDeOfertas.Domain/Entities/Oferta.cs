namespace GerenciamentoDeOfertas.Domain.Entities
{
    public class Oferta
    {
        public int Id { get; set; }
        public string? Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public DateTime DataRegistro { get; set; } = DateTime.UtcNow;
    }
}
