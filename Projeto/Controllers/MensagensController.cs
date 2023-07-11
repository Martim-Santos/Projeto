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
    public class MensagensController : ControllerBase {

        private readonly ApplicationDbContext _context;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public MensagensController(ApplicationDbContext context, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager) {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // devolve a lista de Mensagens
        [HttpGet]
        public async Task<ActionResult<List<Mensagem>>> Get() {

            var Mensagems = _context.Mensagem.ToList();

            return Ok(Mensagems);
        }

        // devolve a lista de jogadores da Mensagem
        [HttpGet("User/{id}")]
        public async Task<ActionResult<List<Mensagem>>> GetMsgUser(int Id) {

            var msg = await _context.Mensagem.FindAsync(Id);

            if (msg == null) return BadRequest("Msg not found :(");

            var w = msg.JogadorFK;

            if (w == null) return BadRequest("User not found :(");

            var r = await _context.Jogador.FindAsync(w);

            var t = r.Nome;

            return Ok(t);
        }

        // devolve a lista de jogadores da Mensagem
        [HttpGet("Grupos/{id}")]
        public async Task<ActionResult<List<Mensagem>>> GetMsgGrupo(int Id) {

            var msg = await _context.Mensagem.FindAsync(Id);

            if (msg == null) return BadRequest("Msg not found :(");

            var w = msg.GrupoFK;

            if (w == null) return BadRequest("Grupo not found :(");

            var r = await _context.Grupo.FindAsync(w);

            var t = r.Name;

            return Ok(t);
        }



    }

}
