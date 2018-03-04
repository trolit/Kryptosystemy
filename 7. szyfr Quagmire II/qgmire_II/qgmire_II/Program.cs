using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qgmire_II
{
    class Quagmire
    {
        public static string uzupelnijAlfabet(string a)
        {
            string w = "";
            for (int i = 0; i < a.Length; i++)
                if (w.IndexOf(a[i]) == -1)
                    w += a[i];
            for (char i = 'A'; i <= 'Z'; i++)
                if (w.IndexOf(i) == -1)
                    w += i;
            return w;
        }

        public static string[] utworzTabele(string alfabet, string klucz)
        {
            string[] tabela = new string[klucz.Length];
            for (int i = 0; i < klucz.Length; i++)
            {
                int znak = alfabet.IndexOf(klucz[i]);
                tabela[i] = "";
                for (int j = 0; j < 26; j++)
                {
                    tabela[i] += alfabet[znak];
                    znak = (znak + 1) % 26;
                }
            }
            return tabela;
        }

        public static string szyfruj(string tekst, string alfabet, string[] tabela, int n)
        {
            string w = "";
            for (int i = 0; i < tekst.Length; i++)
            {
                int pozycja = tekst[i] - 'A';
                w += tabela[i % n][pozycja];
            }
            return w;
        }

        public static string rozszyfruj(string tekst, string alfabet, string[] tabela, int n)
        {
            string w = "";
            for (int i = 0; i < tekst.Length; i++)
            {
                int pozycja = tabela[i % n].IndexOf(tekst[i]);
                w += (char)(pozycja + 'A');
            }
            return w;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Szyfrownie Quagmire II");
            Console.WriteLine("źródło implementacji: mattomatti");

            string haslo = "", klucz = "", tekst = "";
            Console.Write("Podaj słowo szyfrujące: ");
            haslo = Console.ReadLine();
            string alfabet = Quagmire.uzupelnijAlfabet(haslo);
            Console.Write("Podaj słowo klucz: ");
            klucz = Console.ReadLine();
            string[] tabela = Quagmire.utworzTabele(alfabet, klucz);
            Console.Write("Podaj tekst do zaszyfrowania: ");
            tekst = Console.ReadLine();
            string szyfrogram = Quagmire.szyfruj(tekst, alfabet, tabela, klucz.Length);
            string tekstJawny = Quagmire.rozszyfruj(szyfrogram, alfabet, tabela, klucz.Length);
            Console.Write("\nSzyfrogram to: {0}\n", szyfrogram);
            Console.Write("\nPo rozszyfrowaniu: {0}\n", tekstJawny);
            Console.ReadKey();

            Console.WriteLine("Nacisnij klawisz aby zakonczyc dzialanie programu...");
            Console.ReadKey();
        }
    }
}
