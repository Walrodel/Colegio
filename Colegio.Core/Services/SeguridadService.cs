using Colegio.Core.Entities;
using Colegio.Core.Interfaces;
using System.Threading.Tasks;

namespace Colegio.Core.Services
{
    public class SeguridadService : ISeguridadService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SeguridadService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Seguridad> GetLoginbyCredentials(UserLogin login)
        {
            return await _unitOfWork.SeguridadRepository.GetLoginbyCredentials(login);
        }

        public async Task RegisterUser(Seguridad seguridad)
        {
            await _unitOfWork.SeguridadRepository.Add(seguridad);
            await _unitOfWork.SaveChangesAsyn();
        }

    }
}
