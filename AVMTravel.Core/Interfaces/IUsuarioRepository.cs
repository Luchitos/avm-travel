using AVMTravel.Core.Entities;

namespace AVMTravel.Core.Interfaces
{
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Registra un nuevo usuario.
        /// </summary>
        /// <param name="usuario">El usuario a registrar.</param>
        void RegistrarUsuario(Usuario usuario);

        /// <summary>
        /// Valida las credenciales de un usuario.
        /// </summary>
        /// <param name="correoElectronico">El correo electrónico del usuario.</param>
        /// <param name="contrasena">La contraseña del usuario.</param>
        /// <returns>El usuario validado si las credenciales son correctas; de lo contrario, null.</returns>
        Usuario ValidarUsuario(string correoElectronico, string contrasena);
    }
}
