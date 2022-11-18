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
    public class TiposHabitacionesController : Controller
    {
        private readonly HotelContext _context;

        public TiposHabitacionesController() // (HotelContext context)
        {
            _context = new HotelContext(); // context;
        }

        // GET: TiposHabitaciones
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposHabitaciones.ToListAsync());
        }

        // GET: TiposHabitaciones/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposHabitaciones = await _context.TiposHabitaciones
                .FirstOrDefaultAsync(m => m.IdTipoHabitacion == id);
            if (tiposHabitaciones == null)
            {
                return NotFound();
            }

            return View(tiposHabitaciones);
        }

        // GET: TiposHabitaciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposHabitaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoHabitacion,Descripcion,PrecioNoche")] TiposHabitaciones tiposHabitaciones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiposHabitaciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiposHabitaciones);
        }

        // GET: TiposHabitaciones/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposHabitaciones = await _context.TiposHabitaciones.FindAsync(id);
            if (tiposHabitaciones == null)
            {
                return NotFound();
            }
            return View(tiposHabitaciones);
        }

        // POST: TiposHabitaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("IdTipoHabitacion,Descripcion,PrecioNoche")] TiposHabitaciones tiposHabitaciones)
        {
            if (id != tiposHabitaciones.IdTipoHabitacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiposHabitaciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiposHabitacionesExists(tiposHabitaciones.IdTipoHabitacion))
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
            return View(tiposHabitaciones);
        }

        // GET: TiposHabitaciones/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposHabitaciones = await _context.TiposHabitaciones
                .FirstOrDefaultAsync(m => m.IdTipoHabitacion == id);
            if (tiposHabitaciones == null)
            {
                return NotFound();
            }

            return View(tiposHabitaciones);
        }

        // POST: TiposHabitaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var tiposHabitaciones = await _context.TiposHabitaciones.FindAsync(id);
            _context.TiposHabitaciones.Remove(tiposHabitaciones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiposHabitacionesExists(decimal id)
        {
            return _context.TiposHabitaciones.Any(e => e.IdTipoHabitacion == id);
        }
    }
}
