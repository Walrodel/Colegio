using Colegio.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Colegio.Core.Entities
{
    public class Seguridad : BaseEntity
    {
        public string Usuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public TipoRol Rol { get; set; }
    }
}
