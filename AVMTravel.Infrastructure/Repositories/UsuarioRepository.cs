using System.Linq;
using AVMTravel.Core.Entities;
using AVMTravel.Core.Interfaces;
using AVMTravel.Infrastructure.Data;

namespace AVMTravel.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AvmTravelDbContext _context;

        public UsuarioRepository()
        {
            _context = new AvmTravelDbContext();
        }

        /// <summary>
        /// Registra un nuevo usuario en el sistema.
        /// </summary>
        /// <param name="usuario">El usuario a registrar.</param>
        public void RegistrarUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        /// <summary>
        /// Valida las credenciales de un usuario.
        /// </summary>
        /// <param name="correoElectronico">El correo electrónico del usuario.</param>
        /// <param name="contrasena">La contraseña del usuario.</param>
        /// <returns>El usuario si las credenciales son válidas; de lo contrario, null.</returns>
        public Usuario ValidarUsuario(string correoElectronico, string contrasena)
        {
            return _context.Usuarios.FirstOrDefault(u => u.CorreoElectronico == correoElectronico && u.Contrasena == contrasena);
        }
    }
}
