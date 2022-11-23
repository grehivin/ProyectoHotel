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
    public class RolesUsuariosController : Controller
    {
        private readonly HotelContext _context;

        public RolesUsuariosController() // (HotelContext context)
        {
            _context = new HotelContext(); // context;
        }

        // GET: RolesUsuarios
        public async Task<IActionResult> Index()
        {
            var hotelContext = _context.RolesUsuarios.Include(r => r.IdRolNavigation).Include(r => r.UsuarioNavigation);
            return View(await hotelContext.ToListAsync());
        }

        // GET: RolesUsuarios/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolesUsuarios = await _context.RolesUsuarios
                .Include(r => r.IdRolNavigation)
                .Include(r => r.UsuarioNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rolesUsuarios == null)
            {
                return NotFound();
            }

            return View(rolesUsuarios);
        }

        // GET: RolesUsuarios/Create
        public IActionResult Create()
        {
            ViewData["IdRol"] = new SelectList(_context.Roles, "IdRol", "Descripcion");
            ViewData["Usuario"] = new SelectList(_context.Usuarios, "Usuario", "Usuario");
            return View();
        }

        // POST: RolesUsuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Usuario,IdRol")] RolesUsuarios rolesUsuarios)
        {
            IAccesoMongo bitacora = new AccesoMongo();
            if (ModelState.IsValid)
            {
                _context.Add(rolesUsuarios);
                await _context.SaveChangesAsync();
                bitacora.AgregarRegistroBitacora(new Accion()
                {
                    AccionRealizada = "CrearRolesUsuarios",
                    Objeto = nameof(rolesUsuarios),
                    Instancia = rolesUsuarios.GetType().ToString(),
                    Usuario = HttpContext.User.Claims.First().Value,
                    Resultado = "Completado",
                    Momento = DateTime.Now

                });
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdRol"] = new SelectList(_context.Roles, "IdRol", "Descripcion", rolesUsuarios.IdRol);
            ViewData["Usuario"] = new SelectList(_context.Usuarios, "Usuario", "Usuario", rolesUsuarios.Usuario);
            bitacora.AgregarRegistroBitacora(new Accion()
            {
                AccionRealizada = "CrearRolesUsuarios",
                Objeto = nameof(rolesUsuarios),
                Instancia = rolesUsuarios.GetType().ToString(),
                Usuario = HttpContext.User.Claims.First().Value,
                Resultado = "Fallido",
                Momento = DateTime.Now

            });
            return View(rolesUsuarios);
        }

        // GET: RolesUsuarios/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolesUsuarios = await _context.RolesUsuarios.FindAsync(id);
            if (rolesUsuarios == null)
            {
                return NotFound();
            }
            ViewData["IdRol"] = new SelectList(_context.Roles, "IdRol", "Descripcion", rolesUsuarios.IdRol);
            ViewData["Usuario"] = new SelectList(_context.Usuarios, "Usuario", "Usuario", rolesUsuarios.Usuario);
            return View(rolesUsuarios);
        }

        // POST: RolesUsuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,Usuario,IdRol")] RolesUsuarios rolesUsuarios)
        {
            IAccesoMongo bitacora = new AccesoMongo();
            if (id != rolesUsuarios.Id)
            {
                bitacora.AgregarRegistroBitacora(new Accion()
                {
                    AccionRealizada = "EditarRolesUsuarios",
                    Objeto = nameof(rolesUsuarios),
                    Instancia = rolesUsuarios.GetType().ToString(),
                    Usuario = HttpContext.User.Claims.First().Value,
                    Resultado = "Rol de Usuario no encontrado",
                    Momento = DateTime.Now

                });
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rolesUsuarios);
                    await _context.SaveChangesAsync();
                    bitacora.AgregarRegistroBitacora(new Accion()
                    {
                        AccionRealizada = "EditarRolesUsuarios",
                        Objeto = nameof(rolesUsuarios),
                        Instancia = rolesUsuarios.GetType().ToString(),
                        Usuario = HttpContext.User.Claims.First().Value,
                        Resultado = "Completado",
                        Momento = DateTime.Now

                    });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RolesUsuariosExists(rolesUsuarios.Id))
                    {
                        bitacora.AgregarRegistroBitacora(new Accion()
                        {
                            AccionRealizada = "EditarRolesUsuarios",
                            Objeto = nameof(rolesUsuarios),
                            Instancia = rolesUsuarios.GetType().ToString(),
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
            ViewData["IdRol"] = new SelectList(_context.Roles, "IdRol", "Descripcion", rolesUsuarios.IdRol);
            ViewData["Usuario"] = new SelectList(_context.Usuarios, "Usuario", "Usuario", rolesUsuarios.Usuario);
            return View(rolesUsuarios);
        }

        // GET: RolesUsuarios/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolesUsuarios = await _context.RolesUsuarios
                .Include(r => r.IdRolNavigation)
                .Include(r => r.UsuarioNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rolesUsuarios == null)
            {
                return NotFound();
            }

            return View(rolesUsuarios);
        }

        // POST: RolesUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            IAccesoMongo bitacora = new AccesoMongo();
            var rolesUsuarios = await _context.RolesUsuarios.FindAsync(id);
            _context.RolesUsuarios.Remove(rolesUsuarios);
            await _context.SaveChangesAsync();
            bitacora.AgregarRegistroBitacora(new Accion()
            {
                AccionRealizada = "EliminarRolesUsuario",
                Objeto = nameof(rolesUsuarios),
                Instancia = rolesUsuarios.GetType().ToString(),
                Usuario = HttpContext.User.Claims.First().Value,
                Resultado = "Fallido EliminarRolesUsuario",
                Momento = DateTime.Now

            });
            return RedirectToAction(nameof(Index));
        }

        private bool RolesUsuariosExists(decimal id)
        {
            return _context.RolesUsuarios.Any(e => e.Id == id);
        }
    }
}
