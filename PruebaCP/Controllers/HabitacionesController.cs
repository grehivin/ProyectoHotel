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
    public class HabitacionesController : Controller
    {
        private readonly HotelContext _context;
        private readonly IRegistroActividad _registroActividad;

        public HabitacionesController() // (HotelContext context)
        {
            _context = new HotelContext(); // context;
            _registroActividad = new RegistroActividad();
        }

        // GET: Habitaciones
        public async Task<IActionResult> Index()
        {
            var hotelContext = _context.Habitaciones.Include(h => h.IdTipoHabitacionNavigation);
            return View(await hotelContext.ToListAsync());
        }

        // GET: Habitaciones/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                _registroActividad.AgregarRegistro(new Actividad("ver", HttpContext.User.Claims.First().Value, "fallido"), new Habitaciones());

                return NotFound();
            }

            var habitaciones = await _context.Habitaciones
                .Include(h => h.IdTipoHabitacionNavigation)
                .FirstOrDefaultAsync(m => m.IdHabitacion == id);
            if (habitaciones == null)
            {
                _registroActividad.AgregarRegistro(new Actividad("ver", HttpContext.User.Claims.First().Value, "fallido"), habitaciones);

                return NotFound();
            }

            _registroActividad.AgregarRegistro(new Actividad("ver", HttpContext.User.Claims.First().Value, "completado"), habitaciones);

            return View(habitaciones);
        }

        // GET: Habitaciones/Create
        public IActionResult Create()
        {
            ViewData["IdTipoHabitacion"] = new SelectList(_context.TiposHabitaciones, "IdTipoHabitacion", "Descripcion");
            return View();
        }

        // POST: Habitaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHabitacion,NumHabitacion,PisoHabitacion,IdTipoHabitacion,CapacidadPersonas,HabitacionActiva")] Habitaciones habitaciones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(habitaciones);
                await _context.SaveChangesAsync();

                _registroActividad.AgregarRegistro(new Actividad("crear", HttpContext.User.Claims.First().Value, "completado"), habitaciones);

                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTipoHabitacion"] = new SelectList(_context.TiposHabitaciones, "IdTipoHabitacion", "Descripcion", habitaciones.IdTipoHabitacion);

            _registroActividad.AgregarRegistro(new Actividad("crear", HttpContext.User.Claims.First().Value, "fallido"), habitaciones);

            return View(habitaciones);
        }

        // GET: Habitaciones/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                _registroActividad.AgregarRegistro(new Actividad("editar", HttpContext.User.Claims.First().Value, "fallido"), new Habitaciones());

                return NotFound();
            }

            var habitaciones = await _context.Habitaciones.FindAsync(id);
            if (habitaciones == null)
            {
                _registroActividad.AgregarRegistro(new Actividad("editar", HttpContext.User.Claims.First().Value, "fallido"), habitaciones);

                return NotFound();
            }
            ViewData["IdTipoHabitacion"] = new SelectList(_context.TiposHabitaciones, "IdTipoHabitacion", "Descripcion", habitaciones.IdTipoHabitacion);
            return View(habitaciones);
        }

        // POST: Habitaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("IdHabitacion,NumHabitacion,PisoHabitacion,IdTipoHabitacion,CapacidadPersonas,HabitacionActiva")] Habitaciones habitaciones)
        {
            if (id != habitaciones.IdHabitacion)
            {
                _registroActividad.AgregarRegistro(new Actividad("editar", HttpContext.User.Claims.First().Value, "fallido"), habitaciones);

                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(habitaciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HabitacionesExists(habitaciones.IdHabitacion))
                    {
                        _registroActividad.AgregarRegistro(new Actividad("editar", HttpContext.User.Claims.First().Value, "fallido"), habitaciones);

                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                _registroActividad.AgregarRegistro(new Actividad("editar", HttpContext.User.Claims.First().Value, "completado"), habitaciones);

                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTipoHabitacion"] = new SelectList(_context.TiposHabitaciones, "IdTipoHabitacion", "Descripcion", habitaciones.IdTipoHabitacion);

            _registroActividad.AgregarRegistro(new Actividad("editar", HttpContext.User.Claims.First().Value, "fallido"), habitaciones);

            return View(habitaciones);
        }

        // GET: Habitaciones/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                _registroActividad.AgregarRegistro(new Actividad("borrar", HttpContext.User.Claims.First().Value, "fallido"), new Habitaciones());

                return NotFound();
            }

            var habitaciones = await _context.Habitaciones
                .Include(h => h.IdTipoHabitacionNavigation)
                .FirstOrDefaultAsync(m => m.IdHabitacion == id);
            if (habitaciones == null)
            {
                _registroActividad.AgregarRegistro(new Actividad("borrar", HttpContext.User.Claims.First().Value, "fallido"), habitaciones);

                return NotFound();
            }

            return View(habitaciones);
        }

        // POST: Habitaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var habitaciones = await _context.Habitaciones.FindAsync(id);
            _context.Habitaciones.Remove(habitaciones);
            await _context.SaveChangesAsync();

            _registroActividad.AgregarRegistro(new Actividad("borrar", HttpContext.User.Claims.First().Value, "completado"), habitaciones);

            return RedirectToAction(nameof(Index));
        }

        private bool HabitacionesExists(decimal id)
        {
            return _context.Habitaciones.Any(e => e.IdHabitacion == id);
        }
    }
}
