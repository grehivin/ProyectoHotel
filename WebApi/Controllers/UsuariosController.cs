using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Logica;
using Entidades;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;


namespace WebApi.Controllers
{
    [Route("api/hotel")]
    [ApiController]
 

    public class UsuariosController : ControllerBase
    {
        private readonly ILogica logica_;


        //NonAction]
        public UsuariosController(ILogica logica)
        {
            logica_ = logica;
        }

        // GET: UsuariosController
        [HttpPost]
        [Route(nameof(ConsultarUsuarios))]
        [SwaggerOperation("ConsultarUsuarios")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public ActionResult<IEnumerable<Usuarios>> ConsultarUsuarios(Usuarios usuarios)
        {
            return logica_.ConsultarUsuarios(usuarios);
        }

        // POST: UsuariosController/Create
        [HttpPost]
        [Route(nameof(CrearUsuario))]
        [SwaggerOperation("CrearUsuario")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public ActionResult <bool>CrearUsuario(Usuarios usuarios)
        {

            return logica_.AgregarUsuarios(usuarios);
       
        }

        //// GET: UsuariosController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: UsuariosController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: UsuariosController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: UsuariosController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
