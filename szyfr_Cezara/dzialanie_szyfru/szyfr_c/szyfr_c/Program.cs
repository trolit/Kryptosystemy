using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szyfr_c
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Szyfr Cezara - małe litery");
            Console.WriteLine("Aby wyjść wciśnij klawisz Escape");
            ConsoleKeyInfo keyInfo;
            char[] tablica = new char[500];
            int i = 0;

            do
            {
                keyInfo = Console.ReadKey(true);
                if (keyInfo.KeyChar >= 97 && keyInfo.KeyChar <= 122)
                {
                    char znak = (char)(((keyInfo.KeyChar - 95) % 27) + 97);
                    tablica[i] = znak;
                    i++;
                    Console.Write(znak);
                }
            } while (keyInfo.Key != ConsoleKey.Escape);

            Console.WriteLine("koniec...");
            Console.ReadKey();
        }
    }
}
