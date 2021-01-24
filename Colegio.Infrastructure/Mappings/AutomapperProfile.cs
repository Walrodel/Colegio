using AutoMapper;
using Colegio.Core.DTOs;
using Colegio.Core.Entities;

namespace Colegio.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Ingreso, IngresoDto>();
            CreateMap<IngresoDto, Ingreso>();
        }
    }
}
