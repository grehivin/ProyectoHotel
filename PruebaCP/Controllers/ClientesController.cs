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

            if (ModelState.IsValid)
            {
                bool status = false;
                string accion_s = "CrearCliente";
                try
                {
                    _context.Add(clientes);
                    await _context.SaveChangesAsync();
                    status = true;
                    AccionesLogs(accion_s, accion, clientes, status);
                    return RedirectToAction(nameof(Index));

                }
                catch (Exception)
                {
                    AccionesLogs(accion_s, accion, clientes, status);
                }
                finally
                {
                    AccionesLogs(accion_s, accion, clientes, status);

                }                           
                
            }
            return View(clientes);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(decimal? id, Accion accion)
        {
            bool status = false;
            string accion_s = "EditarCliente";
            if (id == null)
            {
                AccionesLogs(accion_s, accion, null, status);
                return NotFound();
            }

            var clientes = await _context.Clientes.FindAsync(id);
            AccionesLogs(accion_s,accion, clientes, status);
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
            if (id != clientes.IdCliente)
            {
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
        public async Task<IActionResult> Delete(decimal? id, Accion accion)
        {
            bool status = false;
            string accion_s = "EliminarCliente";
            if (id == null)
            {
                AccionesLogs(accion_s, accion, null, status);
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
        public async Task<IActionResult> DeleteConfirmed(decimal id, Accion accion)
        {
            bool status = false;
            string accion_s = "EliminarCliente";
            try
            {
                var clientes = await _context.Clientes.FindAsync(id);
                _context.Clientes.Remove(clientes);
                await _context.SaveChangesAsync();
                status = true;
                AccionesLogs(accion_s, accion, clientes, status);
                return RedirectToAction(nameof(Index));

            }
            catch (Exception)
            {

                AccionesLogs(accion_s, accion, null, status);
                return RedirectToAction(nameof(Index));

            }
            finally
            {
                AccionesLogs(accion_s, accion, null, status);


            }


        }

        private bool ClientesExists(decimal id)
        {
            return _context.Clientes.Any(e => e.IdCliente == id);
        }

        public void AccionesLogs(string accion, Accion P_accion, object obj,bool status)
        {

            P_accion.AccionRealizada = accion;
            P_accion.Objeto = obj.GetType().ToString();
            P_accion.Instancia = "";
            P_accion.Usuario = Environment.UserName;
            P_accion.Resultado = status.ToString();
            P_accion.Momento = DateTime.Now;
            accesoMongo.AgregarRegistroBitacora(P_accion);

        }
    }
}
