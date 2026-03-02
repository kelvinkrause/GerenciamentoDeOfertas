namespace GerenciamentoDeOfertas.Domain.Repositories.Oferta
{
    public interface IOfertaReadOnlyRepository
    {
        Task<Entities.Oferta> GetByIdAsync(int id);
        Task<IEnumerable<Entities.Oferta>> GetAll();
    }
}
