using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.Transactions;

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
            this.Click = 1;
            this.Score = 0;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id{ get; set; }

        /// <summary>
        /// score do criador
        /// </summary>
        public int Click { get; set; }

        /// <summary>
        /// score do criador
        /// </summary>
        public int Score { get; set; }


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
