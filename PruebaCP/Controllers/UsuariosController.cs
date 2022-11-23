using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AccesoDatos;
using Entidades;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace WebAPI.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly HotelContext _context;

        public UsuariosController() // (HotelContext context)
        {
            _context = new HotelContext(); // context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios.ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Usuario == id);
            if (usuarios == null)
            {
                return NotFound();
            }

            return View(usuarios);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Usuario,Contrasena,UsuarioActivo")] Usuarios usuarios)
        {
            IAccesoMongo bitacora = new AccesoMongo();

            if (ModelState.IsValid)
            {
                _context.Add(usuarios);
                await _context.SaveChangesAsync();
                bitacora.AgregarRegistroBitacora(new Accion()
                {
                    AccionRealizada = "CrearUsuario",
                    Objeto = nameof(usuarios),
                    Instancia = usuarios.GetType().ToString(),
                    Usuario = HttpContext.User.Claims.First().Value,
                    Resultado = "Completado",
                    Momento = DateTime.Now

                });
                return RedirectToAction(nameof(Index));
            }
            bitacora.AgregarRegistroBitacora(new Accion()
            {
                AccionRealizada = "CrearUsuario",
                Objeto = nameof(usuarios),
                Instancia = usuarios.GetType().ToString(),
                Usuario = HttpContext.User.Claims.First().Value,
                Resultado = "Fallido",
                Momento = DateTime.Now

            });
            return View(usuarios);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = await _context.Usuarios.FindAsync(id);
            if (usuarios == null)
            {
                return NotFound();
            }
            return View(usuarios);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Usuario,Contrasena,UsuarioActivo")] Usuarios usuarios)
        {
            IAccesoMongo bitacora = new AccesoMongo();
            if (id != usuarios.Usuario)
            {
                bitacora.AgregarRegistroBitacora(new Accion()
                {
                    AccionRealizada = "EditarUsuario",
                    Objeto = nameof(usuarios),
                    Instancia = usuarios.GetType().ToString(),
                    Usuario = HttpContext.User.Claims.First().Value,
                    Resultado = "Usuario no encontrado",
                    Momento = DateTime.Now

                });
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarios);
                    await _context.SaveChangesAsync();
                    bitacora.AgregarRegistroBitacora(new Accion()
                    {
                        AccionRealizada = "EditarUsuario",
                        Objeto = nameof(usuarios),
                        Instancia = usuarios.GetType().ToString(),
                        Usuario = HttpContext.User.Claims.First().Value,
                        Resultado = "Completado",
                        Momento = DateTime.Now

                    });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuariosExists(usuarios.Usuario))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuarios);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Usuario == id);
            if (usuarios == null)
            {
                return NotFound();
            }

            return View(usuarios);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            IAccesoMongo bitacora = new AccesoMongo();
            var usuarios = await _context.Usuarios.FindAsync(id);
            _context.Usuarios.Remove(usuarios);
            await _context.SaveChangesAsync();
            bitacora.AgregarRegistroBitacora(new Accion()
            {
                AccionRealizada = "EliminarUsuario",
                Objeto = nameof(usuarios),
                Instancia = usuarios.GetType().ToString(),
                Usuario = HttpContext.User.Claims.First().Value,
                Resultado = "Completado",
                Momento = DateTime.Now

            });
            return RedirectToAction(nameof(Index));
        }

        private bool UsuariosExists(string id)
        {
            return _context.Usuarios.Any(e => e.Usuario == id);
        }
    }
}
