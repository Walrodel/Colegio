using Colegio.Core.Entities;
using Colegio.Core.Interfaces;
using Colegio.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Colegio.Infrastructure.Repositories
{
    public class SeguridadRepository : BaseRepository<Seguridad>, ISeguridadRepository
    {
        public SeguridadRepository(ColegioContext context) : base(context) { }

        public async Task<Seguridad> GetLoginbyCredentials(UserLogin login)
        {
            return await _entities.FirstOrDefaultAsync(x => x.Usuario == login.User && x.Contrasena == login.Password);
        }
    }
}
