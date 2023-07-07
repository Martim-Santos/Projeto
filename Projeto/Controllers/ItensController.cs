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
        private readonly SignInManager<IdentityUser>? signInManager;
        private readonly UserManager<IdentityUser> userManager;

        public ItensController(ApplicationDbContext context, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager) {
            _context = context;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAsync() {
            IdentityUser j = await userManager.FindByEmailAsync("email");

            if (j != null) {
                PasswordVerificationResult res = new PasswordHasher<IdentityUser>().VerifyHashedPassword(null, hashedPassword: j.PasswordHash, "password");
                if (res.Equals(PasswordVerificationResult.Success)) {
                    await signInManager.SignInAsync(j, false);
                }
            }

            var item = _context.Itens.ToList();

            return Ok(item);
        }

    }
}
