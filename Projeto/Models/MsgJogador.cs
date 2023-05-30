using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto.Models {
    public class MsgJogador {

        public int Id { get; set; }

        [ForeignKey(nameof(Jogador))]
        public int JogadorFK { get; set; }
        public Jogador Jogador { get; set; }

        [ForeignKey(nameof(Mensagem))]
        public int MensagemFK { get; set; }
        public Mensagem Mensagem { get; set; }
    }
}
