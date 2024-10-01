using AVMTravel.Core.Entities;
using AVMTravel.Core.Interfaces;
using System;

namespace AVMTravel.Services.Services
{
    /// <summary>
    /// Servicio para gestionar las operaciones relacionadas con los usuarios.
    /// </summary>
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Registra un nuevo usuario.
        /// </summary>
        /// <param name="usuario">El usuario a registrar.</param>
        public void RegistrarUsuario(Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Nombre))
            {
                throw new ArgumentException("El nombre del usuario no puede estar vacío.");
            }

            if (string.IsNullOrWhiteSpace(usuario.CorreoElectronico))
            {
                throw new ArgumentException("El correo electrónico no puede estar vacío.");
            }

            if (string.IsNullOrWhiteSpace(usuario.Contrasena))
            {
                throw new ArgumentException("La contraseña no puede estar vacía.");
            }

            _usuarioRepository.RegistrarUsuario(usuario);
        }

        /// <summary>
        /// Valida las credenciales del usuario.
        /// </summary>
        /// <param name="correoElectronico">El correo electrónico del usuario.</param>
        /// <param name="contrasena">La contraseña del usuario.</param>
        /// <returns>El usuario si las credenciales son válidas, de lo contrario null.</returns>
        public Usuario ValidarUsuario(string correoElectronico, string contrasena)
        {
            if (string.IsNullOrWhiteSpace(correoElectronico))
            {
                throw new ArgumentException("El correo electrónico no puede estar vacío.");
            }

            if (string.IsNullOrWhiteSpace(contrasena))
            {
                throw new ArgumentException("La contraseña no puede estar vacía.");
            }

            return _usuarioRepository.ValidarUsuario(correoElectronico, contrasena);
        }
    }
}