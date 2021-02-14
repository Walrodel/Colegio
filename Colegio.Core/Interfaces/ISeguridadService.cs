using Colegio.Core.Entities;
using System.Threading.Tasks;

namespace Colegio.Core.Interfaces
{
    public interface ISeguridadService
    {
        Task<Seguridad> GetLoginbyCredentials(UserLogin login);
        Task RegisterUser(Seguridad seguridad);
    }
}