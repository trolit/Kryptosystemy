using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rot13_program
{
    // ROT13 - Polega na tym, że przesuwamy litery w alfabecie o +13 w prawo

    class ROT13
    {
        // pusto

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Podaj tekst do zaszyfrowania przez algorytm ROT13");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetWindowSize(77, 20);
            string tekst = Console.ReadLine();
            int rozmiar = tekst.Length;
            char[] tablica = new char[rozmiar];
            tablica = tekst.ToCharArray();
            int x;

            for(x = 0; x < rozmiar; x++)                // SZYFROWANIE ROT13
            {
                char litera = tablica[x];
                if(litera >= 97 && litera <= 122)
                {
                    int wartosc = (int)litera + 13;
                    if(wartosc > 122)
                    {
                        wartosc -= 26;
                    }
                    tablica[x] = (char)wartosc;
                }
                else if(litera >= 65 && litera <= 90)
                {
                    int wartosc = (int)litera + 13;
                    if(wartosc > 90)
                    {
                        wartosc -= 26;
                    }
                    tablica[x] = (char)wartosc;
                }
                else
                {
                    tablica[x] = (char)litera;
                }
            }

            Console.WriteLine("\nZaszyfrowany tekst przy pomocy ROT13:");
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
