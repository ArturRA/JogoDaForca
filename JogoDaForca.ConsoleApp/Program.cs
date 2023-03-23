using System;

namespace JogoDaForca.ConsoleApp
{
    internal class Program
    {
        public static char proximaLetraParaAdivinhar()
        {
            char letraParaAdivinhar = ' ';

            while (true)
            {
                Console.Write("Digite uma letra para adivinhar a palavra: ");
                letraParaAdivinhar = Convert.ToChar(Console.ReadLine());

                if (Char.IsLetter(letraParaAdivinhar))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Por favor digite uma letra valida.");
                    Console.WriteLine("Digite qualquer tecla para tentar novamente....");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }

            }

            return Char.ToUpper(letraParaAdivinhar);
        }
        static void Main(string[] args)
        {
            // Lista de palavras
            List<string> listaDePalavras = new List<string> {
                    "ABACATE", "CAJÚ",       "MARACUJÁ",
                    "ABACAXI", "CARAMBOLA",  "MURICI",
                    "ACEROLA", "CUPUAÇU",    "PEQUI",
                    "AÇAÍ",    "GRAVIOLA",   "PITANGA",
                    "ARAÇA",   "GOIABA",     "PITAYA",
                    "ABACATE", "JABUTICABA", "SAPOTI",
                    "BACABA",  "JENIPAPO",   "TANGERINA",
                    "BACURI",  "MAÇÃ",       "UMBU",
                    "BANANA",  "MANGABA",    "UVA",
                    "CAJÁ",    "MANGA",      "UVAIA"
                };
            char letraParaAdivinhar = ' ';

            while (true)
            {
                Console.Clear();

                int quantidadeChutes = 5;
                string estadoDoJogo = "";

                // Escolhendo palavra sorteada
                Random random = new Random();
                int numeroParaEscolherAPalavraSorteada = random.Next(0, 30);
                List<char> palavraSorteada = new List<char>();
                palavraSorteada.AddRange(listaDePalavras[numeroParaEscolherAPalavraSorteada]);

                // Lista de todas as letras escolhidas pelo jogador
                List<char> letrasEscolhidas = new List<char>();
                

                while (quantidadeChutes > 0)
                {
                    Console.Clear();

                    Console.WriteLine($"Tentativas restantes: {quantidadeChutes}");
                    Console.WriteLine(estadoDoJogo);
                    // Console.WriteLine(String.Concat(palavraSorteada));
                    estadoDoJogo = "";
                    letraParaAdivinhar = proximaLetraParaAdivinhar();
                    letrasEscolhidas.Add(letraParaAdivinhar);

                    // Decreser quantidade de chutes caso a palavra não possua a letra escolhida
                    if (!palavraSorteada.Contains(letraParaAdivinhar))
                        quantidadeChutes--;

                    // Cria a string estado do jogo verificando quais letras o jogador acertou
                    foreach (char charDaPalavraSorteada in palavraSorteada)
                    {
                        if (letrasEscolhidas.Contains(charDaPalavraSorteada))
                            estadoDoJogo += charDaPalavraSorteada;
                        else
                            estadoDoJogo += "_";
                    }

                    // Confere se o jogador acertou a palavra
                    if (estadoDoJogo == String.Concat(palavraSorteada))
                    {
                        Console.WriteLine($"Voce adivinhou a palavra: {String.Concat(palavraSorteada)}!");
                        break;
                    }

                    // Confere se o jogador gastou todas as tentativas e não conseguiu adivinhar a palavra
                    if (quantidadeChutes == 0)
                    {

                        Console.WriteLine($"Que pena voce não adivinhou a palavra: {String.Concat(palavraSorteada)}!");
                        break;
                    }
                }

                #region Conitinuar ou parar o programa
                string continuar = "";
                while (true)
                {
                    Console.Write("Gostaria de tentar mais uma vez(S/N)?");
                    continuar = Console.ReadLine();

                    if (continuar == "S" || continuar == "s")
                    {
                        Console.WriteLine("Por favor digite um valor impar.");
                        Console.Clear();
                        break;
                    }
                    else if (continuar == "N" || continuar == "n")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Por favor digite uma opção valida.");
                    }

                }
                #endregion

                // Termina o programa
                if (continuar == "N" || continuar == "n")
                {
                    break;
                }
            }
        }
    }
}