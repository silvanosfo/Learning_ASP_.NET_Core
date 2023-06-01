using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using P3CoreSilvano.Data;
using P3CoreSilvano.Models;

namespace P3CoreSilvano.Controllers
{
    public class ReuniaosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReuniaosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reuniaos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TReuniaos.Include(r => r.Cliente).Include(r => r.Funcionario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Reuniaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TReuniaos == null)
            {
                return NotFound();
            }

            var reuniao = await _context.TReuniaos
                .Include(r => r.Cliente)
                .Include(r => r.Funcionario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reuniao == null)
            {
                return NotFound();
            }

            return View(reuniao);
        }

        // GET: Reuniaos/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.TClientes, "Id", "NomeCliente");
            ViewData["FuncionarioId"] = new SelectList(_context.TFuncionarios, "Id", "NomeFunc");
            return View();
        }

        // POST: Reuniaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Data,Duracao,Resumo,ClienteId,FuncionarioId")] Reuniao reuniao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reuniao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.TClientes, "Id", "NomeCliente", reuniao.ClienteId);
            ViewData["FuncionarioId"] = new SelectList(_context.TFuncionarios, "Id", "NomeFunc", reuniao.FuncionarioId);
            return View(reuniao);
        }

        // GET: Reuniaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TReuniaos == null)
            {
                return NotFound();
            }

            var reuniao = await _context.TReuniaos.FindAsync(id);
            if (reuniao == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.TClientes, "Id", "NomeCliente", reuniao.ClienteId);
            ViewData["FuncionarioId"] = new SelectList(_context.TFuncionarios, "Id", "NomeFunc", reuniao.FuncionarioId);
            return View(reuniao);
        }

        // POST: Reuniaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Data,Duracao,Resumo,ClienteId,FuncionarioId")] Reuniao reuniao)
        {
            if (id != reuniao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reuniao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReuniaoExists(reuniao.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.TClientes, "Id", "NomeCliente", reuniao.ClienteId);
            ViewData["FuncionarioId"] = new SelectList(_context.TFuncionarios, "Id", "NomeFunc", reuniao.FuncionarioId);
            return View(reuniao);
        }

        // GET: Reuniaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TReuniaos == null)
            {
                return NotFound();
            }

            var reuniao = await _context.TReuniaos
                .Include(r => r.Cliente)
                .Include(r => r.Funcionario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reuniao == null)
            {
                return NotFound();
            }

            return View(reuniao);
        }

        // POST: Reuniaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TReuniaos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TReuniaos'  is null.");
            }
            var reuniao = await _context.TReuniaos.FindAsync(id);
            if (reuniao != null)
            {
                _context.TReuniaos.Remove(reuniao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReuniaoExists(int id)
        {
          return (_context.TReuniaos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
