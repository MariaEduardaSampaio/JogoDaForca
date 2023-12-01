using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao
{
    internal static class Palavra
    {
        internal static int ImprimePalavra(List<char> chutes, string palavra)
        {
            Console.WriteLine();
            int letrasNaoDescobertas = 0;

            foreach (char letra in palavra)
            {
                if (chutes.Contains(letra))
                    Console.Write(letra.ToString().ToUpper());
                else
                {
                    Console.Write(" _ ");
                    letrasNaoDescobertas++;
                }
            }
            Console.WriteLine();
            return letrasNaoDescobertas;
        }

        internal static bool VerificaAcerto(int letrasNaoDescobertas)
        {
            return letrasNaoDescobertas == 0;
        }
    }
}
