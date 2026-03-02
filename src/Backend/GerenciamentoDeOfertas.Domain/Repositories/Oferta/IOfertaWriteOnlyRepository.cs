namespace GerenciamentoDeOfertas.Domain.Repositories.Oferta
{
    public interface IOfertaWriteOnlyRepository
    {
        Task AddAsync(Domain.Entities.Oferta oferta);
    }
}
