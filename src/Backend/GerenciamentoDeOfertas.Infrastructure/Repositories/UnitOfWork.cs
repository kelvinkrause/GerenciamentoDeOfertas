using GerenciamentoDeOfertas.Domain.Repositories;
using GerenciamentoDeOfertas.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
