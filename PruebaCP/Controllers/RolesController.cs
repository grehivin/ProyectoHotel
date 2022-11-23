using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AccesoDatos;
using Entidades;
using Negocio;

namespace WebAPI.Controllers
{
    public class RolesController : Controller
    {
        private readonly HotelContext _context;
        private readonly IRegistroActividad _registroActividad;

        public RolesController() // (HotelContext context)
        {
            _context = new HotelContext(); // context;
            _registroActividad = new RegistroActividad();
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
                _registroActividad.AgregarRegistro(new Actividad("ver", HttpContext.User.Claims.First().Value, "fallido"), new Roles());

                return NotFound();
            }

            var roles = await _context.Roles
                .FirstOrDefaultAsync(m => m.IdRol == id);
            if (roles == null)
            {
                _registroActividad.AgregarRegistro(new Actividad("ver", HttpContext.User.Claims.First().Value, "fallido"), roles);

                return NotFound();
            }

            _registroActividad.AgregarRegistro(new Actividad("ver", HttpContext.User.Claims.First().Value, "completado"), roles);

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
            if (ModelState.IsValid)
            {
                _context.Add(roles);
                await _context.SaveChangesAsync();

                _registroActividad.AgregarRegistro(new Actividad("crear", HttpContext.User.Claims.First().Value, "completado"), roles);

                return RedirectToAction(nameof(Index));
            }
            _registroActividad.AgregarRegistro(new Actividad("crear", HttpContext.User.Claims.First().Value, "fallido"), roles);

            return View(roles);
        }

        // GET: Roles/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                _registroActividad.AgregarRegistro(new Actividad("editar", HttpContext.User.Claims.First().Value, "fallido"), new Roles());

                return NotFound();
            }

            var roles = await _context.Roles.FindAsync(id);
            if (roles == null)
            {
                _registroActividad.AgregarRegistro(new Actividad("editar", HttpContext.User.Claims.First().Value, "fallido"), roles);

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
            if (id != roles.IdRol)
            {
                _registroActividad.AgregarRegistro(new Actividad("editar", HttpContext.User.Claims.First().Value, "fallido"), roles);

                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RolesExists(roles.IdRol))
                    {
                        _registroActividad.AgregarRegistro(new Actividad("editar", HttpContext.User.Claims.First().Value, "fallido"), roles);

                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                _registroActividad.AgregarRegistro(new Actividad("editar", HttpContext.User.Claims.First().Value, "completado"), roles);

                return RedirectToAction(nameof(Index));
            }
            _registroActividad.AgregarRegistro(new Actividad("editar", HttpContext.User.Claims.First().Value, "fallido"), roles);

            return View(roles);
        }

        // GET: Roles/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                _registroActividad.AgregarRegistro(new Actividad("borrar", HttpContext.User.Claims.First().Value, "fallido"), new Roles());

                return NotFound();
            }

            var roles = await _context.Roles
                .FirstOrDefaultAsync(m => m.IdRol == id);
            if (roles == null)
            {
                _registroActividad.AgregarRegistro(new Actividad("borrar", HttpContext.User.Claims.First().Value, "fallido"), roles);
                
                return NotFound();
            }

            return View(roles);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var roles = await _context.Roles.FindAsync(id);
            _context.Roles.Remove(roles);
            await _context.SaveChangesAsync();

            _registroActividad.AgregarRegistro(new Actividad("borrar", HttpContext.User.Claims.First().Value, "completado"), roles);

            return RedirectToAction(nameof(Index));
        }

        private bool RolesExists(decimal id)
        {
            return _context.Roles.Any(e => e.IdRol == id);
        }
    }
}
