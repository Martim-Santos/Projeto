using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto.Data;
using Projeto.Models;

namespace Projeto.Controllers {
    public class JogadorsController : Controller {

        private readonly ApplicationDbContext _context;

        public JogadorsController(ApplicationDbContext context) {
            _context = context;
        }

        // GET: Jogador
        public async Task<IActionResult> Index() {
            return View(await _context.Jogador.ToListAsync());
        }

        // GET: Jogador/Details/5
        public async Task<IActionResult> Details(int? id) {
            if (id == null || _context.Jogador == null) {
                return NotFound();
            }

            var Jogador = await _context.Jogador
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Jogador == null) {
                return NotFound();
            }

            return View(Jogador);
        }

        // GET: Jogador/Create
        public IActionResult Create() {
            return View();
        }

        // POST: Jogador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Email,Password")] Jogador Jogador) {
            if (ModelState.IsValid) {
                _context.Add(Jogador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Jogador);
        }

        // GET: Jogador/Edit/5
        public async Task<IActionResult> Edit(int? id) {
            if (id == null || _context.Jogador == null) {
                return NotFound();
            }

            var Jogador = await _context.Jogador.FindAsync(id);
            if (Jogador == null) {
                return NotFound();
            }
            return View(Jogador);
        }

        // POST: Jogador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,Email,Password")] Jogador Jogador) {
            if (id != Jogador.Id) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(Jogador);
                    await _context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException) {
                    if (!JogadorExists(Jogador.Id)) {
                        return NotFound();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(Jogador);
        }

        // GET: Jogador/Delete/5
        public async Task<IActionResult> Delete(int? id) {
            if (id == null || _context.Jogador == null) {
                return NotFound();
            }

            var Jogador = await _context.Jogador
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Jogador == null) {
                return NotFound();
            }

            return View(Jogador);
        }

        // POST: Jogador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            if (_context.Jogador == null) {
                return Problem("Entity set 'ApplicationDbContext.Jogador'  is null.");
            }
            var Jogador = await _context.Jogador.FindAsync(id);
            if (Jogador != null) {
                _context.Jogador.Remove(Jogador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JogadorExists(int id) {
            return _context.Jogador.Any(e => e.Id == id);
        }
    }
}
