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
    public class HabitacionesController : Controller
    {
        private readonly HotelContext _context;

        public HabitacionesController() // (HotelContext context)
        {
            _context = new HotelContext(); // context;
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
                return NotFound();
            }

            var habitaciones = await _context.Habitaciones
                .Include(h => h.IdTipoHabitacionNavigation)
                .FirstOrDefaultAsync(m => m.IdHabitacion == id);
            if (habitaciones == null)
            {
                return NotFound();
            }

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
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTipoHabitacion"] = new SelectList(_context.TiposHabitaciones, "IdTipoHabitacion", "Descripcion", habitaciones.IdTipoHabitacion);
            return View(habitaciones);
        }

        // GET: Habitaciones/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitaciones = await _context.Habitaciones.FindAsync(id);
            if (habitaciones == null)
            {
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
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTipoHabitacion"] = new SelectList(_context.TiposHabitaciones, "IdTipoHabitacion", "Descripcion", habitaciones.IdTipoHabitacion);
            return View(habitaciones);
        }

        // GET: Habitaciones/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitaciones = await _context.Habitaciones
                .Include(h => h.IdTipoHabitacionNavigation)
                .FirstOrDefaultAsync(m => m.IdHabitacion == id);
            if (habitaciones == null)
            {
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
            return RedirectToAction(nameof(Index));
        }

        private bool HabitacionesExists(decimal id)
        {
            return _context.Habitaciones.Any(e => e.IdHabitacion == id);
        }
    }
}
