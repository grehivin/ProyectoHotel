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
    public class ClientesController : Controller
    {
        private readonly HotelContext _context;
        private readonly IRegistroActividad _registroActividad;

        public ClientesController() // (HotelContext context)
        {
            _context = new HotelContext(); // context;
            _registroActividad = new RegistroActividad();
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clientes.ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                _registroActividad.AgregarRegistro(new Actividad("ver", HttpContext.User.Claims.First().Value, "fallido"), new Clientes());

                return NotFound();
            }

            var clientes = await _context.Clientes
                .FirstOrDefaultAsync(m => m.IdCliente == id);
            if (clientes == null)
            {
                _registroActividad.AgregarRegistro(new Actividad("ver", HttpContext.User.Claims.First().Value, "fallido"), clientes);

                return NotFound();
            }

            _registroActividad.AgregarRegistro(new Actividad("ver", HttpContext.User.Claims.First().Value, "completado"), clientes);

            return View(clientes);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCliente,NombreCompleto,CorreoElectronico,TelefonoContacto,ClienteActivo,Pais,Provincia,Canton,Distrito,CodigoPostal,Direccion")] Clientes clientes)
        {

            if (ModelState.IsValid)
            {
                _context.Add(clientes);
                await _context.SaveChangesAsync();

                _registroActividad.AgregarRegistro(new Actividad("crear", HttpContext.User.Claims.First().Value, "completado"), clientes);

                return RedirectToAction(nameof(Index));
            }

            _registroActividad.AgregarRegistro(new Actividad("crear", HttpContext.User.Claims.First().Value, "fallido"), clientes);

            return View(clientes);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                _registroActividad.AgregarRegistro(new Actividad("editar", HttpContext.User.Claims.First().Value, "fallido"), new Clientes());

                return NotFound();
            }

            var clientes = await _context.Clientes.FindAsync(id);
            if (clientes == null)
            {
                _registroActividad.AgregarRegistro(new Actividad("editar", HttpContext.User.Claims.First().Value, "fallido"), clientes);

                return NotFound();
            }

            return View(clientes);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("IdCliente,NombreCompleto,CorreoElectronico,TelefonoContacto,ClienteActivo,Pais,Provincia,Canton,Distrito,CodigoPostal,Direccion")] Clientes clientes)
        {
            if (id != clientes.IdCliente)
            {
                _registroActividad.AgregarRegistro(new Actividad("editar", HttpContext.User.Claims.First().Value, "fallido"), clientes);

                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientesExists(clientes.IdCliente))
                    {
                        _registroActividad.AgregarRegistro(new Actividad("editar", HttpContext.User.Claims.First().Value, "fallido"), clientes);

                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                _registroActividad.AgregarRegistro(new Actividad("editar", HttpContext.User.Claims.First().Value, "completado"), clientes);

                return RedirectToAction(nameof(Index));
            }

            _registroActividad.AgregarRegistro(new Actividad("editar", HttpContext.User.Claims.First().Value, "fallido"), clientes);

            return View(clientes);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                _registroActividad.AgregarRegistro(new Actividad("borrar", HttpContext.User.Claims.First().Value, "fallido"), new Clientes());

                return NotFound();
            }

            var clientes = await _context.Clientes
                .FirstOrDefaultAsync(m => m.IdCliente == id);
            if (clientes == null)
            {
                _registroActividad.AgregarRegistro(new Actividad("borrar", HttpContext.User.Claims.First().Value, "fallido"), clientes);

                return NotFound();
            }

            return View(clientes);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var clientes = await _context.Clientes.FindAsync(id);
            _context.Clientes.Remove(clientes);
            await _context.SaveChangesAsync();

            _registroActividad.AgregarRegistro(new Actividad("borrar", HttpContext.User.Claims.First().Value, "completado"), clientes);

            return RedirectToAction(nameof(Index));
        }

        private bool ClientesExists(decimal id)
        {
            return _context.Clientes.Any(e => e.IdCliente == id);
        }
    }
}
