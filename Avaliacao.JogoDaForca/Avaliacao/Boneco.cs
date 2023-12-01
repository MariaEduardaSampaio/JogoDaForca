using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao
{
    internal static class Boneco
    {
        internal static void ImprimeBoneco(int erros)
        {
            char[] boneco = [' ','o', '/', '|', '\\','/','\\'];
            Console.WriteLine("-|");
            for (int i = 0; i <= erros; i++)
            {
                Console.Write(boneco[i]);
                if (i == 1 || i == 4)
                    Console.WriteLine("");
                if (i == 5)
                    Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}
