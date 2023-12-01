namespace Avaliacao
{
    internal class Program
    {
        internal static Dictionary<string, string[]> palavrasPorTema = new Dictionary<string, string[]>()
        {
            { "Animais", new string[] { "Cachorro", "Gato", "Elefante", "Leão", "Pássaro", "Macaco" } },
            { "Frutas", new string[] { "Maçã", "Banana", "Uva", "Melancia", "Morango", "Abacaxi", "Pitanga" } },
            { "Cores", new string[] { "Vermelho", "Azul", "Verde", "Amarelo", "Roxo", "Preto" } },
            { "Tecnologia", new string[] { "Computador", "Notebook", "Celular", "Internet" } },
            { "Objeto", new string[] { "Lápis", "Mouse", "Mesa", "Papel", "Camisa" } },
        };

        static string SorteiaTema()
        {
            Random random = new Random();
            int quantidadeTemas = palavrasPorTema.Keys.Count;
            int indiceAleatorio = random.Next(quantidadeTemas);

            return palavrasPorTema.Keys.ElementAt(indiceAleatorio);
        }

        static string SorteiaPalavra(string tema)
        {
            Random random = new Random();
            int quantidadePalavras = palavrasPorTema[tema].Count();
            int indiceAleatorio = random.Next(quantidadePalavras);

            return palavrasPorTema[tema][indiceAleatorio];
        }
        static void Main(string[] args)
        {
            List<char> chutes = new List<char>();
            int erros = 0;
            bool chuteValido, acertou = false;
            char chuteAtual;
            string temaSorteado = SorteiaTema();
            string palavraSorteada = SorteiaPalavra(temaSorteado).ToUpper();

            Console.WriteLine("\n\rJogo da Forca");
            while (erros < 6 && !acertou)
            {
                Console.WriteLine("***********\n");
                Console.WriteLine($"Dica: {temaSorteado}\n");
                Console.Write("Chute uma letra: ");
                do
                {
                    chuteValido = char.TryParse(Console.ReadLine(), out chuteAtual);
                } while (!chuteValido || !char.IsLetter(chuteAtual) || chutes.Contains(chuteAtual));
                
                chuteAtual = char.ToUpper(chuteAtual);
                chutes.Add(chuteAtual);

                int letrasNaoDescobertas = Palavra.ImprimePalavra(chutes, palavraSorteada);

                if (!palavraSorteada.Contains(chuteAtual))
                {
                    erros++;
                    Console.WriteLine($"\nA letra '{chuteAtual}' não existe nesta palavra");
                } else
                    Console.WriteLine($"\nA letra '{chuteAtual}' existe nesta palavra!");
                

                Console.Write("Chutes: ");
                foreach(char chute in chutes)
                    Console.Write($"{chute} ");

                Console.WriteLine($"\tTentativas restantes: {6 - erros}");
                Boneco.ImprimeBoneco(erros);

                if (erros >= 6)
                    Console.WriteLine($"\nPoxa, não deu certo desta vez :( A palavra era {palavraSorteada}!");

                acertou = Palavra.VerificaAcerto(letrasNaoDescobertas);
                if (acertou)
                    Console.WriteLine($"\nParabéns!! A palavra era {palavraSorteada}!");

                Console.WriteLine();
            }
        }
    }
}
