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


    }

    class Program
    {
        static void Main(string[] args)
        { 
            Console.WriteLine("Podaj tekst do zaszyfrowania przez ROT13");
            Console.SetWindowSize(77, 20);
            string tekst = Console.ReadLine();
            int rozmiar = tekst.Length;
            char[] tablica = new char[rozmiar];
            char[] tablica_znakowa = new char[26];
            tablica = tekst.ToCharArray();
            int x;
            char znak = 'm';

            for(x = 0; x < 26; x++)   // tablica znakow
            {
                int wartosc = (int)znak;       
                if (znak == 'z')
                {
                    wartosc = (int)'a';
                    wartosc -= 1;
                }
                wartosc += 1;
                znak = (char)wartosc;
                tablica_znakowa[x] = znak;
            }
            // tablica_znakowa[25] = m

            for(x = 0; x < rozmiar; x++)
            {
                char litera = tablica[x];


            }
            Console.ReadKey();
        }
    }
}
