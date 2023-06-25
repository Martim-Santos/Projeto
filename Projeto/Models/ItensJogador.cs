using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto.Models {
    public class ItensJogador {

        public int Id { get; set; }

        [ForeignKey(nameof(Jogador))]
        public string JogadorFK { get; set; }
        public Jogador Jogador { get; set; }

        [ForeignKey(nameof(Itens))]
        public int ItensFK { get; set; }
        public Itens Itens { get; set; }
    }
}
