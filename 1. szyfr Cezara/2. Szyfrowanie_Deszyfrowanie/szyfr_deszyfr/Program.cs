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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetWindowSize(77, 20);
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine("Szyfr Cezara");
            Console.WriteLine("Podaj słowo/zdanie do zaszyfrowania");
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            string slowo = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            char[] tablica = slowo.ToCharArray();           // dokonujemy konwersji do char
            int i;
            char probka;
            int rozmiar = tablica.Length;                   // w rozmiar zapisujemy długość tablicy

            for (i = 0; i < rozmiar; i++)                   // formatujemy otrzymany tekst
            {
                probka = tablica[i];
                tablica[i] = Char.ToUpper(probka);
            }
      
            Console.WriteLine("\n\n-----------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("TWOJA ZASZYFROWANA WIADOMOŚĆ: ");
            Console.ForegroundColor = ConsoleColor.Green;
            for (i = 0; i < rozmiar; i++)                    // szyfrowanie i wypisanie zaszyfrowanego słowa
            { 
                int znak = tablica[i];
                if (znak >= 65 && znak <= 90)
                {
                    znak = (65 + (znak - 62) % 26);
                    tablica[i] = (char)znak;
                    Console.Write(tablica[i]);
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n-----------------------------------------------------------------------------");     
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("TWOJA WIADOMOŚĆ PO ODSZYFROWANIU: ");
            Console.ForegroundColor = ConsoleColor.Green;
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
            Console.WriteLine("\n-----------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Naciśnij dowolny klawisz...");
            Console.ReadKey();
        }
    }
}
