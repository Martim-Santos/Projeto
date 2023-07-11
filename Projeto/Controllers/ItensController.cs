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
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public ItensController(ApplicationDbContext context, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager) {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAsync(IdentityUser j) {
            _ = await _userManager.FindByEmailAsync("email");

            if (j != null) {
                PasswordVerificationResult res = new PasswordHasher<IdentityUser>().VerifyHashedPassword(null, j.PasswordHash, "password");
                if (res.Equals(PasswordVerificationResult.Success)) {
                    await _signInManager.SignInAsync(j, false);
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
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public GrupoController(ApplicationDbContext context, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager) {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAsync(IdentityUser j) {
            _ = await _userManager.FindByEmailAsync("email");

            if (j != null) {
                PasswordVerificationResult res = new PasswordHasher<IdentityUser>().VerifyHashedPassword(null, j.PasswordHash, "password");
                if (res.Equals(PasswordVerificationResult.Success)) {
                    await _signInManager.SignInAsync(j, false);
                }
            }

            var Grupo = _context.Itens.ToList();

            return Ok(Grupo);
        }
    }*/
}
