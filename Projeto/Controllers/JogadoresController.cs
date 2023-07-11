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

        // devolve o Grupo com esse Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Jogador>> Get(int id) {

            var user = await _context.Jogador.FindAsync(id);

            if (user == null) return BadRequest("Jogador not found :(");

            return Ok(await _context.Jogador.FindAsync(id));
        }

        // devolve a lista de itens do jogador
        [HttpGet("itens/{id}")]
        public async Task<ActionResult<List<Itens>>> GetUserItens(int Id) {

            var user = await _context.Jogador.FindAsync(Id);

            if (user == null) return BadRequest("user not found :(");

            var item = user.ListaItens;

            return Ok(item);
        }


    }

}
