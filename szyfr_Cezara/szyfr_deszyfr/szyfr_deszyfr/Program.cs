using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szyfr_deszyfr
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Szyfr Cezara ----> wielkie litery");
            Console.WriteLine("Podaj słowo/zdanie do zaszyfrowania");
            string slowo = Console.ReadLine();                    
            char[] tablica = slowo.ToCharArray();           // dokonujemy konwersji do char
            int rozmiar = tablica.Length;                   // w rozmiar zapisujemy długość tablicy
            int i;

            Console.WriteLine("\nZASZYFROWANE: ");
            for(i = 0; i < rozmiar; i++)                    // szyfrowanie i wypisanie zaszyfrowanego słowa
            {
                int znak = tablica[i];
                if (znak >= 65 && znak <= 90)
                {
                    znak = (65 + (znak - 62) % 26);
                    tablica[i] = (char)znak;
                    Console.Write(tablica[i]);
                }
                else
                {
                    Console.Write(" ");
                }
            }

            Console.WriteLine("\n\nODSZYFROWANE: ");
            for (i = 0; i < rozmiar; i++)                    // odszyfrowanie i wypisanie odszyfrowanego słowa
            {
                int znak = tablica[i];
                if (znak >= 65 && znak <= 90)
                {
                    znak = (65 + (znak - 42) % 26);
                    tablica[i] = (char)znak;
                    Console.Write(tablica[i]);
                }
                else
                {
                    Console.Write(" ");
                }
            }

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
