using AutoMapper;
using Colegio.Api.Responses;
using Colegio.Core.DTOs;
using Colegio.Core.Entities;
using Colegio.Core.Enumerations;
using Colegio.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Colegio.Api.Controllers
{
    [Authorize(Roles = nameof(TipoRol.Administrador))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SeguridadController : ControllerBase
    {
        private readonly ISeguridadService _seguridadService;
        private readonly IMapper _mapper;

        public SeguridadController(ISeguridadService seguridadService, IMapper mapper)
        {
            _seguridadService = seguridadService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post(SeguridadDto seguridadDto)
        {
            var seguridad = _mapper.Map<Seguridad>(seguridadDto);
            await _seguridadService.RegisterUser(seguridad);
            seguridadDto = _mapper.Map<SeguridadDto>(seguridad);
            var respose = new ApiResponse<SeguridadDto>(seguridadDto);
            return Ok(seguridad);
        }
    }
}
