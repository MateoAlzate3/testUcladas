using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppVeterinaria.Models;

namespace WebAppVeterinaria.Controllers
{
    public class VeterinariasController : Controller
    {
        private readonly VeterinariaDbContext _context;

        public VeterinariasController(VeterinariaDbContext context)
        {
            _context = context;
        }

        // GET: Veterinarias
        public async Task<IActionResult> Index()
        {
            return View(await _context.Veterinaria.ToListAsync());
        }

        // GET: Veterinarias/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veterinaria = await _context.Veterinaria
                .FirstOrDefaultAsync(m => m.id == id);
            if (veterinaria == null)
            {
                return NotFound();
            }

            return View(veterinaria);
        }

        // GET: Veterinarias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Veterinarias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Nit,RazonSocial,Direccion,Telefono,Email,Empleados,FechaFundacion")] Veterinaria veterinaria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(veterinaria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(veterinaria);
        }

        // GET: Veterinarias/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veterinaria = await _context.Veterinaria.FindAsync(id);
            if (veterinaria == null)
            {
                return NotFound();
            }
            return View(veterinaria);
        }

        // POST: Veterinarias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("id,Nit,RazonSocial,Direccion,Telefono,Email,Empleados,FechaFundacion")] Veterinaria veterinaria)
        {
            if (id != veterinaria.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(veterinaria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VeterinariaExists(veterinaria.id))
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
            return View(veterinaria);
        }

        // GET: Veterinarias/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veterinaria = await _context.Veterinaria
                .FirstOrDefaultAsync(m => m.id == id);
            if (veterinaria == null)
            {
                return NotFound();
            }

            return View(veterinaria);
        }

        // POST: Veterinarias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var veterinaria = await _context.Veterinaria.FindAsync(id);
            if (veterinaria != null)
            {
                _context.Veterinaria.Remove(veterinaria);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VeterinariaExists(long id)
        {
            return _context.Veterinaria.Any(e => e.id == id);
        }
    }
}
