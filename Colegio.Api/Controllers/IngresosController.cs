using AutoMapper;
using Colegio.Api.Responses;
using Colegio.Core.DTOs;
using Colegio.Core.Entities;
using Colegio.Core.Interfaces;
using Colegio.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colegio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngresosController : ControllerBase
    {
        private readonly IIngresoService _ingresoService;
        private readonly IMapper _mapper;

        public IngresosController(IIngresoService ingresoService, IMapper mapper)
        {
            _ingresoService = ingresoService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetIngresos()
        {
            var ingresos = _ingresoService.GetIngresos();
            var ingresosDto = _mapper.Map<IEnumerable<IngresoDto>>(ingresos);
            var respose = new ApiResponse<IEnumerable<IngresoDto>>(ingresosDto);
            return Ok(respose);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetIngreso(int Id)
        {
            var ingreso = await _ingresoService.GetIngreso(Id);
            var ingresoDto = _mapper.Map<IngresoDto>(ingreso);
            var respose = new ApiResponse<IngresoDto>(ingresoDto);
            return Ok(respose);
        }

        [HttpPost]
        public async Task<IActionResult> Post(IngresoDto ingresoDto)
        {
            var ingreso = _mapper.Map<Ingreso>(ingresoDto);
            await _ingresoService.InsertIngreso(ingreso);
            ingresoDto = _mapper.Map<IngresoDto>(ingreso);
            var respose = new ApiResponse<IngresoDto>(ingresoDto);
            return Ok(ingreso);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, IngresoDto ingresoDto)
        {
            var ingreso = _mapper.Map<Ingreso>(ingresoDto);
            ingreso.Id = Id;
            var result = await _ingresoService.UpdateIngreso(ingreso);
            var respose = new ApiResponse<bool>(result);
            return Ok(respose);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await _ingresoService.DeleteIngreso(Id);
            var respose = new ApiResponse<bool>(result);
            return Ok(respose);
        }
    }
}
