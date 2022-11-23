using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AccesoDatos;
using Entidades;
using System.Reflection;

namespace WebAPI.Controllers
{
    public class ClientesController : Controller
    {
        private readonly HotelContext _context;
        private readonly IAccesoMongo accesoMongo;

        public ClientesController() // (HotelContext context)
        {
            _context = new HotelContext(); // context;
            accesoMongo = new AccesoMongo();
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
                return NotFound();
            }

            var clientes = await _context.Clientes
                .FirstOrDefaultAsync(m => m.IdCliente == id);
            if (clientes == null)
            {
                return NotFound();
            }

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
        public async Task<IActionResult> Create([Bind("IdCliente,NombreCompleto,CorreoElectronico,TelefonoContacto,ClienteActivo,Pais,Provincia,Canton,Distrito,CodigoPostal,Direccion")] Clientes clientes, Accion accion)
        {
            IAccesoMongo bitacora = new AccesoMongo();

            if (ModelState.IsValid)
            {
                _context.Add(clientes);
                await _context.SaveChangesAsync();
                bitacora.AgregarRegistroBitacora(new Accion()
                {
                    AccionRealizada = "CrearCliente",
                    Objeto = nameof(clientes),
                    Instancia = clientes.GetType().ToString(),
                    Usuario = HttpContext.User.Claims.First().Value,
                    Resultado = "Completado",
                    Momento = DateTime.Now

                });
                return RedirectToAction(nameof(Index));
 

                         
                
            }
            bitacora.AgregarRegistroBitacora(new Accion()
            {
                AccionRealizada = "CrearCliente",
                Objeto = nameof(clientes),
                Instancia = clientes.GetType().ToString(),
                Usuario = HttpContext.User.Claims.First().Value,
                Resultado = "Fallido",
                Momento = DateTime.Now

            });
            return View(clientes);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = await _context.Clientes.FindAsync(id);
            if (clientes == null)
            {
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
            IAccesoMongo bitacora = new AccesoMongo();
            if (id != clientes.IdCliente)
            {
                bitacora.AgregarRegistroBitacora(new Accion()
                {
                    AccionRealizada = "EditarCliente",
                    Objeto = nameof(clientes),
                    Instancia = clientes.GetType().ToString(),
                    Usuario = HttpContext.User.Claims.First().Value,
                    Resultado = "Cliente no encontrado",
                    Momento = DateTime.Now

                });
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientes);
                    await _context.SaveChangesAsync();
                    bitacora.AgregarRegistroBitacora(new Accion()
                    {
                        AccionRealizada = "EditarCliente",
                        Objeto = nameof(clientes),
                        Instancia = clientes.GetType().ToString(),
                        Usuario = HttpContext.User.Claims.First().Value,
                        Resultado = "Completado",
                        Momento = DateTime.Now

                    });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientesExists(clientes.IdCliente))
                    {
                        bitacora.AgregarRegistroBitacora(new Accion()
                        {
                            AccionRealizada = "EditarCliente",
                            Objeto = nameof(clientes),
                            Instancia = clientes.GetType().ToString(),
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
            return View(clientes);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = await _context.Clientes
                .FirstOrDefaultAsync(m => m.IdCliente == id);
            if (clientes == null)
            {
                return NotFound();
            }

            return View(clientes);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            IAccesoMongo bitacora = new AccesoMongo();
            var clientes = await _context.Clientes.FindAsync(id);
            _context.Clientes.Remove(clientes);
            await _context.SaveChangesAsync();
            bitacora.AgregarRegistroBitacora(new Accion()
            {
                AccionRealizada = "EliminarCliente",
                Objeto = nameof(clientes),
                Instancia = clientes.GetType().ToString(),
                Usuario = HttpContext.User.Claims.First().Value,
                Resultado = "Completado",
                Momento = DateTime.Now

            });
            return RedirectToAction(nameof(Index));
        }

        private bool ClientesExists(decimal id)
        {
            return _context.Clientes.Any(e => e.IdCliente == id);
        }


    }
}
