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
            Console.WriteLine("-------------");
            Console.WriteLine("Szyfr Cezara");
            Console.WriteLine("Podaj słowo/zdanie do zaszyfrowania");

            string slowo = Console.ReadLine();                    
            char[] tablica = slowo.ToCharArray();           // dokonujemy konwersji do char
            int i;
            char probka;
            int rozmiar = tablica.Length;                   // w rozmiar zapisujemy długość tablicy

            for (i = 0; i < rozmiar; i++)                   // formatujemy otrzymany tekst
            {
                probka = tablica[i];
                tablica[i] = Char.ToUpper(probka);
            }
            

            Console.WriteLine("\nTWOJA ZASZYFROWANA WIADOMOŚĆ: ");
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

            Console.WriteLine("\n\nODSZYFROWANIE WIADOMOŚCI: ");
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
