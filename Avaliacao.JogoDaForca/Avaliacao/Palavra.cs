using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao
{
    internal static class Palavra
    {
        internal static Dictionary<string, string[]> palavrasPorTema = new Dictionary<string, string[]>()
        {
            { "Animais", new string[] { "Cachorro", "Gato", "Elefante", "Leão", "Pássaro", "Macaco" } },
            { "Frutas", new string[] { "Maçã", "Banana", "Uva", "Melancia", "Morango", "Abacaxi", "Pitanga" } },
            { "Cores", new string[] { "Vermelho", "Azul", "Verde", "Amarelo", "Roxo", "Preto" } },
            { "Tecnologia", new string[] { "Computador", "Notebook", "Celular", "Internet" } },
            { "Objeto", new string[] { "Lápis", "Mouse", "Mesa", "Papel", "Camisa" } },
        };
        internal static string SorteiaTema()
        {
            Random random = new Random();
            int quantidadeTemas = palavrasPorTema.Keys.Count;
            int indiceAleatorio = random.Next(quantidadeTemas);

            return palavrasPorTema.Keys.ElementAt(indiceAleatorio);
        }
        internal static string SorteiaPalavra(string tema)
        {
            Random random = new Random();
            int quantidadePalavras = palavrasPorTema[tema].Count();
            int indiceAleatorio = random.Next(quantidadePalavras);

            return palavrasPorTema[tema][indiceAleatorio];
        }

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
    }
}
