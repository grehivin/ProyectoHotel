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
            IAccesoMongo bitacora = new AccesoMongo();

            if (ModelState.IsValid)
            {
                _context.Add(tiposHabitaciones);
                await _context.SaveChangesAsync();
                bitacora.AgregarRegistroBitacora(new Accion()
                {
                    AccionRealizada = "CrearTipoHabitacion",
                    Objeto = nameof(tiposHabitaciones),
                    Instancia = tiposHabitaciones.GetType().ToString(),
                    Usuario = HttpContext.User.Claims.First().Value,
                    Resultado = "Completado",
                    Momento = DateTime.Now

                });
                return RedirectToAction(nameof(Index));
            }
            bitacora.AgregarRegistroBitacora(new Accion()
            {
                AccionRealizada = "CrearTipoHabitacion",
                Objeto = nameof(tiposHabitaciones),
                Instancia = tiposHabitaciones.GetType().ToString(),
                Usuario = HttpContext.User.Claims.First().Value,
                Resultado = "Fallido",
                Momento = DateTime.Now

            });
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
            IAccesoMongo bitacora = new AccesoMongo();
            if (id != tiposHabitaciones.IdTipoHabitacion)
            {
                bitacora.AgregarRegistroBitacora(new Accion()
                {
                    AccionRealizada = "EditarTipoHabitacion",
                    Objeto = nameof(tiposHabitaciones),
                    Instancia = tiposHabitaciones.GetType().ToString(),
                    Usuario = HttpContext.User.Claims.First().Value,
                    Resultado = "TipoHabitacion no encontrado",
                    Momento = DateTime.Now

                });
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiposHabitaciones);
                    await _context.SaveChangesAsync();
                    bitacora.AgregarRegistroBitacora(new Accion()
                    {
                        AccionRealizada = "EditarTipoHabitacion",
                        Objeto = nameof(tiposHabitaciones),
                        Instancia = tiposHabitaciones.GetType().ToString(),
                        Usuario = HttpContext.User.Claims.First().Value,
                        Resultado = "Completado",
                        Momento = DateTime.Now

                    });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiposHabitacionesExists(tiposHabitaciones.IdTipoHabitacion))
                    {
                        bitacora.AgregarRegistroBitacora(new Accion()
                        {
                            AccionRealizada = "EditarTipoHabitacion",
                            Objeto = nameof(tiposHabitaciones),
                            Instancia = tiposHabitaciones.GetType().ToString(),
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
            IAccesoMongo bitacora = new AccesoMongo();
            var tiposHabitaciones = await _context.TiposHabitaciones.FindAsync(id);
            _context.TiposHabitaciones.Remove(tiposHabitaciones);
            await _context.SaveChangesAsync();
            bitacora.AgregarRegistroBitacora(new Accion()
            {
                AccionRealizada = "EliminarTipoHabitacion",
                Objeto = nameof(tiposHabitaciones),
                Instancia = tiposHabitaciones.GetType().ToString(),
                Usuario = HttpContext.User.Claims.First().Value,
                Resultado = "Completado",
                Momento = DateTime.Now

            });
            return RedirectToAction(nameof(Index));
        }

        private bool TiposHabitacionesExists(decimal id)
        {
            return _context.TiposHabitaciones.Any(e => e.IdTipoHabitacion == id);
        }
    }
}
