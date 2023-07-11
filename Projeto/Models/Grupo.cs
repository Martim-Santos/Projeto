namespace Projeto.Models {
    public class Grupo {

        public Grupo() {
            // inicializar a lista de jogador do grupo
            ListaJogador = new HashSet<Jogador>();
            // inicializar a lista de Mensagens do grupo
            ListaMensagem = new HashSet<Mensagem>();
        }

        public int Id { get; set; }

        /// <summary>
        /// nome do Grupo
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// descrição do grupo
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Lista dos Jogadores associados ao Grupo
        /// </summary>
        public ICollection<Jogador> ListaJogador { get; set; }

        /// <summary>
        /// Lista das Mensagens associados ao Grupo
        /// </summary>
        public ICollection<Mensagem> ListaMensagem { get; set; }

    }
}
