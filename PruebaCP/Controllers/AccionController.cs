using AccesoDatos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class AccionController : Controller
    {
        private readonly IAccesoMongo _accesoMongo;

        public AccionController()
        {
            _accesoMongo = new AccesoMongo();
        }

        public IActionResult Index()
        {
            return View(_accesoMongo.ObtenerBitacoraCompleta());
        }
    }
}
