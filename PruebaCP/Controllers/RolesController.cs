using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AccesoDatos;
using Entidades;

namespace WebAPI.Controllers
{
    public class RolesController : Controller
    {
        private readonly HotelContext _context;

        public RolesController() // (HotelContext context)
        {
            _context = new HotelContext(); // context;
        }

        // GET: Roles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Roles.ToListAsync());
        }

        // GET: Roles/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roles = await _context.Roles
                .FirstOrDefaultAsync(m => m.IdRol == id);
            if (roles == null)
            {
                return NotFound();
            }

            return View(roles);
        }

        // GET: Roles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRol,Descripcion,RolActivo")] Roles roles)
        {
            IAccesoMongo bitacora = new AccesoMongo();
            if (ModelState.IsValid)
            {
                _context.Add(roles);
                await _context.SaveChangesAsync();
                bitacora.AgregarRegistroBitacora(new Accion()
                {
                    AccionRealizada = "CrearRol",
                    Objeto = nameof(roles),
                    Instancia = roles.GetType().ToString(),
                    Usuario = HttpContext.User.Claims.First().Value,
                    Resultado = "Completado",
                    Momento = DateTime.Now

                });
                bitacora.AgregarRegistroBitacora(new Accion()
                {
                    AccionRealizada = "CrearRol",
                    Objeto = nameof(roles),
                    Instancia = roles.GetType().ToString(),
                    Usuario = HttpContext.User.Claims.First().Value,
                    Resultado = "Fallido",
                    Momento = DateTime.Now

                });
                return RedirectToAction(nameof(Index));
            }
            return View(roles);
        }

        // GET: Roles/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roles = await _context.Roles.FindAsync(id);
            if (roles == null)
            {
                return NotFound();
            }
            return View(roles);
        }

        // POST: Roles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("IdRol,Descripcion,RolActivo")] Roles roles)
        {
            IAccesoMongo bitacora = new AccesoMongo();
            if (id != roles.IdRol)
            {
                bitacora.AgregarRegistroBitacora(new Accion()
                {
                    AccionRealizada = "EditarRol",
                    Objeto = nameof(roles),
                    Instancia = roles.GetType().ToString(),
                    Usuario = HttpContext.User.Claims.First().Value,
                    Resultado = "Rol no encontrado",
                    Momento = DateTime.Now

                });
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roles);
                    await _context.SaveChangesAsync();
                    bitacora.AgregarRegistroBitacora(new Accion()
                    {
                        AccionRealizada = "EditarRol",
                        Objeto = nameof(roles),
                        Instancia = roles.GetType().ToString(),
                        Usuario = HttpContext.User.Claims.First().Value,
                        Resultado = "Completado",
                        Momento = DateTime.Now

                    });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RolesExists(roles.IdRol))
                    {
                        bitacora.AgregarRegistroBitacora(new Accion()
                        {
                            AccionRealizada = "EditarRole",
                            Objeto = nameof(roles),
                            Instancia = roles.GetType().ToString(),
                            Usuario = HttpContext.User.Claims.First().Value,
                            Resultado = "Fallido",
                            Momento = DateTime.Now

                        });
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(roles);
        }

        // GET: Roles/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roles = await _context.Roles
                .FirstOrDefaultAsync(m => m.IdRol == id);
            if (roles == null)
            {
                return NotFound();
            }

            return View(roles);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            IAccesoMongo bitacora = new AccesoMongo();
            var roles = await _context.Roles.FindAsync(id);
            _context.Roles.Remove(roles);
            await _context.SaveChangesAsync();
            bitacora.AgregarRegistroBitacora(new Accion()
            {
                AccionRealizada = "EliminarRol",
                Objeto = nameof(roles),
                Instancia = roles.GetType().ToString(),
                Usuario = HttpContext.User.Claims.First().Value,
                Resultado = "Completado",
                Momento = DateTime.Now

            });
            return RedirectToAction(nameof(Index));
        }

        private bool RolesExists(decimal id)
        {
            return _context.Roles.Any(e => e.IdRol == id);
        }
    }
}
