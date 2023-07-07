using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Projeto.Models;

namespace Projeto.Data {
    public class ApplicationDbContext : IdentityDbContext {

        private readonly IWebHostEnvironment _webHostEnvironment;
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options, IWebHostEnvironment webHostEnvironment)
        : base(options)
            {
            _webHostEnvironment = webHostEnvironment;
        }


        protected override void OnModelCreating(ModelBuilder builder) {
            string nomeLocalizacaoImagem = _webHostEnvironment.WebRootPath;
            nomeLocalizacaoImagem = Path.Combine(nomeLocalizacaoImagem, "imagens");

            base.OnModelCreating(builder);
            builder.Entity<Itens>().HasData(

                new {
                    Id = 1, Name = "+1", Custo = 10, Description = "Mais 1 click por click :)", Imagem = Path.Combine(nomeLocalizacaoImagem, "Item +1.png")
                }, new {
                    Id = 2, Name = "+69", Custo = 690, Description = "Boa", Imagem = Path.Combine(nomeLocalizacaoImagem, "Item +69.png")
                }, new {
                    Id = 3, Name = "x5", Custo = 5000, Description = "MULTIPLOS CLICKS", Imagem = Path.Combine(nomeLocalizacaoImagem, "Item x5.png")
                }, new {
                    Id = 4, Name = "x100", Custo = 100000, Description = "tantos clicks", Imagem = Path.Combine(nomeLocalizacaoImagem, "Item x100.png")
                }, new {
                    Id = 5, Name = "Não é um botão", Custo = 1001, Description = "Definitivamente não é um botão", Imagem = Path.Combine(nomeLocalizacaoImagem, "not a button.png")
                }, new {
                    Id = 6, Name = "Gorro de natal", Custo = 2512, Description = "HO HO HO", Imagem = Path.Combine(nomeLocalizacaoImagem, "christmas hat.png")
                });
        }

        public DbSet<Jogador> Jogador { get; set; }
        public DbSet<Itens> Itens { get; set; }
        public DbSet<Grupo> Grupo { get; set; }
        public DbSet<Mensagem> Mensagem { get; set; }
        public DbSet<MsgJogador> MsgJogador { get; set; }
    }
}