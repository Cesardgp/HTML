using Microsoft.AspNetCore.Mvc;
using Prueba2.Models;

namespace Prueba2.Controllers
{
    public class AccountController : Controller
    {

        private readonly UsuarioService _usuarioService;

        public AccountController(
            UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult Register( )
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string usuario, string correo, string contraseña)
        {

            var nuevoUsuario = new Users
            {
                Usuario = usuario,
                Correo = correo,
                Contraseña = contraseña
            };
            await _usuarioService.CrearUsuario(nuevoUsuario);

            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string usuario,string contraseña)
        {
            var user =
                await _usuarioService.Login(
                    usuario,
                    contraseña);

            if (user == null)
            {
                ViewBag.Error =
                    "Credenciales incorrectas";

                return View();
            }

            HttpContext.Session.SetString(
                "Usuario",
                user.Usuario);

            return RedirectToAction(
                "Index",
                "Home");
        }
    }
}
