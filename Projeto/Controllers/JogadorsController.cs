using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto.Data;
using Projeto.Models;

namespace Projeto.Controllers {
    public class JogadorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JogadorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AumentaPAsync() {
            var j = await _context.Jogador.FindAsync();
            if(j != null) {
                j.Score += j.Click;
            }
        }

        // GET: Jogadors
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Jogador.Include(j => j.Grupo);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Jogadors/Details/1
        public async Task<IActionResult> Details(int? Id)
        {
            if (Id == null || _context.Jogador == null)
            {
                return NotFound();
            }

            var jogador = await _context.Jogador
                .Include(j => j.Grupo)
                .FirstOrDefaultAsync(m => m.Id == Id);
            if (jogador == null)
            {
                return NotFound();
            }

            return View(jogador);
        }

        // GET: Jogadors/Edit/1
        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id == null || _context.Jogador == null)
            {
                return NotFound();
            }

            var jogador = await _context.Jogador.FindAsync(Id);
            if (jogador == null)
            {
                return NotFound();
            }
            ViewData["GrupoFK"] = new SelectList(_context.Grupo, "Id", "Name", jogador.GrupoFK);
            return View(jogador);
        }

        // POST: Jogadors/Edit/1
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, [Bind("Id,Nome,Email,Click,Score,GrupoFK")] Jogador jogador)
        {
            if (Id != jogador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jogador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JogadorExists(jogador.Id))
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
            ViewData["GrupoFK"] = new SelectList(_context.Grupo, "Id", "Name", jogador.GrupoFK);
            return View(jogador);
        }

        // GET: Jogadors/Delete/1
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null || _context.Jogador == null)
            {
                return NotFound();
            }

            var jogador = await _context.Jogador
                .Include(j => j.Grupo)
                .FirstOrDefaultAsync(m => m.Id == Id);
            if (jogador == null)
            {
                return NotFound();
            }

            return View(jogador);
        }

        // POST: Jogadors/Delete/1
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            if (_context.Jogador == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Jogador'  is null.");
            }
            var jogador = await _context.Jogador.FindAsync(Id);
            if (jogador != null)
            {
                _context.Jogador.Remove(jogador);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JogadorExists(int Id)
        {
          return (_context.Jogador.Any(e => e.Id == Id));
        }
    }
}
