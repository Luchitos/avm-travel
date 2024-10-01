using AVMTravel.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMTravel.Core.Interfaces
{
    /// <summary>
    /// Interfaz para gestionar las operaciones relacionadas con los usuarios.
    /// </summary>
    public interface IUsuarioService
    {
        /// <summary>
        /// Registra un nuevo usuario.
        /// </summary>
        /// <param name="usuario">El usuario a registrar.</param>
        void RegistrarUsuario(Usuario usuario);

        /// <summary>
        /// Valida las credenciales del usuario.
        /// </summary>
        /// <param name="correoElectronico">El correo electrónico del usuario.</param>
        /// <param name="contrasena">La contraseña del usuario.</param>
        /// <returns>El usuario si las credenciales son válidas, de lo contrario null.</returns>
        Usuario ValidarUsuario(string correoElectronico, string contrasena);
    }
}

