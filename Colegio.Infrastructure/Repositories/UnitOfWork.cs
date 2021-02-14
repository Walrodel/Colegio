using Colegio.Core.Entities;
using Colegio.Core.Interfaces;
using Colegio.Infrastructure.Data;
using System.Threading.Tasks;

namespace Colegio.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ColegioContext _context;
        private readonly IRepository<Ingreso> _ingresoRepositoty;
        private readonly ISeguridadRepository _seguridadRepositoty;

        public UnitOfWork(ColegioContext context)
        {
            _context = context;
        }

        public IRepository<Ingreso> IngresoRepository => _ingresoRepositoty ?? new BaseRepository<Ingreso>(_context);

        public ISeguridadRepository SeguridadRepository => _seguridadRepositoty ?? new SeguridadRepository(_context);

        public void Dispose()
        {
            if(_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsyn()
        {
            await _context.SaveChangesAsync();
        }

    }
}
