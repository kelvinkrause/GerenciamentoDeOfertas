using GerenciamentoDeOfertas.Domain.Repositories;
using GerenciamentoDeOfertas.Infrastructure.DataAccess;

namespace GerenciamentoDeOfertas.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GerenciamentoDeOfertasDbContext _context;
        public UnitOfWork(GerenciamentoDeOfertasDbContext context)
        {
            _context = context;
        }
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
