using Colegio.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colegio.Core.Interfaces
{
    public interface IIngresoService
    {
        IEnumerable<Ingreso> GetIngresos();
        Task<Ingreso> GetIngreso(int Id);
        Task InsertIngreso(Ingreso ingreso);
        Task<bool> UpdateIngreso(Ingreso ingreso);
        Task<bool> DeleteIngreso(int Id);
    }
}