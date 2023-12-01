namespace Avaliacao
{
    internal class Program
    {
        internal static bool VerificaAcerto(int letrasNaoDescobertas)
        {
            return letrasNaoDescobertas == 0;
        }
        static void Main(string[] args)
        {
            List<char> chutes = new List<char>();
            int erros = 0;
            bool chuteValido, acertou = false;
            char chuteAtual;
            string temaSorteado = Palavra.SorteiaTema();
            string palavraSorteada = Palavra.SorteiaPalavra(temaSorteado).ToUpper();

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

                acertou = VerificaAcerto(letrasNaoDescobertas);
                if (acertou)
                    Console.WriteLine($"\nParabéns!! A palavra era {palavraSorteada}!");

                Console.WriteLine();
            }
        }
    }
}
