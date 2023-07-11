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

        

    }

}
