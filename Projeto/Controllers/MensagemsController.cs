using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto.Data;
using Projeto.Models;

namespace Projeto.Controllers {
    public class MensagemsController : Controller {
        private readonly ApplicationDbContext _context;

        public MensagemsController(ApplicationDbContext context) {
            _context = context;
        }

        // GET: Mensagems
        public async Task<IActionResult> Index() {
            var applicationDbContext = _context.Mensagem.Include(m => m.Grupo).Include(m => m.Jogador);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Mensagems/Details/5
        public async Task<IActionResult> Details(int? id) {
            if (id == null || _context.Mensagem == null) {
                return NotFound();
            }

            var mensagem = await _context.Mensagem
                .Include(m => m.Grupo)
                .Include(m => m.Jogador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mensagem == null) {
                return NotFound();
            }

            return View(mensagem);
        }

        // GET: Mensagems/Create
        public IActionResult Create() {
            ViewData["GrupoFK"] = new SelectList(_context.Grupo, "Id", "Name");
            ViewData["JogadorFK"] = new SelectList(_context.Users, "Id", "UserName");
            return View();
        }

        // POST: Mensagems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Frase,Data,JogadorFK,GrupoFK")] Mensagem mensagem) {
            if (mensagem.GrupoFK == 0) {
                if (mensagem.JogadorFK == 0) {
                    ModelState.AddModelError("", "Tem de escolher para quem vai enviar.");
                }
                mensagem.GrupoFK = null;
            }
            if (mensagem.JogadorFK == 0) {
                mensagem.JogadorFK = null;
            }
            if (ModelState.IsValid) {
                    _context.Add(mensagem);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
            }
            ViewData["GrupoFK"] = new SelectList(_context.Grupo, "Id", "Name", mensagem.GrupoFK);
            ViewData["JogadorFK"] = new SelectList(_context.Users, "Id", "UserName", mensagem.JogadorFK);
            return View(mensagem);
        }
    

        // GET: Mensagems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Mensagem == null)
            {
                return NotFound();
            }

            var mensagem = await _context.Mensagem.FindAsync(id);
            if (mensagem == null)
            {
                return NotFound();
            }
            ViewData["GrupoFK"] = new SelectList(_context.Grupo, "Id", "Name", mensagem.GrupoFK);
            ViewData["JogadorFK"] = new SelectList(_context.Users, "Id", "UserName", mensagem.JogadorFK);
            return View(mensagem);
        }

        // POST: Mensagems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Frase,Data,JogadorFK,GrupoFK")] Mensagem mensagem)
        {
            if (id != mensagem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    mensagem.Data = DateTime.Now;
                    _context.Update(mensagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MensagemExists(mensagem.Id))
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
            ViewData["GrupoFK"] = new SelectList(_context.Grupo, "Id", "Name", mensagem.GrupoFK);
            ViewData["JogadorFK"] = new SelectList(_context.Users, "Id", "UserName", mensagem.JogadorFK);
            return View(mensagem);
        }

        // GET: Mensagems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Mensagem == null)
            {
                return NotFound();
            }

            var mensagem = await _context.Mensagem
                .Include(m => m.Grupo)
                .Include(m => m.Jogador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mensagem == null)
            {
                return NotFound();
            }

            return View(mensagem);
        }

        // POST: Mensagems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Mensagem == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Mensagem'  is null.");
            }
            var mensagem = await _context.Mensagem.FindAsync(id);
            if (mensagem != null)
            {
                _context.Mensagem.Remove(mensagem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MensagemExists(int id)
        {
          return (_context.Mensagem?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
