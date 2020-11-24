namespace tabuleiro {
    class Peca {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QtdMovimentos { get;protected set; }
        public Tabuleiro Tab { get; protected set; }

        public Peca(Posicao posicao, Tabuleiro tab, Cor cor ) {
            this.Posicao = posicao;
            this.Tab = tab;
            this.Cor = cor;
            this.QtdMovimentos = 0;
        }
    }
}
