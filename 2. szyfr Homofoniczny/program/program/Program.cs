using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{
    // szyfr homomofoniczny(bez polskich znaków)
    // załóżmy że pierwszy program będzie miał możliwość obsługi do 100 homofonów max dla każdej litery
    // oparty na prostocie w celu zrozumienia działania 

    class Program
    {
        static void Main(string[] args)
        {
            int A = 0, B = 0, C = 0, D = 0, E = 0, F = 0, G = 0, H = 0, I = 0, J = 0, K = 0, L = 0, M = 0, N = 0, O = 0, P = 0, Q = 0, R = 0, S = 0, T = 0, U = 0, W = 0, X = 0, Y = 0, Z = 0;
            Console.WriteLine("Szyfr homomofoniczny(inspirowany Beale'm");
            Console.WriteLine("Podaj informacje ktora chcesz zaszyfrować");
            Console.WriteLine("-uwaga: narazie max wystąpienie danej litery to 100");
            Console.WriteLine("-uwaga: tylko DUŻE litery, bez polskich znaków");
            string tekst = Console.ReadLine();
            int rozmiar = tekst.Length;  // rozmiar tekstu
            char[] tablica = new char[rozmiar];
            tablica = tekst.ToCharArray();
            int x; // indeks

            for(x = 0; x < rozmiar; x++)
            {
                char sprawdz = tablica[x];
                #region No trzeba no....
                if (sprawdz == 'A')
                {
                    A++;
                }
                else if (sprawdz == 'B')
                {
                    B++;
                }
                else if (sprawdz == 'C')
                {
                    C++;
                }
                else if (sprawdz == 'D')
                {
                    D++;
                }
                else if (sprawdz == 'E')
                {
                    E++;
                }
                #endregion
            }
        }
    }
}
