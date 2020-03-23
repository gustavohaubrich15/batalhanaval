using System;

namespace Exercicio6
{
    class Program
    {
        static void Main(string[] args)
        {
            int linhas = 3;
            int colunas = 3;
            int[,] campoBatalha = new int[linhas, colunas];
            int[,] escolhido = new int[linhas, colunas];
            Random randomNum = new Random();

            for (int i = 0; i < linhas; i++)
            {
                for (int j = 0; j < colunas; j++)
                {
                    campoBatalha[i, j] = randomNum.Next(2, 4);
                }
            }

            for (int i = 0; i < linhas; i++)
            {
                for (int j = 0; j < colunas; j++)
                {
                    escolhido[i, j] = 1;
                }
            }
            bool existeCampo = true;
            Console.WriteLine("-----------------");
            Console.WriteLine("Batalha Naval");
            while (existeCampo)
            {
                ImprimirCampo(escolhido, linhas, colunas);
                int linhaAtaque = linhas;
                int colunaAtaque = colunas;
                while (linhaAtaque > linhas - 1 || colunaAtaque > colunas - 1)
                {
                    Console.WriteLine("Digite uma posicao para atacar no formatao (A, D):");
                    string digitado = Console.ReadLine();
                    string[] numeros = digitado.Split(",");
                    linhaAtaque = int.Parse(numeros[0]);
                    colunaAtaque = int.Parse(numeros[1]);

                    if (linhaAtaque > linhas - 1 || colunaAtaque > colunas - 1)
                    {
                        ImprimirCampo(escolhido, linhas, colunas);
                    }
                }
                if (campoBatalha[linhaAtaque, colunaAtaque] != escolhido[linhaAtaque, colunaAtaque])
                {
                    escolhido[linhaAtaque, colunaAtaque] = campoBatalha[linhaAtaque, colunaAtaque];
                }
                existeCampo = PossuiCampoNaoAtacado(escolhido, linhas, colunas);
            }
            ImprimirCampo(escolhido, linhas, colunas);
        }

        static void ImprimirCampo(int[,] campoBatalha, int linhas, int colunas)
        {
            for (int i = 0; i < linhas; i++)
            {
                for (int j = 0; j < colunas; j++)
                {
                    char letra = ' ';
                    if (campoBatalha[i, j] == 1)
                    {
                        letra = 'O';
                    }
                    else if (campoBatalha[i, j] == 2)
                    {
                        letra = 'A';
                    }
                    else if (campoBatalha[i, j] == 3)
                    {
                        letra = 'B';
                    }

                    Console.Write(letra + "\t");
                }
                Console.WriteLine("");
            }
        }

        static bool PossuiCampoNaoAtacado(int[,] campo, int linhas, int colunas)
        {
            bool existeCampo = false;

            for (int i = 0; i < linhas; i++)
            {
                for (int j = 0; j < colunas; j++)
                {
                    if (campo[i, j] == 1)
                    {
                        existeCampo = true;
                    }
                }
            }

            return existeCampo;
        }
    }
}
