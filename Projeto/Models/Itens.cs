namespace Projeto.Models {
    public class Itens {

        public Itens() {
            // inicializar a lista de itens do jogador
            ListaJogador = new HashSet<Jogador>();
        }
        public int Id { get; set; }

        /// <summary>
        /// nome do Item
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Descrição do Item
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// imagem do Item
        /// </summary>
        public string Imagem { get; set; }

        /// <summary>
        /// tipo de item
        /// </summary>
        public int custo { get; set; }

        /// <summary>
        /// Lista dos Itens associados ao Jogador
        /// </summary>
        public ICollection<Jogador> ListaJogador { get; set; }

    }
}
