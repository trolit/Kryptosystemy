using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eni_one
{
    class EnigmaCore
    {
        public bool reverse = false;
        public int rotor_counter = 0;
        public char Rotor1_StartPosition;
        public char Rotor2_StartPosition;
        public char Rotor3_StartPosition;
    }

    class Program
    {
        static void Main(string[] args)
        {
            EnigmaCore body = new EnigmaCore();

            Console.WriteLine("E  N I G M  A");
            Console.WriteLine("*trzy wirniki*");
            Console.WriteLine("Ustal klucz kodowania np. AGR(podawaj po jednej literze zatwierdzając)");
            body.Rotor1_StartPosition = Convert.ToChar(Console.ReadLine());
            body.Rotor2_StartPosition = Convert.ToChar(Console.ReadLine());
            body.Rotor3_StartPosition = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Klucz kodowania: " + body.Rotor1_StartPosition + body.Rotor2_StartPosition + body.Rotor3_StartPosition);

            Console.WriteLine("Podaj tekst do zaszyfrowania(tylko duże litery)");
            string tekst = Console.ReadLine();
            int rozmiar = tekst.Length;
            char[] Chars_To_Encrypt = new char[rozmiar];
            Chars_To_Encrypt = tekst.ToCharArray();

            Console.WriteLine("Naciśnij dowolny klawisz aby zakończyć...");
            Console.ReadKey();
        }
    }
}
