using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto.Data;
using Projeto.Models;

namespace Projeto.Controllers
{
    public class LojaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public LojaController(ApplicationDbContext context, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // GET: Loja
        public async Task<IActionResult> Index()
        {
              return _context.Itens != null ? 
                          View(await _context.Itens.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Itens'  is null.");
        }

        // GET: Loja/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Itens == null)
            {
                return NotFound();
            }

            var itens = await _context.Itens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itens == null)
            {
                return NotFound();
            }

            return View(itens);
        }

        // GET: Loja/Comprar
        public async Task<IActionResult> Comprar(int? id) {
            if (id == null || _context.Itens == null) {
                return NotFound();
            }

            var itens = await _context.Itens
                .FirstOrDefaultAsync(m => m.Id == id);

            var preco = itens.Custo;

            if (itens == null) {
                return NotFound();
            }

            return View(Index);
        }
    }
}
