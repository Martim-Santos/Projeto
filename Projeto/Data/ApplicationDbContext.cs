using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Projeto.Models;
using static System.Formats.Asn1.AsnWriter;

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

            base.OnModelCreating(builder);

            /*
            * adicionar itens e grupos à base de dados
            */

            builder.Entity<Itens>().HasData(

                new Itens{
                    Id = 1, Name = "+1", Custo = 10, Description = "Mais 1 click por click :)", Imagem = "item1.png"
                }, new Itens {
                    Id = 2, Name = "+69", Custo = 690, Description = "Boa", Imagem = "item69.png"
                }, new Itens {
                    Id = 3, Name = "x5", Custo = 5000, Description = "MULTIPLOS CLICKS", Imagem = "itemx5.png"
                }, new Itens {
                    Id = 4, Name = "x100", Custo = 100000, Description = "tantos clicks", Imagem = "itemx100.png"
                }, new Itens {
                    Id = 5, Name = "Não é um botão", Custo = 1001, Description = "Definitivamente não é um botão", Imagem = "not_a_button.png"
                }, new Itens {
                    Id = 6, Name = "Gorro de natal", Custo = 2512, Description = "HO HO HO", Imagem = "christmas_hat.png"
                });

            builder.Entity<Grupo>().HasData(
                new Grupo{
                    Id = 1, Name = "Grupo Inicial", Description = "Grupo Inicial"
                }, new Grupo {
                    Id = 2, Name = "Bacanos", Description = "Grupo para pessoas fixes"
                }, new Grupo {
                    Id = 3, Name = "Não somos um grupo", Description = "Definitivamente não é um grupo"
                }, new Grupo {
                    Id = 4, Name = "Sem nome", Description = "Não temos nome"
                });

        }

        /*
         * criação das tabelas da base de dados
         */

        public DbSet<Jogador> Jogador { get; set; }
        public DbSet<Itens> Itens { get; set; }
        public DbSet<Grupo> Grupo { get; set; }
        public DbSet<Mensagem> Mensagem { get; set; }
        public DbSet<MsgJogador> MsgJogador { get; set; }
    }
}