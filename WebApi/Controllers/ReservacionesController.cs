using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class ReservacionesController : Controller
    {
        // GET: ReservacionesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ReservacionesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReservacionesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReservacionesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReservacionesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReservacionesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReservacionesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReservacionesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
