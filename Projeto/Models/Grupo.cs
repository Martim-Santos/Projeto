namespace Projeto.Models {
    public class Grupo {

        public Grupo() {
            // inicializar a lista de jogador do grupo
            ListaJogador = new HashSet<Jogador>();
        }

        public int Id { get; set; }

        /// <summary>
        /// nome do Grupo
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// nome do criador
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Lista dos Jogadores associados ao Grupo
        /// </summary>
        public ICollection<Jogador> ListaJogador { get; set; }

    }
}
