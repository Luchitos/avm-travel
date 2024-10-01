using System.Web.Http;
using AVMTravel.Core.Interfaces;
using AVMTravel.API.Models;
using AVMTravel.Core.Entities;

namespace AVMTravel.API.Controllers
{
    /// <summary>
    /// Controlador para gestionar los usuarios.
    /// </summary>
    [RoutePrefix("api/usuarios")]
    public class UsuariosController : ApiController
    {
        private readonly IUsuarioService _usuarioService;

        /// <summary>
        /// Constructor del controlador que recibe el servicio de usuarios.
        /// </summary>
        /// <param name="usuarioService">Servicio para gestionar usuarios.</param>
        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        /// <summary>
        /// Registra un nuevo usuario.
        /// </summary>
        /// <param name="usuarioDto">Objeto DTO que contiene los datos del usuario.</param>
        /// <returns>Resultado de la acción HTTP.</returns>
        [HttpPost]
        [Route("")]
        public IHttpActionResult RegistrarUsuario([FromBody] UsuarioDto usuarioDto)
        {
            if (usuarioDto == null)
                return BadRequest("Datos de usuario inválidos.");

            var usuario = new Usuario
            {
                CorreoElectronico = usuarioDto.CorreoElectronico,
                Contrasena = usuarioDto.Contrasena
            };

            _usuarioService.RegistrarUsuario(usuario);
            return Ok(usuario);
        }
    }
}
