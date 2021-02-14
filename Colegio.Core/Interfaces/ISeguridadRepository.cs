using Colegio.Core.Entities;
using System.Threading.Tasks;

namespace Colegio.Core.Interfaces
{
    public interface ISeguridadRepository : IRepository<Seguridad>
    {
        Task<Seguridad> GetLoginbyCredentials(UserLogin login);
    }
}