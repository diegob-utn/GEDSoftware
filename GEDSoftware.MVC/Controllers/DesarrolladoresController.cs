using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GEDSoftware.MVC.Data;
using GEDSoftware.Models.Models;

namespace GEDSoftware.MVC.Controllers
{
    public class DesarrolladoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DesarrolladoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Desarrolladores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Desarrolladores.ToListAsync());
        }

        // GET: Desarrolladores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var desarrollador = await _context.Desarrolladores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (desarrollador == null)
            {
                return NotFound();
            }

            return View(desarrollador);
        }

        // GET: Desarrolladores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Desarrolladores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Correo,Telefono")] Desarrollador desarrollador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(desarrollador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(desarrollador);
        }

        // GET: Desarrolladores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var desarrollador = await _context.Desarrolladores.FindAsync(id);
            if (desarrollador == null)
            {
                return NotFound();
            }
            return View(desarrollador);
        }

        // POST: Desarrolladores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Correo,Telefono")] Desarrollador desarrollador)
        {
            if (id != desarrollador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(desarrollador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DesarrolladorExists(desarrollador.Id))
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
            return View(desarrollador);
        }

        // GET: Desarrolladores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var desarrollador = await _context.Desarrolladores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (desarrollador == null)
            {
                return NotFound();
            }

            return View(desarrollador);
        }

        // POST: Desarrolladores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var desarrollador = await _context.Desarrolladores.FindAsync(id);
            if (desarrollador != null)
            {
                _context.Desarrolladores.Remove(desarrollador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DesarrolladorExists(int id)
        {
            return _context.Desarrolladores.Any(e => e.Id == id);
        }
    }
}
