using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Projeto.Models;

namespace Projeto.Data {
    public class ApplicationDbContext : IdentityDbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }


        public DbSet<Jogador> Jogador { get; set; }
        public DbSet<Itens> Itens { get; set; }
        public DbSet<Grupo> Grupo { get; set; }
        public DbSet<Mensagem> Mensagem { get; set; }
        public DbSet<MsgJogador> MsgJogador { get; set; }
    }
}