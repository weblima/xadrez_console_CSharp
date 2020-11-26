using tabuleiro;

namespace xadrez {
    class PosicaoXadrez {
        public char Coluna { get; set; }
        public int Linha { get; set; }

        public PosicaoXadrez(char coluna, int linha) {
            this.Coluna = coluna;
            this.Linha = linha;
        }

        public Posicao ToPosicao() {
            return new Posicao(8 - Linha, Coluna - 'a');
        }

        public override string ToString() {
            return "" + Coluna + Linha;
        }
    }
}
