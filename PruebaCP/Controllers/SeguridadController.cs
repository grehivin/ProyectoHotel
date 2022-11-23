using AccesoDatos;
using Entidades;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Negocio;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class SeguridadController : Controller
    {
        private readonly HotelContext _hotel;
        private readonly IRegistroActividad _registroActividad;
        public SeguridadController ()
        {
            _hotel = new HotelContext();
            _registroActividad = new RegistroActividad();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AccesoDenegado()
        {
            return View();
        }

        public IActionResult ErrorAcceso()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Autenticacion(Usuarios _usuario)
        {
            #region Autenticación con código cableado
            /*
            _usuario.Estado = true;
            Models.Usuarios objUsuario = _usuario.ValidarUsuario();
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
            // */
            #endregion

            #region Autenticación a la base de datos
            // /*
            var usuario = await _hotel.Usuarios
                .FirstOrDefaultAsync(x => x.Usuario == _usuario.Usuario);

            if (usuario == null)
            {
                _registroActividad.AgregarRegistroAcceso(new Actividad("iniciarsesion", _usuario.Usuario, "fallido"), string.Empty);

                return RedirectToAction("ErrorAcceso");
            }

            if (!(usuario.Contrasena == _usuario.Contrasena))
            {
                _registroActividad.AgregarRegistroAcceso(new Actividad("iniciarsesion", _usuario.Usuario, "fallido"), usuario.RolesUsuarios.ToString());

                return RedirectToAction("ErrorAcceso");
            }

            if (!usuario.UsuarioActivo)
            {
                _registroActividad.AgregarRegistroAcceso(new Actividad("iniciarsesion", _usuario.Usuario, "fallido"), usuario.RolesUsuarios.ToString());

                return RedirectToAction("ErrorAcceso");
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, usuario.Usuario),
                new Claim("Usuario", usuario.Usuario)
            };

            List<RolesUsuarios> rolesUsuario = await _hotel.RolesUsuarios.ToListAsync();

            foreach (RolesUsuarios rolUsuario in rolesUsuario)
            {
                if (rolUsuario.Usuario == usuario.Usuario)
                {
                    var rol = await _hotel.Roles
                        .FirstOrDefaultAsync(x => x.IdRol == rolUsuario.IdRol);

                    if (rol == null)
                    {
                        _registroActividad.AgregarRegistroAcceso(new Actividad("iniciarsesion", _usuario.Usuario, "fallido"), usuario.RolesUsuarios.ToString());

                        return RedirectToAction("ErrorAcceso");
                    }

                    if (!rol.RolActivo)
                    {
                        _registroActividad.AgregarRegistroAcceso(new Actividad("iniciarsesion", _usuario.Usuario, "fallido"), usuario.RolesUsuarios.ToString());

                        return RedirectToAction("ErrorAcceso");
                    }
                    
                    claims.Add(new Claim(ClaimTypes.Role, rol.Descripcion));
                }
            }

            var claimID = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimID));

            _registroActividad.AgregarRegistroAcceso(new Actividad("iniciarsesion", _usuario.Usuario, "completado"), claims[2].Value);

            return RedirectToAction("Index", "Home");
            // */
            #endregion
        }


        [HttpGet]
        public async Task<IActionResult> CerrarSesion()
        {
            string _usuario = HttpContext.User.Identity.Name;
            string _rol = HttpContext.User.FindFirst(ClaimTypes.Role).Value;

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            _registroActividad.AgregarRegistroAcceso(new Actividad("cerrarsesion", _usuario, "completado"), _rol);

            return RedirectToAction("Index", "Seguridad");
        }
    }
}
