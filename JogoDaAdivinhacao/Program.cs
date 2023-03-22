namespace JogoDaAdivinhacao
{
    internal class Program
    {
        #region Passos do Exercício
        // Passos do exercício:
        // 1 - Fazer o computador gerar um número aleatório entre 1 e 20; (x)
        // 2 - Fazer o usuário digitar um número tentanto adivinhá-lo e o computador comparar esse número. (x)
        // 3 - Dizer se acertou e falar se o número imputado é maior ou menor que o número gerado. (x)
        // 4 - Limitar as tentativas e criar um menu de tentativas.(x)
        // 5 - Descrescer a pontuação conforme for errando. (x)
        // 6 - Mostrar a pontuação final! (x)
        #endregion
        #region Variáveis Globais
        static int numeroDigitado;
        static bool ehVerdade = true;
        static int numeroTentativas;
        static int numeroTentativasMenu;
        static int pontuacaoJogador = 1000;
        static int numeroGerado;
        #endregion
        static void Main(string[] args)
        {   
            do
            {
            GerarNumeroAleatorio();
            MostrarMenu();
            GerarDificuldade();
            ColetarNumeroCompararNumero();
            } while (ehVerdade == true);

        }
        static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("---------- Adivinhe o número! ----------");
            Console.WriteLine();
            Console.WriteLine("- Escolha a dificuldade do nosso jogo: -");
            Console.WriteLine("- Sendo \n- 1 - Fácil (15 tentativas)            - \n- 2 - Médio (10 tentativas)            - \n- 3 - Difícil (5 tentativas)           -");
            numeroTentativasMenu = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
        }
        static void GerarNumeroAleatorio()
        {
            Random numeroAleatorio = new Random();
            numeroGerado = numeroAleatorio.Next(1, 23);
        }
        static void GerarDificuldade()
        {
            switch (numeroTentativasMenu)
            {
                case 1:
                    numeroTentativas = 15;
                    break;
                case 2:
                    numeroTentativas = 10;
                    break;
                case 3:
                    numeroTentativas = 5;
                    break;
                default:
                    Console.WriteLine("- Número é inválido! Tente novamente - ");
                    Console.ReadLine();
                    break;
            }
        }
        static void PontosPerdidos()
        {
            int pontosPerdidos = Math.Abs((numeroDigitado - numeroGerado) / 2);
            pontuacaoJogador = pontuacaoJogador - pontosPerdidos;
        }
        static void DesejaContinuar()
        {
            Console.WriteLine("-      Deseja continuar? Digite S ou N  -");
            Console.WriteLine();
            char continuarJogar = Convert.ToChar(Console.ReadLine());

            if (continuarJogar == 'S' || continuarJogar == 's')
            {
                ehVerdade = true;
            }
            else
            {
                ehVerdade = false;
            }
        }
        static void ColetarNumeroCompararNumero()
        {
            for (int i = numeroTentativas - 1; i >= 0; i--)
            {

                SolicitarNumero();
                PontosPerdidos();
                if (VerificarAcerto())
                {
                    Console.WriteLine("Você Acertou! Parabéns!");
                    PontuacaoTotal();
                    Console.ReadLine();
                    i = 0;
                }
                else
                {
                    if (numeroDigitado > numeroGerado)
                    {
                        Console.WriteLine("O número é menor!");
                        Console.WriteLine();
                    }
                    else if (numeroDigitado < numeroGerado)
                    {
                        Console.WriteLine("O número é maior!");
                    }

                    Console.WriteLine("\n- Você tem um total de " + i + " tentativas.    - ");
                    PontuacaoTotal();
                    Console.WriteLine();
                }

                if (i == 0)
                {
                    DesejaContinuar();
                }

            }
        }
        static bool VerificarAcerto()
        {
            return numeroDigitado == numeroGerado;
        }
        static void PontuacaoTotal()
        {
            Console.WriteLine("Sua pontuação total é de  " + pontuacaoJogador + " pontos.");
        }
        static void SolicitarNumero()
        {
            Console.WriteLine("-     Digite um número entre 1 e 22    -");
            numeroDigitado = Convert.ToInt32(Console.ReadLine());
        }
    }
}