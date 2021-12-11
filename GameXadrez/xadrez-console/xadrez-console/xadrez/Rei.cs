using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {

        private PartidaDeXadrez partida;

        public Rei(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
        {
            this.partida = partida;
        }

        public override string ToString()
        {
            return "R";
        }

        private bool podeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != cor;
        }

        private bool testeTorreParaRoque(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p != null && p is Torre && p.cor == cor && p.qteMovimentos == 0;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];
            Posicao pos = new Posicao(0, 0);

            //norte
            pos.definirValores(posicao.Linha - 1, posicao.Coluna);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //nordeste
            pos.definirValores(posicao.Linha - 1, posicao.Coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //leste
            pos.definirValores(posicao.Linha, posicao.Coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //sudeste
            pos.definirValores(posicao.Linha + 1, posicao.Coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //sul
            pos.definirValores(posicao.Linha + 1, posicao.Coluna);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //sudoeste
            pos.definirValores(posicao.Linha + 1, posicao.Coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //oeste
            pos.definirValores(posicao.Linha, posicao.Coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //noroeste
            pos.definirValores(posicao.Linha - 1, posicao.Coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //#jogadaespecial roque
            if (qteMovimentos == 0 && !partida.xeque)
            {
                //#jogadaespecial roque pequeno
                Posicao PosT1 = new Posicao(posicao.Linha, posicao.Coluna + 3);
                if (testeTorreParaRoque(PosT1))
                {
                    Posicao p1 = new Posicao(posicao.Linha, posicao.Coluna + 1);
                    Posicao p2 = new Posicao(posicao.Linha, posicao.Coluna + 2);
                    if (tab.peca(p1) == null && tab.peca(p2) == null)
                    {
                        mat[posicao.Linha, posicao.Coluna + 2] = true;
                    }
                }

                //#jogadaespecial roque grande
                Posicao PosT2 = new Posicao(posicao.Linha, posicao.Coluna - 4);
                if (testeTorreParaRoque(PosT2))
                {
                    Posicao p1 = new Posicao(posicao.Linha, posicao.Coluna - 1);
                    Posicao p2 = new Posicao(posicao.Linha, posicao.Coluna - 2);
                    Posicao p3 = new Posicao(posicao.Linha, posicao.Coluna - 3);
                    if (tab.peca(p1) == null && tab.peca(p2) == null && tab.peca(p3) == null)
                    {
                        mat[posicao.Linha, posicao.Coluna + 2] = true;
                    }
                }
            }

            return mat;
        }
    }
}