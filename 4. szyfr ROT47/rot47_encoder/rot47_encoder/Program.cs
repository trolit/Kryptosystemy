using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rot47_encoder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Podaj tekst do zaszyfrowania przez algorytm ROT47");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetWindowSize(77, 20);
            string tekst = Console.ReadLine();
            int rozmiar = tekst.Length;
            char[] tablica = new char[rozmiar];
            tablica = tekst.ToCharArray();
            int x;

            for (x = 0; x < rozmiar; x++)                // SZYFROWANIE ROT47
            {
                char litera = tablica[x];
                if ((int)litera >= 33 && (int)litera <= 126)    // jesli znak z przedzialu od 33 do 126
                {
                    int wartosc = 0;
                    if ((int)litera <= 79)              // bo 80 + 47 daje 127 znak (a my mamy przedzial do 126 znakow)
                    {
                        wartosc = (int)litera + 47;
                    }
                    else
                    {
                        wartosc = ((int)litera + 47) - 94;    // przetestowane dla malej litery a bo 97+47-94 daje 50(czyli 2)
                    }
                    tablica[x] = (char)wartosc;
                }
                else
                {
                    tablica[x] = (char)litera;
                }
            }

            Console.WriteLine("\nZaszyfrowany tekst przy pomocy ROT47:");
            Console.ForegroundColor = ConsoleColor.Red;
            for (x = 0; x < rozmiar; x++)
            {
                Console.Write(tablica[x]);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\nNaciśnij dowolny klawisz...");
            Console.ReadKey();
        }
    }
}
