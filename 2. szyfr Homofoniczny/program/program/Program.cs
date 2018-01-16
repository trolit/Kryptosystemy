using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{
    // szyfr homofoniczny(bez polskich znaków)
    // załóżmy że pierwszy program będzie miał możliwość obsługi do 100 homofonów max dla każdej litery
    // oparty na prostocie w celu zrozumienia działania 

    class Program
    {
        static void Main(string[] args)
        {
            int A = 0, B = 0, C = 0, D = 0, E = 0, F = 0, G = 0, H = 0, I = 0, J = 0, K = 0, L = 0, M = 0, N = 0, O = 0, P = 0, Q = 0, R = 0, S = 0, T = 0, U = 0, W = 0, X = 0, Y = 0, Z = 0;
            Console.WriteLine("Szyfr homofoniczny(inspirowany Beale'm");
            Console.WriteLine("Podaj informacje ktora chcesz zaszyfrować");
            Console.WriteLine("-uwaga: narazie max wystąpienie danej litery to 100");
            Console.WriteLine("-uwaga: tylko DUŻE litery, bez polskich znaków");
            string tekst = Console.ReadLine();
            int rozmiar = tekst.Length;  // rozmiar tekstu
            char[] tablica = new char[rozmiar];
            tablica = tekst.ToCharArray();
            int x, i; // indeks

            for (x = 0; x < rozmiar; x++)                        // zliczamy ile danych liter wystąpiło
            {
                char sprawdz = tablica[x];
                #region No trzeba no zliczyć ile tego jest....
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
                else if (sprawdz == 'F')
                {
                    F++;
                }
                else if (sprawdz == 'G')
                {
                    G++;
                }
                else if (sprawdz == 'H')
                {
                    H++;
                }
                else if (sprawdz == 'I')
                {
                    I++;
                }
                else if (sprawdz == 'J')
                {
                    J++;
                }
                else if (sprawdz == 'K')
                {
                    K++;
                }
                else if (sprawdz == 'L')
                {
                    L++;
                }
                else if (sprawdz == 'M')
                {
                    M++;
                }
                else if (sprawdz == 'N')
                {
                    N++;
                }
                else if (sprawdz == 'O')
                {
                    O++;
                }
                else if (sprawdz == 'P')
                {
                    P++;
                }
                else if (sprawdz == 'Q')
                {
                    Q++;
                }
                else if (sprawdz == 'R')
                {
                    R++;
                }
                else if (sprawdz == 'S')
                {
                    S++;
                }
                else if (sprawdz == 'T')
                {
                    T++;
                }
                else if (sprawdz == 'U')
                {
                    U++;
                }
                else if (sprawdz == 'W')
                {
                    W++;
                }
                else if (sprawdz == 'X')
                {
                    X++;
                }
                else if (sprawdz == 'Y')
                {
                    Y++;
                }
                else if (sprawdz == 'Z')
                {
                    Z++;
                }
                else
                {
                    // nie rob nic
                }
                #endregion
            }

            // tworzymy tablice homofonów
            #region -> pokaż <-
            int[] A_tab = new int[A];
            int[] B_tab = new int[B];
            int[] C_tab = new int[C];
            int[] D_tab = new int[D];
            int[] E_tab = new int[E];
            int[] F_tab = new int[F];
            int[] G_tab = new int[G];
            int[] H_tab = new int[H];
            int[] I_tab = new int[I];
            int[] J_tab = new int[J];
            int[] K_tab = new int[K];
            int[] L_tab = new int[L];
            int[] M_tab = new int[M];
            int[] N_tab = new int[N];
            int[] O_tab = new int[O];
            int[] P_tab = new int[P];
            int[] Q_tab = new int[Q];
            int[] R_tab = new int[R];
            int[] S_tab = new int[S];
            int[] T_tab = new int[T];
            int[] U_tab = new int[U];
            int[] W_tab = new int[W];
            int[] X_tab = new int[X];
            int[] Y_tab = new int[Y];
            int[] Z_tab = new int[Z];
            #endregion

            Random rnd = new Random();      // tworzymy obiekt z Random

            #region 1. Losowanie homofonów dla A
            for(x = 0; x < A; x++)
            {
                int randomize = rnd.Next(1, 100);
                for(i = 0; i < A; i++)
                {
                    if(A_tab[i] != randomize)   // szukamy czy takiej wartości już nie ma...
                    {
                        i++;
                    }
                    else if(A_tab[i] == randomize)
                    {
                        continue;
                    }
                }
                A_tab[x] = randomize;
            }
            #endregion
            #region 2. Losowanie homofonów dla B
            for (x = 0; x < B; x++)
            {
                int randomize = rnd.Next(1, 100);
                for (i = 0; i < B; i++)
                {
                    if (B_tab[i] != randomize)   // szukamy czy takiej wartości już nie ma...
                    {
                        i++;
                    }
                    else if (B_tab[i] == randomize)
                    {
                        continue;
                    }
                }
                B_tab[x] = randomize;
            }
            #endregion
        }
    }
}
