using GerenciamentoDeOfertas.Communication.Requests;

namespace CommonTestUtilities.Requests
{
    public static class RequestRegistrarOfertaJsonBuilder
    {
        public static RequestRegistrarOfertaJson Build()
        {
            return new RequestRegistrarOfertaJson
            {
                Nome = "Oferta Teste",
                Descricao = "Descrição da oferta teste",
                Preco = 100.00m
            };
        }
    }
}
