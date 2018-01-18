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
    
    class Encryption
    {
        bool NieZnalezionoTakiejSamejLiczby = false;



        public bool NieJestPusty(int zmienna)
        {
            bool pusty;

            if(zmienna != 0)
            {
                pusty = false;
            }
            else
            {
                pusty = true;
            }

            return pusty;
        }

        public void WypelnijHomofonami(int[] tablica, int rozmiar)
        {
            Random rnd = new Random();
            int x, i;

            for (x = 0; x < rozmiar; x++)
            {
                int randomize = rnd.Next(1, 100);
                for (i = 0; i < rozmiar; i++)
                {
                    if (tablica[i] != randomize)   // szukamy czy takiej wartości już nie ma...
                    {
                        i++;
                        NieZnalezionoTakiejSamejLiczby = true;
                    }
                    else if (tablica[i] == randomize)
                    {
                        NieZnalezionoTakiejSamejLiczby = false;
                        continue;                  // idziemy dalej (po co reszte przeszukiwać...)
                    }
                }
                if (NieZnalezionoTakiejSamejLiczby)
                {
                    tablica[x] = randomize;
                }
            }
        }

        public void ZliczajWystapieniaLitery(char SprawdzCotoZaLitera, char OczekiwanaLitera, int LiczbaWystapienLitery)
        {
            if (SprawdzCotoZaLitera == OczekiwanaLitera)
            {
                LiczbaWystapienLitery++;
            }
            else
            {
                // nie rób nic
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Encryption obiekt = new Encryption();

            int A = 0, B = 0, C = 0, D = 0, E = 0, F = 0, G = 0, H = 0, I = 0, J = 0, K = 0, L = 0, M = 0, N = 0, O = 0, P = 0, Q = 0, R = 0, S = 0, T = 0, U = 0, W = 0, X = 0, Y = 0, Z = 0;
            Console.WriteLine("Szyfr homofoniczny(inspirowany Beale'm)");
            Console.WriteLine("Podaj informacje ktora chcesz zaszyfrować");
            Console.WriteLine("-uwaga: narazie max wystąpienie danej litery to 100");
            Console.WriteLine("-uwaga: tylko DUŻE litery, bez polskich znaków");
            string tekst = Console.ReadLine();              // bierzemy tekst
            int rozmiar = tekst.Length;                     // rozmiar tekstu
            char[] tablica = new char[rozmiar];
            tablica = tekst.ToCharArray();
            int x;

            for (x = 0; x < rozmiar; x++)                        // zliczamy ile danych liter wystąpiło
            {
                char sprawdz = tablica[x];
                obiekt.ZliczajWystapieniaLitery(sprawdz, 'A', A);
                obiekt.ZliczajWystapieniaLitery(sprawdz, 'B', B);
                obiekt.ZliczajWystapieniaLitery(sprawdz, 'C', C);
                obiekt.ZliczajWystapieniaLitery(sprawdz, 'D', D);
                obiekt.ZliczajWystapieniaLitery(sprawdz, 'E', E);
                obiekt.ZliczajWystapieniaLitery(sprawdz, 'F', F);
                obiekt.ZliczajWystapieniaLitery(sprawdz, 'G', G);
                obiekt.ZliczajWystapieniaLitery(sprawdz, 'H', H);
                obiekt.ZliczajWystapieniaLitery(sprawdz, 'I', I);
                obiekt.ZliczajWystapieniaLitery(sprawdz, 'J', J);
                obiekt.ZliczajWystapieniaLitery(sprawdz, 'K', K);
                obiekt.ZliczajWystapieniaLitery(sprawdz, 'L', L);
                obiekt.ZliczajWystapieniaLitery(sprawdz, 'M', M);
                obiekt.ZliczajWystapieniaLitery(sprawdz, 'N', N);
                obiekt.ZliczajWystapieniaLitery(sprawdz, 'O', O);
                obiekt.ZliczajWystapieniaLitery(sprawdz, 'P', P);
                obiekt.ZliczajWystapieniaLitery(sprawdz, 'Q', Q);
                obiekt.ZliczajWystapieniaLitery(sprawdz, 'R', R);
                obiekt.ZliczajWystapieniaLitery(sprawdz, 'S', S);
                obiekt.ZliczajWystapieniaLitery(sprawdz, 'T', T);
                obiekt.ZliczajWystapieniaLitery(sprawdz, 'U', U);
                obiekt.ZliczajWystapieniaLitery(sprawdz, 'W', W);
                obiekt.ZliczajWystapieniaLitery(sprawdz, 'X', X);
                obiekt.ZliczajWystapieniaLitery(sprawdz, 'Y', Y);
                obiekt.ZliczajWystapieniaLitery(sprawdz, 'Z', Z);
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

            if (obiekt.NieJestPusty(A))
            {
                obiekt.WypelnijHomofonami(A_tab, A);
            }
            if (obiekt.NieJestPusty(B))
            {
                obiekt.WypelnijHomofonami(B_tab, B);
            }
            if (obiekt.NieJestPusty(C))
            {
                obiekt.WypelnijHomofonami(C_tab, C);
            }
            if (obiekt.NieJestPusty(D))
            {
                obiekt.WypelnijHomofonami(D_tab, D);
            }
            if (obiekt.NieJestPusty(E))
            {
                obiekt.WypelnijHomofonami(E_tab, E);
            }



            Console.WriteLine("Naciśnij dowolny klawisz aby zakończyć...");
            Console.ReadKey();
        }
    }
}
