using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto.Areas.Identity.Pages.Account;
using Projeto.Data;
using Projeto.Models;

namespace Projeto.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class JogadoresController : ControllerBase {

        private readonly ApplicationDbContext _context;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public JogadoresController(ApplicationDbContext context, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager) {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // devolve a lista de jogadores
        [HttpGet]
        public async Task<ActionResult<List<Jogador>>> Get() {

            var Jogadores = _context.Jogador.ToList();

            return Ok(Jogadores);
        }

        

    }

}
