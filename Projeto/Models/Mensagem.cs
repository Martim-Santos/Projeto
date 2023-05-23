using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto.Models {
    public class Mensagem {
        public Mensagem() {
            // inicializar a lista de itens do jogador
            ListaJogador = new HashSet<Jogador>();
        }

        public int id { get; set; }

        /// <summary>
        /// Conteudo da mensagem
        /// </summary>
        public string frase { get; set; }

        /// <summary>
        /// data de envio da mensagem
        /// </summary>
        public DateTime data { get; set; }



        [ForeignKey(nameof(Jogador))]
        public int JogadorFK { get; set; }
        public Jogador Jogador { get; set; }

        [ForeignKey(nameof(Grupo))]
        public int GrupoFK { get; set; }
        public Grupo Grupo { get; set; }

        /// <summary>
        /// Lista dos Itens associados ao Jogador
        /// </summary>
        public ICollection<Jogador> ListaJogador { get; set; }
    }
}
