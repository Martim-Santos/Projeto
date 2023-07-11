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
    public class ItensController : ControllerBase {

        private readonly ApplicationDbContext _context;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public ItensController(ApplicationDbContext context, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager) {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;

        }

        // devolve a lista de itens
        [HttpGet]
        public async Task<ActionResult<List<Itens>>> Get() {

            return Ok(await _context.Itens.ToListAsync());
        }

        // devolve o item com esse Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Itens>> Get(int id) {

            var item = await _context.Itens.FindAsync(id);

            if(item == null) return BadRequest("Item not found :(");

            return Ok(await _context.Itens.FindAsync(id));
        }

        [HttpPut]
        public async Task<ActionResult<List<Itens>>> UpdateItem(Itens request) {

            var item = await _context.Itens.FindAsync(request.Id);
            if (item == null) return BadRequest("Item not found :(");

            item.Custo = 0;

            await _context.SaveChangesAsync();

            return Ok(await _context.Itens.ToListAsync());
        }

        

    }

}
