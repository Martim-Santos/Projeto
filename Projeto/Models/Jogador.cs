using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Projeto.Models {
    public class Jogador : IdentityUser {

        /// <summary>
        /// Descrição dos jogadores
        /// </summary>
        public Jogador() {
            // inicializar a lista de itens do jogador
            ListaItens = new HashSet<Itens>();
            // inicializar a lista de Mensagens do jogador
            ListaRecieved = new HashSet<MsgJogador>();
            this.click = 1;
            this.score = 0;
        }

        public int Id { get; set; }

        /// <summary>
        /// score do criador
        /// </summary>
        public int click { get; set; }

        /// <summary>
        /// score do criador
        /// </summary>
        public int score { get; set; }


        /*+++++++++++++++++++++++++++++++++++++++++++
         * relacionamentos associados ao Jogador
         */

        /// <summary>
        /// FK para o Grupo do Jogador
        /// </summary>
        [ForeignKey(nameof(Grupo))]
        [Display(Name = "Grupo")]
        public int GrupoFK { get; set; }
        public Grupo? Grupo { get; set; }

        /// <summary>
        /// Lista dos Itens associados ao Jogador
        /// </summary>
        public ICollection<Itens> ListaItens { get; set; }

        /// <summary>
        /// Lista das Mensagens associados ao Jogador
        /// </summary>
        public ICollection<MsgJogador> ListaRecieved { get; set; }

    }
}
