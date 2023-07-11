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
    public class GruposController : ControllerBase {

        private readonly ApplicationDbContext _context;

        public GruposController(ApplicationDbContext context) {
            _context = context;
        }

        // devolve a lista de Grupos
        [HttpGet]
        public async Task<ActionResult<List<Grupo>>> Get() {

            var Group = _context.Grupo.ToList();

            return Ok(Group);
        }

        // devolve o Grupo com esse Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Grupo>> Get(int id) {

            var item = await _context.Grupo.FindAsync(id);

            if (item == null) return BadRequest("Grupo not found :(");

            return Ok(await _context.Grupo.FindAsync(id));
        }

        // devolve a lista de jogadores do Grupo
        [HttpGet("User/{id}")]
        public async Task<ActionResult<List<Grupo>>> GetUserItens(int Id) {

            var Group = await _context.Grupo.FindAsync(Id);

            if (Group == null) return BadRequest("Grupo not found :(");

            var lista = Group.ListaJogador;

            return Ok(lista);
        }



    }

}
