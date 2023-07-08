using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Projeto.Data;
using Projeto.Models;

namespace Projeto.Controllers {

    [ApiController]
    [Route("api/itens")]
    public class ItensController : ControllerBase {

        private readonly ApplicationDbContext _context;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;

        public ItensController(ApplicationDbContext context, UserManager<IdentityUser> userManager) {
            _context = context;
            this.userManager = userManager;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAsync(IdentityUser? j) {
            _ = await userManager.FindByEmailAsync("email");

            if (j != null) {
                PasswordVerificationResult res = new PasswordHasher<IdentityUser>().VerifyHashedPassword(null, j.PasswordHash, "password");
                if (res.Equals(PasswordVerificationResult.Success)) {
                    await signInManager.SignInAsync(j, false);
                }
            }

            var item = _context.Itens.ToList();

            return Ok(item);
        }

    }

    /*[ApiController]
    [Route("api/Grupo")]
    public class GrupoController : ControllerBase {

        private readonly ApplicationDbContext _context;

        public GrupoController(ApplicationDbContext context) {  
            _context = context; 
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync() {


            var Grupo = _context.Itens.ToList();

            return Ok(Grupo);
        }
    }*/
}
