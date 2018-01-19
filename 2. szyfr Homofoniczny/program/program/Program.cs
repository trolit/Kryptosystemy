using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Threading;

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
            bool niepusty;

            if(zmienna != 0)
            {
                niepusty = true;
            }
            else
            {
                niepusty = false;
            }

            return niepusty;
        }

        public void WypelnijHomofonami(int[] tablica, int rozmiar)
        {
            Random rnd = new Random();
            int x, i;

            for (x = 0; x < rozmiar; x++)
            {
                RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
                var byteArray = new byte[4];
                provider.GetBytes(byteArray);

                //convert 4 bytes to an integer
                var randomInteger = BitConverter.ToUInt32(byteArray, 0);

                for (i = 0; i < rozmiar; i++)
                {
                    if (tablica[i] != randomInteger)   // szukamy czy takiej wartości już nie ma...
                    {
                        i++;
                        NieZnalezionoTakiejSamejLiczby = true;
                    }
                    else if (tablica[i] == randomInteger)
                    {
                        NieZnalezionoTakiejSamejLiczby = false;
                        continue;                  // idziemy dalej (po co reszte przeszukiwać...)
                    }
                }
                if (NieZnalezionoTakiejSamejLiczby)
                {
                    tablica[x] = (int)randomInteger;
                }
            }
        }

        public int ZliczajWystapieniaLitery(char SprawdzCotoZaLitera, char OczekiwanaLitera, int LiczbaWystapienLitery)
        {
            if (SprawdzCotoZaLitera == OczekiwanaLitera)
            {
                LiczbaWystapienLitery++;
            }
            else
            {
                // nie rób nic
            }
            return LiczbaWystapienLitery;
        }

        public int WylosujHomofondlaLitery(int[] tablicaHomofonowa, int rozmiarTablicyHomofonowej)
        {
            Random rnd = new Random();
            int randomize = rnd.Next(0, rozmiarTablicyHomofonowej);
            // ma problem gdy dana litera jest tylko jeden raz bo jak wylosowac od 1,1 - wszystkie litery na 1 ustawic??
            while(randomize > rozmiarTablicyHomofonowej)
            {
                randomize = rnd.Next(0, rozmiarTablicyHomofonowej);
            }
            return tablicaHomofonowa[randomize];   
        }

        
    }
    class Program
    {
        static void Main(string[] args)
        {
            Encryption obiekt = new Encryption();

            int A = 1, B = 1, C = 1, D = 1, E = 1, F = 1, G = 1, H = 1, I = 1, J = 1, K = 1, L = 1, M = 1, N = 1, O = 1, P = 1, Q = 1, R = 1, S = 1, T = 1, U = 1, W = 1, X = 1, Y = 1, Z = 1;
            Console.WriteLine("Szyfr homofoniczny(inspirowany Beale'm)");
            Console.WriteLine("Podaj informacje ktora chcesz zaszyfrować");
            Console.WriteLine("-uwaga: ???");
            Console.WriteLine("-----------------------------------------------------------------");
            string tekst = Console.ReadLine();              // bierzemy tekst
            int rozmiar = tekst.Length;                     // rozmiar tekstu
            char[] tablica = new char[rozmiar];
            int[] zaszyfrowana = new int[rozmiar];
            tablica = tekst.ToCharArray();
            int x;
            bool ignoruj = false;

            for (x = 0; x < rozmiar; x++)                        // zliczamy ile danych liter wystąpiło
            {
                char sprawdz = tablica[x];
                if((int)sprawdz >= 97 && (int)sprawdz <= 122 && ignoruj == false)
                {
                    Console.WriteLine("!#!#!##!#!#!#!#!#!#!#!#!#!#!#!#!#!#!#!#!#!#!#!#!#!##!##!##!!#!##!#!!#");
                    Console.WriteLine("Zauważyliśy, że twój szyfr zawiera małe litery");
                    Console.WriteLine("Co chcesz zrobić?");
                    Console.WriteLine("1. zamień wszystkie małe litery na duże");
                    Console.WriteLine("2. ignoruj blad(twój szyfr może nie mieć wszystkich liter!)");
                    Console.WriteLine("!#!#!##!#!#!#!#!#!#!#!#!#!#!#!#!#!#!#!#!#!#!#!#!#!##!##!##!!#!##!#!!#");
                    int decyzja = Convert.ToInt32(Console.ReadLine());
                    if(decyzja == 1)
                    {
                        int i;
                        for(i = 0; i < rozmiar; i++)
                        {
                            char znak = tablica[i];
                            if((int)znak >= 97 && (int)znak <= 122)
                            {
                                tablica[i] = char.ToUpper(znak);
                            }
                        }
                        Console.Write("\nDokonywanie konwersji");
                        Thread.Sleep(500);
                        Console.Write(".");
                        Thread.Sleep(600);
                        Console.Write(".");
                        Thread.Sleep(700);
                        Console.Write(".\n");
                    }
                    else if(decyzja == 2)
                    {
                        ignoruj = true; // ignorujemy male litery
                    }
                }
                #region Zliczamy wystapienia liter
                A = obiekt.ZliczajWystapieniaLitery(sprawdz, 'A', A);
                B = obiekt.ZliczajWystapieniaLitery(sprawdz, 'B', B);
                C = obiekt.ZliczajWystapieniaLitery(sprawdz, 'C', C);
                D = obiekt.ZliczajWystapieniaLitery(sprawdz, 'D', D);
                E = obiekt.ZliczajWystapieniaLitery(sprawdz, 'E', E);
                F = obiekt.ZliczajWystapieniaLitery(sprawdz, 'F', F);
                G = obiekt.ZliczajWystapieniaLitery(sprawdz, 'G', G);
                H = obiekt.ZliczajWystapieniaLitery(sprawdz, 'H', H);
                I = obiekt.ZliczajWystapieniaLitery(sprawdz, 'I', I);
                J = obiekt.ZliczajWystapieniaLitery(sprawdz, 'J', J);
                K = obiekt.ZliczajWystapieniaLitery(sprawdz, 'K', K);
                L = obiekt.ZliczajWystapieniaLitery(sprawdz, 'L', L);
                M = obiekt.ZliczajWystapieniaLitery(sprawdz, 'M', M);
                N = obiekt.ZliczajWystapieniaLitery(sprawdz, 'N', N);
                O = obiekt.ZliczajWystapieniaLitery(sprawdz, 'O', O);
                P = obiekt.ZliczajWystapieniaLitery(sprawdz, 'P', P);
                Q = obiekt.ZliczajWystapieniaLitery(sprawdz, 'Q', Q);
                R = obiekt.ZliczajWystapieniaLitery(sprawdz, 'R', R);
                S = obiekt.ZliczajWystapieniaLitery(sprawdz, 'S', S);
                T = obiekt.ZliczajWystapieniaLitery(sprawdz, 'T', T);
                U = obiekt.ZliczajWystapieniaLitery(sprawdz, 'U', U);
                W = obiekt.ZliczajWystapieniaLitery(sprawdz, 'W', W);
                X = obiekt.ZliczajWystapieniaLitery(sprawdz, 'X', X);
                Y = obiekt.ZliczajWystapieniaLitery(sprawdz, 'Y', Y);
                Z = obiekt.ZliczajWystapieniaLitery(sprawdz, 'Z', Z);
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

            #region Losujemy dla liter homofony
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
            if (obiekt.NieJestPusty(F))
            {
                obiekt.WypelnijHomofonami(F_tab, F);
            }
            if (obiekt.NieJestPusty(G))
            {
                obiekt.WypelnijHomofonami(G_tab, G);
            }
            if (obiekt.NieJestPusty(H))
            {
                obiekt.WypelnijHomofonami(H_tab, H);
            }
            if (obiekt.NieJestPusty(I))
            {
                obiekt.WypelnijHomofonami(I_tab, I);
            }
            if (obiekt.NieJestPusty(J))
            {
                obiekt.WypelnijHomofonami(J_tab, J);
            }
            if (obiekt.NieJestPusty(K))
            {
                obiekt.WypelnijHomofonami(K_tab, K);
            }
            if (obiekt.NieJestPusty(L))
            {
                obiekt.WypelnijHomofonami(L_tab, L);
            }
            if (obiekt.NieJestPusty(M))
            {
                obiekt.WypelnijHomofonami(M_tab, M);
            }
            if (obiekt.NieJestPusty(N))
            {
                obiekt.WypelnijHomofonami(N_tab, N);
            }
            if (obiekt.NieJestPusty(O))
            {
                obiekt.WypelnijHomofonami(O_tab, O);
            }
            if (obiekt.NieJestPusty(P))
            {
                obiekt.WypelnijHomofonami(P_tab, P);
            }
            if (obiekt.NieJestPusty(Q))
            {
                obiekt.WypelnijHomofonami(Q_tab, Q);
            }
            if (obiekt.NieJestPusty(R))
            {
                obiekt.WypelnijHomofonami(R_tab, R);
            }
            if (obiekt.NieJestPusty(S))
            {
                obiekt.WypelnijHomofonami(S_tab, S);
            }
            if (obiekt.NieJestPusty(T))
            {
                obiekt.WypelnijHomofonami(T_tab, T);
            }
            if (obiekt.NieJestPusty(U))
            {
                obiekt.WypelnijHomofonami(U_tab, U);
            }
            if (obiekt.NieJestPusty(W))
            {
                obiekt.WypelnijHomofonami(W_tab, W);
            }
            if (obiekt.NieJestPusty(X))
            {
                obiekt.WypelnijHomofonami(X_tab, X);
            }
            if (obiekt.NieJestPusty(Y))
            {
                obiekt.WypelnijHomofonami(Y_tab, Y);
            }
            if (obiekt.NieJestPusty(Z))
            {
                obiekt.WypelnijHomofonami(Z_tab, Z);
            }
            #endregion

            for(x = 0; x < rozmiar; x++)
            {
                char Literadozaszyfrowania = tablica[x];

                #region Sprawdzamy co to za litera
                if(Literadozaszyfrowania == 'A')
                {
                    zaszyfrowana[x] = obiekt.WylosujHomofondlaLitery(A_tab, A);
                }
                else if(Literadozaszyfrowania == 'B')
                {
                    zaszyfrowana[x] = obiekt.WylosujHomofondlaLitery(B_tab, B);
                }
                else if (Literadozaszyfrowania == 'C')
                {
                    zaszyfrowana[x] = obiekt.WylosujHomofondlaLitery(C_tab, C);
                }
                else if (Literadozaszyfrowania == 'D')
                {
                    zaszyfrowana[x] = obiekt.WylosujHomofondlaLitery(D_tab, D);
                }
                else if (Literadozaszyfrowania == 'E')
                {
                    zaszyfrowana[x] = obiekt.WylosujHomofondlaLitery(E_tab, E);
                }
                else if (Literadozaszyfrowania == 'F')
                {
                    zaszyfrowana[x] = obiekt.WylosujHomofondlaLitery(F_tab, F);
                }
                else if (Literadozaszyfrowania == 'G')
                {
                    zaszyfrowana[x] = obiekt.WylosujHomofondlaLitery(G_tab, G);
                }
                else if (Literadozaszyfrowania == 'H')
                {
                    zaszyfrowana[x] = obiekt.WylosujHomofondlaLitery(H_tab, H);
                }
                else if (Literadozaszyfrowania == 'I')
                {
                    zaszyfrowana[x] = obiekt.WylosujHomofondlaLitery(I_tab, I);
                }
                else if (Literadozaszyfrowania == 'J')
                {
                    zaszyfrowana[x] = obiekt.WylosujHomofondlaLitery(J_tab, J);
                }
                else if (Literadozaszyfrowania == 'K')
                {
                    zaszyfrowana[x] = obiekt.WylosujHomofondlaLitery(K_tab, K);
                }
                else if (Literadozaszyfrowania == 'L')
                {
                    zaszyfrowana[x] = obiekt.WylosujHomofondlaLitery(L_tab, L);
                }
                else if (Literadozaszyfrowania == 'M')
                {
                    zaszyfrowana[x] = obiekt.WylosujHomofondlaLitery(M_tab, M);
                }
                else if (Literadozaszyfrowania == 'N')
                {
                    zaszyfrowana[x] = obiekt.WylosujHomofondlaLitery(N_tab, N);
                }
                else if (Literadozaszyfrowania == 'O')
                {
                    zaszyfrowana[x] = obiekt.WylosujHomofondlaLitery(O_tab, O);
                }
                else if (Literadozaszyfrowania == 'P')
                {
                    zaszyfrowana[x] = obiekt.WylosujHomofondlaLitery(P_tab, P);
                }
                else if (Literadozaszyfrowania == 'Q')
                {
                    zaszyfrowana[x] = obiekt.WylosujHomofondlaLitery(Q_tab, Q);
                }
                else if (Literadozaszyfrowania == 'R')
                {
                    zaszyfrowana[x] = obiekt.WylosujHomofondlaLitery(R_tab, R);
                }
                else if (Literadozaszyfrowania == 'S')
                {
                    zaszyfrowana[x] = obiekt.WylosujHomofondlaLitery(S_tab, S);
                }
                else if (Literadozaszyfrowania == 'T')
                {
                    zaszyfrowana[x] = obiekt.WylosujHomofondlaLitery(T_tab, T);
                }
                else if (Literadozaszyfrowania == 'U')
                {
                    zaszyfrowana[x] = obiekt.WylosujHomofondlaLitery(U_tab, U);
                }
                else if (Literadozaszyfrowania == 'W')
                {
                    zaszyfrowana[x] = obiekt.WylosujHomofondlaLitery(W_tab, W);
                }
                else if (Literadozaszyfrowania == 'X')
                {
                    zaszyfrowana[x] = obiekt.WylosujHomofondlaLitery(X_tab, X);
                }
                else if (Literadozaszyfrowania == 'Y')
                {
                    zaszyfrowana[x] = obiekt.WylosujHomofondlaLitery(Y_tab, Y);
                }
                else if (Literadozaszyfrowania == 'Z')
                {
                    zaszyfrowana[x] = obiekt.WylosujHomofondlaLitery(Z_tab, Z);
                }
                else
                {
                    // nie rób nic
                }
                #endregion
            }

            FileStream msg = new FileStream("msg.txt", FileMode.Create, FileAccess.Write);
            StreamWriter przepisz = new StreamWriter(msg);
            for(x = 0; x < rozmiar; x++)
            {
                przepisz.Write(zaszyfrowana[x] + " ");
            }          
            przepisz.Close();
            msg.Close(); // zamykamy plik

            FileStream code = new FileStream("kodowanie.txt", FileMode.Create, FileAccess.Write);
            StreamWriter przepisz_kod = new StreamWriter(code);
            przepisz_kod.Write("PLIK ZAWIERA KOD ODCZYTANIA SZYFRU\r\n");
            przepisz_kod.Write("Data utworzenia szyfru:\r\n");
            przepisz_kod.Write(DateTime.Now.ToString("HH:mm:ss\r\n"));
            przepisz_kod.Write(DateTime.Today.ToString("dd-MM-yyyy\r\n"));
            przepisz_kod.Write("\r\n");
            przepisz_kod.Write("==========================================");
            przepisz_kod.Write("\r\n");
            przepisz_kod.Write("A -> { ");
            for(x = 0; x < A; x++)
            {
                przepisz_kod.Write(A_tab[x] + ", ");
            }
            przepisz_kod.Write(" }\r\n");
            przepisz_kod.Write("==========================================");
            przepisz_kod.Write("\r\n");
            przepisz_kod.Write("B -> { ");
            for (x = 0; x < B; x++)
            {
                przepisz_kod.Write(B_tab[x] + ", ");
            }
            przepisz_kod.Write(" }\r\n");
            przepisz_kod.Write("==========================================");
            przepisz_kod.Write("\r\n");
            przepisz_kod.Write("C -> { ");
            for (x = 0; x < C; x++)
            {
                przepisz_kod.Write(C_tab[x] + ", ");
            }
            przepisz_kod.Write(" }\r\n");
            przepisz_kod.Write("==========================================");
            przepisz_kod.Write("\r\n");
            przepisz_kod.Write("D -> { ");
            for (x = 0; x < D; x++)
            {
                przepisz_kod.Write(D_tab[x] + ", ");
            }
            przepisz_kod.Write(" }\r\n");
            przepisz_kod.Write("==========================================");
            przepisz_kod.Write("\r\n");
            przepisz_kod.Write("E -> { ");
            for (x = 0; x < E; x++)
            {
                przepisz_kod.Write(E_tab[x] + ", ");
            }
            przepisz_kod.Write(" }\r\n");
            przepisz_kod.Write("==========================================");
            przepisz_kod.Write("\r\n");
            przepisz_kod.Write("F -> { ");
            for (x = 0; x < F; x++)
            {
                przepisz_kod.Write(F_tab[x] + ", ");
            }
            przepisz_kod.Write(" }\r\n");
            przepisz_kod.Write("==========================================");
            przepisz_kod.Write("\r\n");
            przepisz_kod.Write("G -> { ");
            for (x = 0; x < G; x++)
            {
                przepisz_kod.Write(G_tab[x] + ", ");
            }
            przepisz_kod.Write(" }\r\n");
            przepisz_kod.Write("==========================================");
            przepisz_kod.Write("\r\n");
            przepisz_kod.Write("H -> { ");
            for (x = 0; x < H; x++)
            {
                przepisz_kod.Write(H_tab[x] + ", ");
            }
            przepisz_kod.Write(" }\r\n");
            przepisz_kod.Write("==========================================");
            przepisz_kod.Write("\r\n");
            przepisz_kod.Write("I -> { ");
            for (x = 0; x < I; x++)
            {
                przepisz_kod.Write(I_tab[x] + ", ");
            }
            przepisz_kod.Write(" }\r\n");
            przepisz_kod.Write("==========================================");
            przepisz_kod.Write("\r\n");
            przepisz_kod.Write("J -> { ");
            for (x = 0; x < J; x++)
            {
                przepisz_kod.Write(J_tab[x] + ", ");
            }
            przepisz_kod.Write(" }\r\n");
            przepisz_kod.Write("==========================================");
            przepisz_kod.Write("\r\n");
            przepisz_kod.Write("K -> { ");
            for (x = 0; x < K; x++)
            {
                przepisz_kod.Write(K_tab[x] + ", ");
            }
            przepisz_kod.Write(" }\r\n");
            przepisz_kod.Write("==========================================");
            przepisz_kod.Write("\r\n");
            przepisz_kod.Write("L -> { ");
            for (x = 0; x < L; x++)
            {
                przepisz_kod.Write(L_tab[x] + ", ");
            }
            przepisz_kod.Write(" }\r\n");
            przepisz_kod.Write("==========================================");
            przepisz_kod.Write("\r\n");
            przepisz_kod.Write("M -> { ");
            for (x = 0; x < M; x++)
            {
                przepisz_kod.Write(M_tab[x] + ", ");
            }
            przepisz_kod.Write(" }\r\n");
            przepisz_kod.Write("==========================================");
            przepisz_kod.Write("\r\n");
            przepisz_kod.Write("N -> { ");
            for (x = 0; x < N; x++)
            {
                przepisz_kod.Write(N_tab[x] + ", ");
            }
            przepisz_kod.Write(" }\r\n");
            przepisz_kod.Write("==========================================");
            przepisz_kod.Write("\r\n");
            przepisz_kod.Write("O -> { ");
            for (x = 0; x < O; x++)
            {
                przepisz_kod.Write(O_tab[x] + ", ");
            }
            przepisz_kod.Write(" }\r\n");
            przepisz_kod.Write("==========================================");
            przepisz_kod.Write("\r\n");
            przepisz_kod.Write("P -> { ");
            for (x = 0; x < P; x++)
            {
                przepisz_kod.Write(P_tab[x] + ", ");
            }
            przepisz_kod.Write(" }\r\n");
            przepisz_kod.Write("==========================================");
            przepisz_kod.Write("\r\n");
            przepisz_kod.Write("Q -> { ");
            for (x = 0; x < Q; x++)
            {
                przepisz_kod.Write(Q_tab[x] + ", ");
            }
            przepisz_kod.Write(" }\r\n");
            przepisz_kod.Write("==========================================");
            przepisz_kod.Write("\r\n");
            przepisz_kod.Write("R -> { ");
            for (x = 0; x < R; x++)
            {
                przepisz_kod.Write(R_tab[x] + ", ");
            }
            przepisz_kod.Write(" }\r\n");
            przepisz_kod.Write("==========================================");
            przepisz_kod.Write("\r\n");
            przepisz_kod.Write("S -> { ");
            for (x = 0; x < S; x++)
            {
                przepisz_kod.Write(S_tab[x] + ", ");
            }
            przepisz_kod.Write(" }\r\n");
            przepisz_kod.Write("==========================================");
            przepisz_kod.Write("\r\n");
            przepisz_kod.Write("T -> { ");
            for (x = 0; x < T; x++)
            {
                przepisz_kod.Write(T_tab[x] + ", ");
            }
            przepisz_kod.Write(" }\r\n");
            przepisz_kod.Write("==========================================");
            przepisz_kod.Write("\r\n");
            przepisz_kod.Write("U -> { ");
            for (x = 0; x < U; x++)
            {
                przepisz_kod.Write(U_tab[x] + ", ");
            }
            przepisz_kod.Write(" }\r\n");
            przepisz_kod.Write("==========================================");
            przepisz_kod.Write("\r\n");
            przepisz_kod.Write("W -> { ");
            for (x = 0; x < W; x++)
            {
                przepisz_kod.Write(W_tab[x] + ", ");
            }
            przepisz_kod.Write(" }\r\n");
            przepisz_kod.Write("==========================================");
            przepisz_kod.Write("\r\n");
            przepisz_kod.Write("X -> { ");
            for (x = 0; x < X; x++)
            {
                przepisz_kod.Write(X_tab[x] + ", ");
            }
            przepisz_kod.Write(" }\r\n");
            przepisz_kod.Write("==========================================");
            przepisz_kod.Write("\r\n");
            przepisz_kod.Write("Y -> { ");
            for (x = 0; x < Y; x++)
            {
                przepisz_kod.Write(Y_tab[x] + ", ");
            }
            przepisz_kod.Write(" }\r\n");
            przepisz_kod.Write("==========================================");
            przepisz_kod.Write("\r\n");
            przepisz_kod.Write("Z -> { ");
            for (x = 0; x < Z; x++)
            {
                przepisz_kod.Write(Z_tab[x] + ", ");
            }
            przepisz_kod.Write(" }\r\n");
            przepisz_kod.Write("==========================================");
            przepisz_kod.Write("\r\n");
            przepisz_kod.Write("\r\n");
            przepisz_kod.Write("koniec wiadomosci....");
            przepisz_kod.Close();
            code.Close();

            Console.Write("\nSzyfrowanie podanej wiadomości");
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(600);
            Console.Write(".");
            Thread.Sleep(600);
            Console.Write(".");
            Thread.Sleep(800);
            Console.Write("       -> OK");
            Console.Write("\nZapisywanie do pliku msg.txt");
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(600);
            Console.Write(".");
            Thread.Sleep(600);
            Console.Write(".");
            Thread.Sleep(800);
            Console.Write("         -> OK");
            Console.Write("\nZapisywanie do pliku kodowanie.txt");
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(600);
            Console.Write(".");
            Thread.Sleep(600);
            Console.Write(".");
            Thread.Sleep(800);
            Console.Write("   -> OK\n");

            Console.WriteLine("\n------------------------------------>");
            Console.WriteLine("Tekst zaszyfrowany pomyślnie!");
            Console.WriteLine("Uwaga:");
            Console.WriteLine("Zaszyfrowany tekst został zapisany do pliku msg.txt");
            Console.WriteLine("Kod niezbędny do odszyfrowania wiadomości znajduje się w pliku kodowanie.txt");
            Console.WriteLine("------------------------------------>");

            

            Console.WriteLine("Naciśnij dowolny klawisz aby zakończyć...");
            Console.ReadKey();
        }
    }
}
