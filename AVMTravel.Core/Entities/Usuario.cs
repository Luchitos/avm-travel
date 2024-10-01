using System;
using System.ComponentModel.DataAnnotations;

namespace AVMTravel.Core.Entities
{
    /// <summary>
    /// Clase que representa un usuario del sistema.
    /// </summary>
    public class Usuario
    {
        /// <summary>
        /// Obtiene o establece el identificador del usuario.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del usuario.
        /// </summary>
        [Required]
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece el correo electrónico del usuario.
        /// </summary>
        [Required]
        public string CorreoElectronico { get; set; }

        /// <summary>
        /// Obtiene o establece la contraseña del usuario.
        /// </summary>
        [Required]
        public string Contrasena { get; set; }

        /// <summary>
        /// Muestra la información del usuario.
        /// </summary>
        /// <returns>Información del usuario como cadena de texto.</returns>
        public string MostrarInformacion()
        {
            return $"Usuario: {Nombre}, Email: {CorreoElectronico}";
        }
    }
}
