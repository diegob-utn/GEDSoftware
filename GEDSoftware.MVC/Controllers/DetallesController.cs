using GEDSoftware.MVC.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GEDSoftware.MVC.Controllers
{
    public class DetallesController:Controller
    {
        private readonly ApplicationDbContext _context;

        public DetallesController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: DetallesController
        public ActionResult Index()
        {
            return View();
        }


        public async Task<ActionResult> Reporte(int id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var desarrollador = await _context.Desarrolladores
                .FirstOrDefaultAsync(m => m.Id == id);
            if(desarrollador == null)
            {
                return NotFound();
            }

            return View(desarrollador);

        }

        // GET: DetallesController/Details/5
        public ActionResult Details(int id)
        {

            return View();

        }

        // GET: DetallesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DetallesController/Create
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

        // GET: DetallesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DetallesController/Edit/5
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

        // GET: DetallesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DetallesController/Delete/5
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
