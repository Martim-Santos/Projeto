using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Projeto.Data;
using Projeto.Models;

namespace Projeto.Controllers {

    [Route("api/itens")]
    [ApiController]
    public class ItensController : ControllerBase {

        private readonly ApplicationDbContext _context;
        private readonly SignInManager<Jogador> signInManager;
        private readonly UserManager<Jogador> userManager;

        public ItensController(ApplicationDbContext context, UserManager<Jogador> userManager) {
            _context = context;
            this.userManager = userManager;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAsync() {
            Jogador j = await userManager.FindByEmailAsync("email");

            if (j != null) {
                PasswordVerificationResult res = new PasswordHasher<Jogador>().VerifyHashedPassword(null, j.PasswordHash, "password");
                if (res.Equals(PasswordVerificationResult.Success)) {
                    signInManager.SignInAsync(j, false);
                }
            }

            var item = _context.Itens.ToList();

            return Ok(item);
        }

    }
}
