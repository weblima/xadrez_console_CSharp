using System;
using tabuleiro;

namespace xadrez {
    class PartidaDeXadrez {

        public Tabuleiro Tab { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        public PartidaDeXadrez() {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            ColocarPecas();
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino) {
            Peca p = Tab.RetirarPeca(origem);
            p.IncrementarQtdMovimentos();
            Peca PecaCapturada = Tab.RetirarPeca(destino);
            Tab.ColocarPeca(p, destino);
        }

        public void RealizaJogada(Posicao origem, Posicao destino) {
            ExecutaMovimento(origem, destino);
            Turno++;
            MudaJogador();
        }
        public void ValidarPosicaoDeOrigem(Posicao pos) {
            if (Tab.peca(pos) == null) {
                throw new TabuleitoException("Não existe peça na posição de origem escolhida!");
            }

            if (JogadorAtual != Tab.peca(pos).Cor) {
                throw new TabuleitoException("A peça de origem escolhoda não é sua!");
            }

            if (!Tab.peca(pos).ExisteMovimentosPossiveis()) {
                throw new TabuleitoException("Não existe movimentos possíveis para a peça de origem escolhida!");
            }
        }
        public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino) {
            if(!Tab.peca(origem).PodeMoverPara(destino)){
                throw new TabuleitoException("Posição de destino inválida!");
            }
        }
        private void MudaJogador() {
            if (JogadorAtual == Cor.Branca) {
                JogadorAtual = Cor.Preta;
            }
            else {
                JogadorAtual = Cor.Branca;
            }
        }

        private void ColocarPecas() {
            Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('c', 1).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('c', 2).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('d', 2).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('e', 2).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('e', 1).ToPosicao());
            Tab.ColocarPeca(new Rei(Tab, Cor.Branca), new PosicaoXadrez('d', 1).ToPosicao());

            Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('c', 7).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('c', 8).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('d', 7).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('e', 7).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('e', 8).ToPosicao());
            Tab.ColocarPeca(new Rei(Tab, Cor.Preta), new PosicaoXadrez('d', 8).ToPosicao());
        }

    }
}
