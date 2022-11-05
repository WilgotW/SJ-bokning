using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokaPlats
{
    internal class tools
    {
        public static void lines(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Console.Write("-");
            }
        }
        public static void colorizeText(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
