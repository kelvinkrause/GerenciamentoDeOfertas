using GerenciamentoDeOfertas.Domain.Entities;
using GerenciamentoDeOfertas.Domain.Repositories.Oferta;
using GerenciamentoDeOfertas.Infrastructure.DataAccess;

namespace GerenciamentoDeOfertas.Infrastructure.Repositories
{
    public class OfertaRepository : IOfertaWriteOnlyRepository, IOfertaReadOnlyRepository
    {
        private readonly GerenciamentoDeOfertasDbContext _context;
        public OfertaRepository(GerenciamentoDeOfertasDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Oferta oferta) => await _context.Ofertas.AddAsync(oferta);

        public Task<IEnumerable<Oferta>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Oferta> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
