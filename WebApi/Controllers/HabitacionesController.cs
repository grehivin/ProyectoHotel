using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class HabitacionesController : Controller
    {
        // GET: HabitacionesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: HabitacionesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HabitacionesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HabitacionesController/Create
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

        // GET: HabitacionesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HabitacionesController/Edit/5
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

        // GET: HabitacionesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HabitacionesController/Delete/5
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
