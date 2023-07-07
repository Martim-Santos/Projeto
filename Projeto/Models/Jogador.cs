using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Models {
    public class Jogador {

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

        public int Id { get; set; }

        /// <summary>
        /// nome do jogador
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchismento obrigratório.")]
        [StringLength(50)]
        public string Nome { get; set; }

        /// <summary>
        /// Email do jogador
        /// </summary>
        [EmailAddress]
        [Required(ErrorMessage = "O {0} é de preenchismento obrigratório.")]
        [StringLength(50)]
        public string Email { get; set; }

        /// <summary>
        /// cliques que o jogador faz ao clicar
        /// </summary>
        public int Click { get; set; }

        /// <summary>
        /// pontuação do jogador (quantas vezes o jogador clicou)
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// chave de ligação entre a base de dados da autenticação
        /// e a base de dados do 'jogo'
        /// </summary>
        public string UserId { get; set; }


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
