using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AVMTravel.API.Models
{
    /// <summary>
    /// Clase que representa los datos de un usuario.
    /// </summary>
    public class UsuarioDto
    {
        /// <summary>
        /// Obtiene o establece el correo electrónico del usuario.
        /// </summary>
        public string CorreoElectronico { get; set; }

        /// <summary>
        /// Obtiene o establece la contraseña del usuario.
        /// </summary>
        public string Contrasena { get; set; }
    }
}