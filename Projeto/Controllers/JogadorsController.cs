using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto.Data;
using Projeto.Models;

namespace Projeto.Controllers
{
    public class JogadorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JogadorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Jogadors
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Users.Include(j => j.Grupo);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Jogadors/Details/5
        public async Task<IActionResult> Details(string? Id)
        {
            if (Id == null || _context.Users == null)
            {
                return NotFound();
            }

            var jogador = await _context.Users
                .Include(j => j.Grupo)
                .FirstOrDefaultAsync(m => m.Id == Id);
            if (jogador == null)
            {
                return NotFound();
            }

            return View(jogador);
        }

        // GET: Jogadors/Create
        public IActionResult Create()
        {
            ViewData["GrupoFK"] = new SelectList(_context.Grupo, "Id", "Id");
            return View();
        }

        // POST: Jogadors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Email,PasswordHash,GrupoFK")] Jogador jogador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jogador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GrupoFK"] = new SelectList(_context.Grupo, "Id", "Id", jogador.GrupoFK);
            return View(jogador);
        }

        // GET: Jogadors/Edit/5
        public async Task<IActionResult> Edit(string? Id)
        {
            if (Id == null || _context.Users == null)
            {
                return NotFound();
            }

            var jogador = await _context.Users.FindAsync(Id);
            if (jogador == null)
            {
                return NotFound();
            }
            ViewData["GrupoFK"] = new SelectList(_context.Grupo, "Id", "Id", jogador.GrupoFK);
            return View(jogador);
        }

        // POST: Jogadors/Edit/0
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string Id, [Bind("Id,UserName,Email,PasswordHash,Click,Score,GrupoFK")] Jogador jogador)
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
                    _context.SaveChanges();
                    //await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JogadorExists(jogador.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        //throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["GrupoFK"] = new SelectList(_context.Grupo, "Id", "Id", jogador.GrupoFK);
            return View(jogador);
        }

        // GET: Jogadors/Delete/5
        public async Task<IActionResult> Delete(string? Id)
        {
            if (Id == null || _context.Users == null)
            {
                return NotFound();
            }

            var jogador = await _context.Users
                .Include(j => j.Grupo)
                .FirstOrDefaultAsync(m => m.Id == Id);
            if (jogador == null)
            {
                return NotFound();
            }

            return View(jogador);
        }

        // POST: Jogadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string Id)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Jogador'  is null.");
            }
            var jogador = await _context.Users.FindAsync(Id);
            if (jogador != null)
            {
                _context.Users.Remove(jogador);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JogadorExists(string Id)
        {
          return (_context.Users?.Any(e => e.Id == Id)).GetValueOrDefault();
        }
    }
}
