namespace JogoDaAdivinhacao
{
    internal class Program
    {
        static void Main(string[] args)
        {   // Passos do exercício:
            // 1 - Fazer o computador gerar um número aleatório entre 1 e 20; (x)
            // 2 - Fazer o usuário digitar um número tentanto adivinhá-lo e o computador comparar esse número. (x)
            // 3 - Dizer se acertou e falar se o número imputado é maior ou menor que o número gerado. (x)
            // 4 - Limitar as tentativas e criar um menu de tentativas.(x)
            // 5 - Descrescer a pontuação conforme for errando. (x)
            // 6 - Mostrar a pontuação final! (x)

            Random numeroAleatorio = new Random();
            int numeroGerado = numeroAleatorio.Next(1, 23);
            int numeroDigitado;
            bool ehVerdade = true;
            int numeroTentativas;
            int numeroTentativasMenu;
            int pontuacaoJogador = 1000;

            do
            {
            Console.Clear();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("---------- Adivinhe o número! ----------");
            Console.WriteLine();
            Console.WriteLine("- Escolha a dificuldade do nosso jogo: -");
            Console.WriteLine("- Sendo \n- 1 - Fácil (15 tentativas)            - \n- 2 - Médio (10 tentativas)            - \n- 3 - Difícil (5 tentativas)           -");
            numeroTentativasMenu = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

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
                    continue;
            }
            
                for (int i = numeroTentativas-1; i >= 0; i--)
                {
                    
                    Console.WriteLine("-     Digite um número entre 1 e 22    -");
                    numeroDigitado = Convert.ToInt32(Console.ReadLine());

                    int pontosPerdidos = Math.Abs((numeroDigitado - numeroGerado) / 2);
                    pontuacaoJogador = pontuacaoJogador - pontosPerdidos;

                    if (numeroDigitado == numeroGerado)
                    {
                        Console.WriteLine("Você Acertou!!");
                        Console.WriteLine("Sua pontuação total é de  " + pontuacaoJogador + " pontos. Parabéns!");
                        break;
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
                        Console.WriteLine("- Sua pontuação atual é de  " + pontuacaoJogador + " pontos. -");
                        Console.WriteLine();
                    }
                    
                    if(i == 0)
                    {
                        Console.WriteLine("-      Você perdeu! :(                  -");
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
                    
                }
            } while (ehVerdade == true);

        }
    }
}