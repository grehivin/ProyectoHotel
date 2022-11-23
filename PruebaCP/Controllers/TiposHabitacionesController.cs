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
    public class TiposHabitacionesController : Controller
    {
        private readonly HotelContext _context;
        private readonly IRegistroActividad _registroActividad;

        public TiposHabitacionesController() // (HotelContext context)
        {
            _context = new HotelContext(); // context;
            _registroActividad = new RegistroActividad();
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
                _registroActividad.AgregarRegistro(new Actividad("ver", HttpContext.User.Claims.First().Value, "fallido"), new TiposHabitaciones());

                return NotFound();
            }

            var tiposHabitaciones = await _context.TiposHabitaciones
                .FirstOrDefaultAsync(m => m.IdTipoHabitacion == id);
            if (tiposHabitaciones == null)
            {
                _registroActividad.AgregarRegistro(new Actividad("ver", HttpContext.User.Claims.First().Value, "fallido"), tiposHabitaciones);

                return NotFound();
            }

            _registroActividad.AgregarRegistro(new Actividad("ver", HttpContext.User.Claims.First().Value, "completado"), tiposHabitaciones);

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

                _registroActividad.AgregarRegistro(new Actividad("crear", HttpContext.User.Claims.First().Value, "completado"), tiposHabitaciones);

                return RedirectToAction(nameof(Index));
            }
            _registroActividad.AgregarRegistro(new Actividad("crear", HttpContext.User.Claims.First().Value, "fallido"), tiposHabitaciones);

            return View(tiposHabitaciones);
        }

        // GET: TiposHabitaciones/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                _registroActividad.AgregarRegistro(new Actividad("editar", HttpContext.User.Claims.First().Value, "fallido"), new TiposHabitaciones());

                return NotFound();
            }

            var tiposHabitaciones = await _context.TiposHabitaciones.FindAsync(id);
            if (tiposHabitaciones == null)
            {
                _registroActividad.AgregarRegistro(new Actividad("editar", HttpContext.User.Claims.First().Value, "fallido"), tiposHabitaciones);

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
                _registroActividad.AgregarRegistro(new Actividad("editar", HttpContext.User.Claims.First().Value, "fallido"), tiposHabitaciones);

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
                        _registroActividad.AgregarRegistro(new Actividad("editar", HttpContext.User.Claims.First().Value, "fallido"), tiposHabitaciones);

                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                _registroActividad.AgregarRegistro(new Actividad("editar", HttpContext.User.Claims.First().Value, "completado"), tiposHabitaciones);

                return RedirectToAction(nameof(Index));
            }
            _registroActividad.AgregarRegistro(new Actividad("editar", HttpContext.User.Claims.First().Value, "fallido"), tiposHabitaciones);

            return View(tiposHabitaciones);
        }

        // GET: TiposHabitaciones/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                _registroActividad.AgregarRegistro(new Actividad("borrar", HttpContext.User.Claims.First().Value, "fallido"), new TiposHabitaciones());

                return NotFound();
            }

            var tiposHabitaciones = await _context.TiposHabitaciones
                .FirstOrDefaultAsync(m => m.IdTipoHabitacion == id);
            if (tiposHabitaciones == null)
            {
                _registroActividad.AgregarRegistro(new Actividad("borrar", HttpContext.User.Claims.First().Value, "fallido"), tiposHabitaciones);

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

            _registroActividad.AgregarRegistro(new Actividad("borrar", HttpContext.User.Claims.First().Value, "completado"), tiposHabitaciones);

            return RedirectToAction(nameof(Index));
        }

        private bool TiposHabitacionesExists(decimal id)
        {
            return _context.TiposHabitaciones.Any(e => e.IdTipoHabitacion == id);
        }
    }
}
