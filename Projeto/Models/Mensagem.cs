using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Projeto.Models {
    public class Mensagem {
        public Mensagem() {
            // inicializar a lista de Mensagens do jogador
            ListaRecieved = new HashSet<MsgJogador>();
            this.Data = DateTime.Now;
        }

        public int Id { get; set; }

        /// <summary>
        /// Conteudo da mensagem
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchismento obrigratório.")]
        [StringLength(60)]
        public string Frase { get; set; }

        /// <summary>
        /// data de envio da mensagem
        /// </summary>
        public DateTime Data { get; set; }

        /********************  Chaves forasteiras  ************************/

        [ForeignKey(nameof(Jogador))]
        public int? JogadorFK { get; set; }
        public Jogador? Jogador { get; set; }


        [ForeignKey(nameof(Grupo))]
        public int? GrupoFK { get; set; }
        public Grupo? Grupo { get; set; }

        /// <summary>
        /// Lista das Mensagens associados ao Jogador
        /// </summary>
        public ICollection<MsgJogador> ListaRecieved { get; set; }
    }
}
