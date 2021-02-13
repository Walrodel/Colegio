using Colegio.Core.CustomEntities;
using Colegio.Core.Entities;
using Colegio.Core.Exceptions;
using Colegio.Core.Interfaces;
using Colegio.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Colegio.Core.Services
{
    public class IngresoService : IIngresoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public IngresoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public PageList<Ingreso> GetIngresos(IngresoQueryFilter filters)
        {
            var ingresos = _unitOfWork.IngresoRepository.GetAll();
            if (filters.Nombre != null)
            {
                ingresos = ingresos.Where(x => x.Nombre.ToLower().Contains(filters.Nombre.ToLower()));
            }

            if (filters.Apellido != null)
            {
                ingresos = ingresos.Where(x => x.Apellido.ToLower().Contains(filters.Apellido.ToLower()));
            }

            if (filters.Edad != null)
            {
                ingresos = ingresos.Where(x => x.Edad == filters.Edad);
            }

            if (filters.Casa != null)
            {
                ingresos = ingresos.Where(x => x.Casa == filters.Casa);
            }

            var pageIngesos = PageList<Ingreso>.Create(ingresos, filters.PageNumber, filters.PageSize);

            return pageIngesos;
        }

        public async Task<Ingreso> GetIngreso(int Id)
        {
            return await _unitOfWork.IngresoRepository.GetById(Id);
        }

        public async Task InsertIngreso(Ingreso ingreso)
        {
            validatorIngreso(ingreso);
            await _unitOfWork.IngresoRepository.Add(ingreso);
        }

        public async Task<bool> UpdateIngreso(Ingreso ingreso)
        {
            validatorIngreso(ingreso);
            _unitOfWork.IngresoRepository.Update(ingreso);
            await _unitOfWork.SaveChangesAsyn();
            return true;
        }

        public async Task<bool> DeleteIngreso(int Id)
        {
            await _unitOfWork.IngresoRepository.Delete(Id);
            return true;
        }

        private void validatorIngreso(Ingreso ingreso)
        {
            if (!Regex.IsMatch(ingreso.Nombre, @"^[a-zA-Z]+$"))
            {
                throw new BusinessExeption("El Nombre no bebe tener numeros.");
            }
            if (!Regex.IsMatch(ingreso.Apellido, @"^[a-zA-Z]+$"))
            {
                throw new BusinessExeption("El Apellido no bebe tener numeros.");
            }
            if (Regex.IsMatch(ingreso.Identificacion, @"^[a-zA-Z]+$"))
            {
                throw new BusinessExeption("La Identificacion debe tener solo numeros.");
            }
            if (Regex.IsMatch(ingreso.Edad, @"^[a-zA-Z]+$"))
            {
                throw new BusinessExeption("La Edad debe tener solo numeros.");
            }
            string[] casas =
            {
                "Gryffindor", "Hufflepuff", "Ravenclaw", "Slytherin"
            };
            if (!Array.Exists(casas, ele => ele == ingreso.Casa))
            {
                throw new BusinessExeption("Debe ingresar una de estas casas Gryffindor, Hufflepuff, Ravenclaw, Slytherin");
            }
        }
    }
}
