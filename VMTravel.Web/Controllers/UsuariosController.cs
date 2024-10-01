using AVMTravel.Core.Entities;
using AVMTravel.Core.Interfaces;
using AVMTravel.Web.ViewModels;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using VMTravel.Web.ViewModels;

namespace VMTravel.Web.Controllers
{
    /// <summary>
    /// Controlador para la gestión de usuarios, incluyendo registro, inicio de sesión y cierre de sesión.
    /// </summary>
    public class UsuariosController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        /// <summary>
        /// Constructor del controlador UsuariosController.
        /// </summary>
        /// <param name="usuarioService">Servicio para la gestión de usuarios.</param>
        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        /// <summary>
        /// Muestra la vista de registro de usuario.
        /// </summary>
        /// <returns>Vista de registro.</returns>
        public ActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Registra un nuevo usuario si el modelo es válido.
        /// </summary>
        /// <param name="model">Modelo con los datos del usuario a registrar.</param>
        /// <returns>Redirige a la página de inicio de sesión si el registro es exitoso, de lo contrario, devuelve la vista de registro.</returns>
        [HttpPost]
        public ActionResult Register(RegistroViewModel model)
        {
            if (ModelState.IsValid)
            {
                var nuevoUsuario = new Usuario
                {
                    Nombre = model.Nombre,
                    CorreoElectronico = model.CorreoElectronico,
                    Contrasena = model.Contrasena
                };
                _usuarioService.RegistrarUsuario(nuevoUsuario);
                return RedirectToAction("Login");
            }
            return View(model);
        }

        /// <summary>
        /// Registra un nuevo usuario utilizando UsuarioViewModel.
        /// </summary>
        /// <param name="model">Modelo con los datos del usuario.</param>
        /// <returns>Redirige a la página de inicio de sesión si el registro es exitoso.</returns>
        [HttpPost]
        public ActionResult RegistrarUsuario(UsuarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usuario = new Usuario
                {
                    Nombre = model.Nombre,
                    CorreoElectronico = model.CorreoElectronico,
                    Contrasena = model.Contrasena
                };

                _usuarioService.RegistrarUsuario(usuario);
                return RedirectToAction("Login");
            }
            return View("Registro");
        }

        /// <summary>
        /// Muestra la vista de inicio de sesión.
        /// </summary>
        /// <returns>Vista de inicio de sesión.</returns>
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Valida las credenciales del usuario y lo autentica si son correctas.
        /// </summary>
        /// <param name="model">Modelo con las credenciales de inicio de sesión.</param>
        /// <returns>Redirige a la lista de tours si el inicio de sesión es exitoso, de lo contrario, devuelve la vista de inicio de sesión con un error.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usuarioValido = _usuarioService.ValidarUsuario(model.CorreoElectronico, model.Contrasena);

                if (usuarioValido != null)
                {
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                        1,
                        usuarioValido.Nombre,
                        DateTime.Now,
                        DateTime.Now.AddMinutes(60),
                        true,
                        usuarioValido.Id.ToString(),
                        FormsAuthentication.FormsCookiePath
                    );

                    string encTicket = FormsAuthentication.Encrypt(authTicket);
                    HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                    Response.Cookies.Add(authCookie);

                    return RedirectToAction("MostrarTours", "Tour");
                }
                else
                {
                    ModelState.AddModelError("", "Correo electrónico o contraseña incorrectos.");
                }
            }

            return View(model);
        }

        /// <summary>
        /// Valida las credenciales del usuario y lo guarda en sesión si son correctas.
        /// </summary>
        /// <param name="model">Modelo con las credenciales de inicio de sesión.</param>
        /// <returns>Redirige a la página de reservas si el inicio de sesión es exitoso, de lo contrario, devuelve la vista de inicio de sesión con un error.</returns>
        [HttpPost]
        public ActionResult ValidarUsuario(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usuarioValido = _usuarioService.ValidarUsuario(model.CorreoElectronico, model.Contrasena);

                if (usuarioValido != null)
                {
                    Session["UsuarioLogueado"] = usuarioValido;
                    return RedirectToAction("ReservarTour", "Reservas");
                }
                else
                {
                    ModelState.AddModelError("", "Correo electrónico o contraseña incorrecta.");
                }
            }

            return View("Login");
        }

        /// <summary>
        /// Cierra la sesión del usuario actual.
        /// </summary>
        /// <returns>Redirige a la vista de inicio de sesión.</returns>
        public ActionResult Logout()
        {
            Session.Remove("UsuarioLogueado");
            return RedirectToAction("Login");
        }
    }
}
