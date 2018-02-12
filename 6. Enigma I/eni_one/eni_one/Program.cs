using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eni_one
{
    class EnigmaCore
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ENIGMA");
            Console.WriteLine("- 3 wirniki");
            Console.WriteLine("Podaj tekst do zaszyfrowania(tylko duże litery)");
            string tekst = Console.ReadLine();
            int rozmiar = tekst.Length;
            char[] Chars_To_Encrypt = new char[rozmiar];
            Chars_To_Encrypt = tekst.ToCharArray();
        }
    }
}
