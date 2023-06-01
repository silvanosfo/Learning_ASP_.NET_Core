using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EquiMembros2022.Data;
using EquiMembros2023.Models;

namespace EquiMembros2023.Controllers
{
    public class MembroesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MembroesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Membroes
        public async Task<IActionResult> Index()
        {
              return _context.Tmembros != null ? 
                          View(await _context.Tmembros.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Tmembros'  is null.");
        }

        // GET: Membroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tmembros == null)
            {
                return NotFound();
            }

            var membro = await _context.Tmembros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (membro == null)
            {
                return NotFound();
            }

            return View(membro);
        }

        // GET: Membroes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Membroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeMembro,EquipaId")] Membro membro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(membro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(membro);
        }

        // GET: Membroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tmembros == null)
            {
                return NotFound();
            }

            var membro = await _context.Tmembros.FindAsync(id);
            if (membro == null)
            {
                return NotFound();
            }
            return View(membro);
        }

        // POST: Membroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeMembro,EquipaId")] Membro membro)
        {
            if (id != membro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(membro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembroExists(membro.Id))
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
            return View(membro);
        }

        // GET: Membroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tmembros == null)
            {
                return NotFound();
            }

            var membro = await _context.Tmembros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (membro == null)
            {
                return NotFound();
            }

            return View(membro);
        }

        // POST: Membroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tmembros == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Tmembros'  is null.");
            }
            var membro = await _context.Tmembros.FindAsync(id);
            if (membro != null)
            {
                _context.Tmembros.Remove(membro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembroExists(int id)
        {
          return (_context.Tmembros?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
