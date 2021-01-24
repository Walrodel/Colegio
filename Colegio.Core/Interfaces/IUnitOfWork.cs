using Colegio.Core.Entities;
using System;
using System.Threading.Tasks;

namespace Colegio.Core.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<Ingreso> IngresoRepository { get;  }

        void SaveChanges();
        Task SaveChangesAsyn();
    }
}
