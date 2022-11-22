using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class SeguridadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult AccesoDenegado()
        {

            return View();

        }

        [HttpPost]
       public async Task <IActionResult> Autenticacion(Usuarios _usuarios) 
        
        {
            _usuarios.Estado = true;
            Usuarios objUsuario = _usuarios.ValidarUsuario();
            if (objUsuario != null)
            {
                var claims = new List<Claim>()
                {
                new Claim(ClaimTypes.Name, objUsuario.Usuario),
                new Claim("Usuario", objUsuario.Usuario)
                };

                foreach (Perfil item in objUsuario.Perfiles)
                    claims.Add(new Claim(ClaimTypes.Role, item.Codigo.ToString()));

                var claimidentidad = new ClaimsIdentity(claims ,CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimidentidad));

              return RedirectToAction("Index", "Home");
            }
            
            return RedirectToAction("Index");   
        }


        [HttpGet]

        public async Task<IActionResult> CerrarSesion()
        {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Seguridad");
                 
        }

    }
}
