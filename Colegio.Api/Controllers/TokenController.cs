using Colegio.Core.Entities;
using Colegio.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : Controller
    {
        private readonly IConfiguration _configutarion;
        private readonly ISeguridadService _seguridadService;
        public TokenController(IConfiguration configutarion, ISeguridadService seguridadService)
        {
            _configutarion = configutarion;
            _seguridadService = seguridadService;
        }

        [HttpPost]
        public async Task<IActionResult> IndexAuthentication(UserLogin login)
        {
            var validation = await IsValidUser(login);

            if (validation.Item1)
            {
                var token = GenerateToken(validation.Item2);
                return Ok(new { token });
            }

            return NotFound();

        }

        private async Task<(bool, Seguridad)> IsValidUser(UserLogin login)
        {
            var user = await _seguridadService.GetLoginbyCredentials(login);
            return (user != null, user);
        }

        private string GenerateToken(Seguridad seguridad)
        {
            //Header
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configutarion["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            //Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, seguridad.Usuario),
                new Claim("Nombre Usuario", seguridad.NombreUsuario),
                new Claim(ClaimTypes.Role, seguridad.Rol.ToString()),
            };

            //Payload
            var payload = new JwtPayload(
                _configutarion["Authentication:Issuer"],
                _configutarion["Authentication:Audience"],
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddMinutes(30)
                );

            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
