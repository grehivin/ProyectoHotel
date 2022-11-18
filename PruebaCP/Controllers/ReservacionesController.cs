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
    public class ReservacionesController : Controller
    {
        private readonly HotelContext _context;

        public ReservacionesController() // (HotelContext context)
        {
            _context = new HotelContext(); // context;
        }

        // GET: Reservaciones
        public async Task<IActionResult> Index()
        {
            var hotelContext = _context.Reservaciones.Include(r => r.IdClienteNavigation).Include(r => r.IdHabitacionNavigation);
            return View(await hotelContext.ToListAsync());
        }

        // GET: Reservaciones/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaciones = await _context.Reservaciones
                .Include(r => r.IdClienteNavigation)
                .Include(r => r.IdHabitacionNavigation)
                .FirstOrDefaultAsync(m => m.IdReservacion == id);
            if (reservaciones == null)
            {
                return NotFound();
            }

            return View(reservaciones);
        }

        // GET: Reservaciones/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "CodigoPostal");
            ViewData["IdHabitacion"] = new SelectList(_context.Habitaciones, "IdHabitacion", "IdHabitacion");
            return View();
        }

        // POST: Reservaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdReservacion,IdCliente,IdHabitacion,CantidadAcompanantes,FechaEntrada,FechaSalida,EstadoReservacion,CostoReservacion,CostoReservacionPagado")] Reservaciones reservaciones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservaciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "CodigoPostal", reservaciones.IdCliente);
            ViewData["IdHabitacion"] = new SelectList(_context.Habitaciones, "IdHabitacion", "IdHabitacion", reservaciones.IdHabitacion);
            return View(reservaciones);
        }

        // GET: Reservaciones/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaciones = await _context.Reservaciones.FindAsync(id);
            if (reservaciones == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "CodigoPostal", reservaciones.IdCliente);
            ViewData["IdHabitacion"] = new SelectList(_context.Habitaciones, "IdHabitacion", "IdHabitacion", reservaciones.IdHabitacion);
            return View(reservaciones);
        }

        // POST: Reservaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("IdReservacion,IdCliente,IdHabitacion,CantidadAcompanantes,FechaEntrada,FechaSalida,EstadoReservacion,CostoReservacion,CostoReservacionPagado")] Reservaciones reservaciones)
        {
            if (id != reservaciones.IdReservacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservaciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservacionesExists(reservaciones.IdReservacion))
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
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "CodigoPostal", reservaciones.IdCliente);
            ViewData["IdHabitacion"] = new SelectList(_context.Habitaciones, "IdHabitacion", "IdHabitacion", reservaciones.IdHabitacion);
            return View(reservaciones);
        }

        // GET: Reservaciones/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaciones = await _context.Reservaciones
                .Include(r => r.IdClienteNavigation)
                .Include(r => r.IdHabitacionNavigation)
                .FirstOrDefaultAsync(m => m.IdReservacion == id);
            if (reservaciones == null)
            {
                return NotFound();
            }

            return View(reservaciones);
        }

        // POST: Reservaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var reservaciones = await _context.Reservaciones.FindAsync(id);
            _context.Reservaciones.Remove(reservaciones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservacionesExists(decimal id)
        {
            return _context.Reservaciones.Any(e => e.IdReservacion == id);
        }
    }
}
