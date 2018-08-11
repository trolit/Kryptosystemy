using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


/*
    ======================
   |  ENIGMA - ULEPSZONA  |
    ======================

    Co nowego tu się pojawiło?
    - po podaniu pozycji dla wirnika1 obliczana zostaje odległość tej pozycji od 
    pierwszej litery alfabetu. Następnie tablica znaków zostaje obrócona o tyle 
    pozycji ile wynosiła wartość odległości ... dzięki czemu zapobiegliśmy sytuacji
    że druga litera koduje się w samą siebie
*/

namespace eni_one
{
    class EnigmaCore
    {
        //-------------------------------------------------------------------------------------------------//
        // Zmienne dla programu Enigma_sol2
        public char Rotor1_Position = '#';           // śledzi aktualną pozycję wirnika1  
        public char Rotor2_Position = '#';
        public char Rotor3_Position = '#';
        public bool Rotor2_rotate = false;           // domyślnie false!!!
        public bool Rotor3_rotate = false;           // domyślnie false!!!
        public int Value = 0;                        // przechowuje wartości liczbowe liter, domyślnie 0
        //-------------------------------------------------------------------------------------------------//

        // przelicz odległość 
        public int Count_Distance(char charGiven)
        {
            char firstLetter = 'A';

            int distance = (int)charGiven - (int)firstLetter;

            return distance;
        }

        public char[] Move_array(char[] array)
        {
            int i = 0;                               // zmienne pomocnicze
            int j = array.Length - 1;
            char tmp = array[j];                     // bierzemy ostatni znak
            array[i] = tmp;                          // ustawiamy go na początku tablicy
            int value = (int)array[0];               // rozmiar elementu, który stoi na początku tablicy
            for (i = 1; i < array.Length; i++)       // wypełniamy pozostałymi znakami tablicę
            {
                value += 1;
                if(value > 90)
                {
                    value -= 26;
                }
                array[i] = (char)value;
            }
            return array;
        }

        //-------------------------------------------------------------------------------------------------//
        // funkcja tłumacząca aktualnie badany znak na pozycję wirnika

        public int Return_RotorPositionNumber(char znak)
        {
            int[,] tablica_znakowa = new int[,] { { 65, 0 }, { 66, 1 }, { 67, 2 }, { 68, 3 }, { 69, 4 }, { 70, 5 }, { 71, 6 }, { 72, 7 }, { 73, 8 }, { 74, 9 }, { 75, 10 }, { 76, 11 }, { 77, 12 }, { 78, 13 }, { 79, 14 }, { 80, 15 }, { 81, 16 }, { 82, 17 }, { 83, 18 }, { 84, 19 }, { 85, 20 }, { 86, 21 }, { 87, 22 }, { 88, 23 }, { 89, 24 }, { 90, 25 } };
            int i = 0;

            // ps: jestem świadom, tego, że ta tablica nie musi być dwuwymiarowa
            // inkrementator i przecież będzie nam mówił w której pozycji jest
            // szukana litera, do przerobienia.

            for (i = 0; i < tablica_znakowa.Length; i++)
            {
                if ((int)znak == tablica_znakowa[i,0])
                {
                    break;
                }
                
            }
            return i;
        }

        //-------------------------------------------------------------------------------------------------//
        // Budowa funkcji: Rotor1, Rotor2, Rotor3 

        public void Rotor1_Encryption()
        {
            int local = (int)Rotor1_Position;        // zmienna tymczasowa local przechowująca pozycję wirnika1
            local += 3;                              // przesuwamy pozycje wirnika o 3
            Rotor1_Position = (char)local;           // ustawiamy w nalezytym miejscu wirnik

            if(Rotor1_Position > 'Z')                // po przekroczeniu pulapu
            {
                Rotor2_rotate = true;                // zezwol na obrot drugiego wirnika
                local = (int)Rotor1_Position;        // architektura wirnika 1 wykonuje obrót o 360*
                local -= 26;        
                Rotor1_Position = (char)local;       // spozycjonowanie wirnika1
            }
        }

        public char[] Rotor2_Encryption(char[] array)
        {
            Rotor2_rotate = false;
            int local = (int)Rotor2_Position;
            local += 1;
            Rotor2_Position = (char)local;

            array = Move_array(array);

            if(Rotor2_Position > 'Z')
            {
                Rotor3_rotate = true;
                local = (int)Rotor2_Position;
                local -= 26;
                Rotor2_Position = (char)local;
            }
            return array;
        }

        public char[] Rotor3_Encryption(char[] array)
        {
            Rotor3_rotate = false;
            int local = (int)Rotor3_Position;
            local += 1;
            Rotor3_Position = (char)local;

            array = Move_array(array);

            if (Rotor3_Position > 'Z')
            {
                local = (int)Rotor3_Position;
                local -= 26;
                Rotor3_Position = (char)local;
            }
            return array;
        }
    }
    class EnigmaAnalysis
    {
        //-------------------------------------------------------------------------------------------------//
        // Zmienne dla programu Enigma_sol2
        public char Rotor1_Position = '#';           // śledzi aktualną pozycję wirnika1  
        public char Rotor2_Position = '#';
        public char Rotor3_Position = '#';
        public bool Rotor2_rotate = false;           // domyślnie false!!!
        public bool Rotor3_rotate = false;           // domyślnie false!!!
        public int Value = 0;                        // przechowuje wartości liczbowe liter, domyślnie 0
                                                     //-------------------------------------------------------------------------------------------------//
        // przelicz odległość 
        public int Count_Distance(char charGiven)
        {
            char firstLetter = 'A';

            int distance = (int)charGiven - (int)firstLetter;

            return distance;
        }

        public char[] Move_array(char[] array)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("!> ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Stan tablicy przed przesunięciem: ");
            for (int x = 0; x < array.Length; x++)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write( array[x] + "|");
                Console.ForegroundColor = ConsoleColor.White;
            }

            int i = 0;                               // zmienne pomocnicze
            int j = array.Length - 1;
            char tmp = array[j];                     // bierzemy ostatni znak
            array[i] = tmp;                          // ustawiamy go na początku tablicy
            int value = (int)array[0];               // rozmiar elementu, który stoi na początku tablicy
            for (i = 1; i < array.Length; i++)       // wypełniamy pozostałymi znakami tablicę
            {
                value += 1;
                if (value > 90)
                {
                    value -= 26;
                }
                array[i] = (char)value;
            }
            Console.ReadKey();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("!> ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Stan tablicy po przesunięciu(obrócenie wirnika): ");
            for (int x = 0; x < array.Length; x++)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write( array[x] +"|");
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.ReadKey();
            Console.WriteLine();
            return array;
        }

        //-------------------------------------------------------------------------------------------------//
        // funkcja tłumacząca aktualnie badany znak na pozycję wirnika

        public int Return_RotorPositionNumber(char znak)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("!> ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Znak: " + znak + " - odpowiada numerowi: ???");
            int[,] tablica_znakowa = new int[,] { { 65, 0 }, { 66, 1 }, { 67, 2 }, { 68, 3 }, { 69, 4 }, { 70, 5 }, { 71, 6 }, { 72, 7 }, { 73, 8 }, { 74, 9 }, { 75, 10 }, { 76, 11 }, { 77, 12 }, { 78, 13 }, { 79, 14 }, { 80, 15 }, { 81, 16 }, { 82, 17 }, { 83, 18 }, { 84, 19 }, { 85, 20 }, { 86, 21 }, { 87, 22 }, { 88, 23 }, { 89, 24 }, { 90, 25 } };
            int i = 0;
            Console.ReadKey();
            // ps: jestem świadom, tego, że ta tablica nie musi być dwuwymiarowa
            // inkrementator i przecież będzie nam mówił w której pozycji jest
            // szukana litera, do przerobienia.

            for (i = 0; i < tablica_znakowa.Length; i++)
            {
                if ((int)znak == tablica_znakowa[i, 0])
                {
                    break;
                }

            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("!> ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Znak: " + znak + " - odpowiada numerowi: " + i);
            Console.ReadKey();

            return i;
        }

        //-------------------------------------------------------------------------------------------------//
        // Budowa funkcji: Rotor1, Rotor2, Rotor3 

        public void Rotor1_Encryption()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("!> ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Ostatnia pozycja wirnika 1: " + Rotor1_Position);
            Console.ReadKey();

            int local = (int)Rotor1_Position;        // zmienna tymczasowa local przechowująca pozycję wirnika1
            local += 3;                              // przesuwamy pozycje wirnika o 1
            Rotor1_Position = (char)local;           // ustawiamy w nalezytym miejscu wirnik

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("!> ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Nowa pozycja wirnika 1: " + Rotor1_Position);
            Console.ReadKey();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("!> ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Czy pozycja wirnika 1: " + Rotor1_Position + " > Z ?");
            Console.ReadKey();

            if (Rotor1_Position > 'Z')                // po przekroczeniu pulapu
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("-> TAK <-");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();

                Rotor2_rotate = true;                // zezwol na obrot drugiego wirnika
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("!> ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" Zezwol wirnikowi 2 na obrot");
                Console.ReadKey();

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("!> ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" Obróć wirnik 1 o 360* -> pozycja wirnika1: " + Rotor1_Position);
                Console.ReadKey();

                local = (int)Rotor1_Position;        // architektura wirnika 1 wykonuje obrót o 360*
                local -= 26;
                Rotor1_Position = (char)local;       // spozycjonowanie wirnika1

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("!> ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" Aktualna pozycja wirnika1: " + Rotor1_Position);
                Console.ReadKey();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("-> NIE <-");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
            }
        }

        public char[] Rotor2_Encryption(char[] array)
        {
            Rotor2_rotate = false;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("!> ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Ustaw obrot wirnika 2 na false");
            Console.ReadKey();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("!> ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Ostatnia pozycja wirnika 2: " + Rotor2_Position);
            Console.ReadKey();

            int local = (int)Rotor2_Position;
            local += 1;
            Rotor2_Position = (char)local;

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("!> ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Nowa pozycja wirnika 2: " + Rotor2_Position);
            Console.ReadKey();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("!> ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Przesuwanie elementow tablicy...");
            Console.ReadKey();
            array = Move_array(array);

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("!> ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Czy pozycja wirnika 2: " + Rotor2_Position + " > Z ?");
            Console.ReadKey();

            if (Rotor2_Position > 'Z')
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("-> TAK <-");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("!> ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" Zezwol wirnikowi 3 na obrot");
                Console.ReadKey();

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("!> ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" Obróć wirnik 2 o 360* -> pozycja wirnika2: " + Rotor2_Position);
                Console.ReadKey();

                Rotor3_rotate = true;
                local = (int)Rotor2_Position;
                local -= 26;
                Rotor2_Position = (char)local;

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("!> ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" Ostatnia pozycja wirnika2: " + Rotor2_Position);
                Console.ReadKey();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("-> NIE <-");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
            }

            return array;
        }

        public char[] Rotor3_Encryption(char[] array)
        {
            Rotor3_rotate = false;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("!> ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Ustaw obrot wirnika 3 na false");
            Console.ReadKey();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("!> ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Ostatnia pozycja wirnika 3: " + Rotor3_Position);
            Console.ReadKey();

            int local = (int)Rotor3_Position;
            local += 1;
            Rotor3_Position = (char)local;

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("!> ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Nowa pozycja wirnika 3: " + Rotor3_Position);
            Console.ReadKey();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("!> ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Przesuwanie elementow tablicy...");
            Console.ReadKey();
            array = Move_array(array);

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("!> ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Czy pozycja wirnika 3: " + Rotor3_Position + " > Z ?");
            Console.ReadKey();

            if (Rotor3_Position > 'Z')
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("-> TAK <-");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("!> ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" Obróć wirnik 3 o 360* -> pozycja wirnika3: " + Rotor3_Position);
                Console.ReadKey();

                local = (int)Rotor3_Position;
                local -= 26;
                Rotor3_Position = (char)local;

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("!> ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" pozycja wirnika3: " + Rotor3_Position);
                Console.ReadKey();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("-> NIE <-");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
            }

            return array;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            EnigmaCore body = new EnigmaCore();                 // ciało Enigmy
            EnigmaAnalysis test = new EnigmaAnalysis();         // ciało Enigmy do testów

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("------------------------------");
            Console.WriteLine("------> ENIGMA - sol 3 <------");
            Console.WriteLine("-----> wersja ulepszona <-----");
            Console.WriteLine("--> Ostatni patch: 9.08.18 <--");
            Console.WriteLine("------------------------------\n");
            Console.ForegroundColor = ConsoleColor.White;

            for (int e = 0; e < 1;)
            {
                Console.WriteLine("///Panel wyboru:");
                Console.WriteLine("1. Zaszyfruj wiadomosc(widok slowny)");
                Console.WriteLine("2. Zaszyfruj wiadomosc(widok strzalkowy)");
                Console.WriteLine("3. Zbadaj działanie programu eni_sol3");
                Console.WriteLine("4. Koniec");

                string decyzja;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("!> ");
                decyzja = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;

                if (decyzja == "3")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nuwagi: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("- aby przejsc do kolejnego kroku działania, kliknij dowolny klawisz");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("!> ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" kolorem oznaczono elementy wywoływane przez funkcje z klasy");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("!> ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" kolorem oznaczono elementy wywoływane przez główny kod enigmy");

                    Console.WriteLine("\nProszę ustalić klucz kodowania np. AGR \n(uwaga:tylko duże litery są akceptowalne)");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("!> ");
                    string coding_key = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    if (coding_key.Length < 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Podano za mało znaków!!! (wymagane: 3)");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Podaj klucz kodowania jeszcze raz");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("!> ");
                        coding_key = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    char[] coding_table = new char[2];
                    coding_table = coding_key.ToCharArray();
                    test.Rotor1_Position = coding_table[0];
                    test.Rotor2_Position = coding_table[1];
                    test.Rotor3_Position = coding_table[2];

                    
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("\nUstalony klucz kodowania: \n => " + test.Rotor1_Position + test.Rotor2_Position + test.Rotor3_Position);
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("\nPodaj tekst do zaszyfrowania(uwaga: tylko duże litery!)");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("!> ");
                    string tekst = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    int rozmiar = tekst.Length;
                    char[] Chars_To_Encrypt = new char[rozmiar];
                    Chars_To_Encrypt = tekst.ToCharArray();

                    char[] Encrypted_Text = new char[rozmiar];
                    char[] Main_Matrix = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

                    // policz odległośc od A do podanej litery
                    int distance = test.Count_Distance(coding_table[0]);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n Odleglosć od znaku A = " + distance);
                    Console.WriteLine("<< kliknij dowolny przycisk aby przejśc dalej >>\n");
                    Console.ReadKey();

                    Console.ForegroundColor = ConsoleColor.White;

                    for (int x = 0; x < distance; x++)
                    {
                        Main_Matrix = body.Move_array(Main_Matrix);
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Stan tablicy po przesunięciu n-razy");
                    Console.ForegroundColor = ConsoleColor.White;
                    for (int x = 0; x < Main_Matrix.Length; x++)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(Main_Matrix[x] + " ");
                    }
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("\n<< kliknij dowolny przycisk aby przejśc dalej >>\n");
                    Console.ReadKey();

                    int i;
                    for (i = 0; i < rozmiar; i++)
                    {
                        char letter = Chars_To_Encrypt[i];                          // bierzemy literkę

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("!> ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(" Litera do zaszyfrowania: " + letter);
                        Console.ReadKey();

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("!> ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(" Czy znak: " + letter + "(" + (int)letter + ") jest z przedzialu 65<>90?");
                        Console.ReadKey();

                        if (letter >= 65 && letter <= 90)                           // sprawdzamy czy się mieści w przedziale <>65<>90<>
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("-> TAK <-");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadKey();

                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("!> ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(" Uruchom wirnik1");
                            Console.ReadKey();

                            test.Rotor1_Encryption();

                            if (test.Rotor2_rotate == true)
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("!> ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(" Uruchom wirnik2");
                                Console.ReadKey();

                                Main_Matrix = test.Rotor2_Encryption(Main_Matrix);
                            }

                            if (test.Rotor3_rotate == true)
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("!> ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(" Uruchom wirnik3");
                                Console.ReadKey();

                                Main_Matrix = test.Rotor3_Encryption(Main_Matrix);
                            }

                            int var = body.Return_RotorPositionNumber(letter);      // funkcja ktora przeszuka aktualna litere i zamieni ja na odpowiadajaca jej cyfre

                            // gdy var 25 , to jesli wezmiemy Main_Matrix[25+1] 
                            // otrzymamy blad o przekroczeniu indeksu,
                            // gdy var bedzie 25 to nie dodamy +1 tylko odejmiemy -1
                            // bo Main_Matrix jest od 0-25 (26 liter)

                            char copy = letter;
                            if (var != 25)
                            {
                                letter = Main_Matrix[var + 1];                              // z tablicy Main_Matrix bierzemy element z pozycji var
                            }
                            else
                            {
                                letter = Main_Matrix[var - 1];
                            }

                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("!> ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(" Znak: " + copy + " zaszyfrowano znakiem: " + letter);
                            Console.ReadKey();

                            Main_Matrix = test.Move_array(Main_Matrix);             // przesuwamy pozycje znaków w tablicy
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("-> NIE <-");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadKey();
                        }

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("!> ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(" Wpisz znak: " + letter + " do tablicy zaszyfrowanej");
                        Console.ReadKey();

                        Encrypted_Text[i] = letter;                                 // wpisujemy znak do szyfrowanej tablicy
                    }

                    // wypisanie oryginalnego tekstu:
                    Console.Write("\n\n oryginalna wiadomosc -> ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    for (int w = 0; w < Chars_To_Encrypt.Length; w++)
                    {
                        Console.Write(Chars_To_Encrypt[w]);
                    }
                    Console.ForegroundColor = ConsoleColor.White;

                    // wypisanie zaszyfrowanego tekstu:
                    Console.Write("\n zaszyfrowana wiadomosc ->  ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    for (int w = 0; w < Encrypted_Text.Length; w++)
                    {
                        Console.Write(Encrypted_Text[w]);
                    }
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine();
                    Console.ReadKey();
                    Console.WriteLine();
                }
                else if (decyzja == "1")
                {
                    Console.WriteLine("\nProszę ustalić klucz kodowania np. AGR \n(uwaga:tylko duże litery są akceptowalne)");
                    Console.Write("!> ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    string coding_key = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    if (coding_key.Length < 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Podano za mało znaków!!! (wymagane: 3)");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Podaj klucz kodowania jeszcze raz");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("!> ");
                        coding_key = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    char[] coding_table = new char[2];
                    coding_table = coding_key.ToCharArray();
                    body.Rotor1_Position = coding_table[0];
                    body.Rotor2_Position = coding_table[1];
                    body.Rotor3_Position = coding_table[2];

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nUstalony klucz kodowania: \n => " + body.Rotor1_Position + body.Rotor2_Position + body.Rotor3_Position);
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("\nPodaj tekst do zaszyfrowania(uwaga: tylko duże litery!)");
                    Console.Write("!> ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    string tekst = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    int rozmiar = tekst.Length;
                    char[] Chars_To_Encrypt = new char[rozmiar];
                    Chars_To_Encrypt = tekst.ToCharArray();

                    char[] Encrypted_Text = new char[rozmiar];
                    char[] Main_Matrix = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

                    // policz odległośc od A do podanej litery
                    int distance = body.Count_Distance(coding_table[0]);

                    for (int x = 0; x < distance; x++)
                    {
                        Main_Matrix = body.Move_array(Main_Matrix);
                    }

                    // Przesuwanie TABLICY DZIALA!
                    // POPRAWIC RESZTE!!!!  ---> reszta działa
                    // zajrzenie do kodu: 28 V 18, i :( ....

                    int i;
                    for (i = 0; i < rozmiar; i++)
                    {
                        char letter = Chars_To_Encrypt[i];                          // bierzemy literkę
                                                                                    // sprawdzenie poboru literek:
                                                                                    // Console.Write(letter);
                        if (letter >= 65 && letter <= 90)                           // sprawdzamy czy się mieści w przedziale <>65<>90<>
                        {
                            body.Rotor1_Encryption();

                            if (body.Rotor2_rotate == true)
                            {
                                Main_Matrix = body.Rotor2_Encryption(Main_Matrix);
                            }

                            if (body.Rotor3_rotate == true)
                            {
                                Main_Matrix = body.Rotor3_Encryption(Main_Matrix);
                            }

                            int var = body.Return_RotorPositionNumber(letter);      // funkcja ktora przeszuka aktualna litere i zamieni ja na odpowiadajaca jej cyfre


                            if (var != 25)
                            {
                                letter = Main_Matrix[var + 1];                              // z tablicy Main_Matrix bierzemy element z pozycji var
                            }
                            else
                            {
                                letter = Main_Matrix[var - 1];
                            }

                            Main_Matrix = body.Move_array(Main_Matrix);             // przesuwamy pozycje znaków w tablicy
                        }

                        // jeżeli litera do zaszyfrowania była taka
                        // sama jak litera szyfrująca to przesuń
                        // o 1 dodatkowo
                        if(Chars_To_Encrypt[i] == letter)
                        {
                            int holder = (int)letter;
                            holder += 1;
                            letter = (char)holder;
                        }

                        Encrypted_Text[i] = letter;                                 // wpisujemy znak do szyfrowanej tablicy
                    }

                    // wypisanie oryginalnego tekstu:
                    Console.Write("\n\n oryginalna wiadomosc -> ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    for (int w = 0; w < Chars_To_Encrypt.Length; w++)
                    {
                        Console.Write(Chars_To_Encrypt[w]);
                    }
                    Console.ForegroundColor = ConsoleColor.White;

                    // wypisanie zaszyfrowanego tekstu:
                    Console.Write("\n zaszyfrowana wiadomosc ->  ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    for (int w = 0; w < Encrypted_Text.Length; w++)
                    {
                        Console.Write(Encrypted_Text[w]);
                    }
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine();
                    Console.ReadKey();
                    Console.WriteLine();
                }
                else if (decyzja == "2")
                {
                    Console.WriteLine("\nProszę ustalić klucz kodowania np. AGR \n(uwaga:tylko duże litery są akceptowalne)");
                    Console.Write("!> ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    string coding_key = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    if (coding_key.Length < 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Podano za mało znaków!!! (wymagane: 3)");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Podaj klucz kodowania jeszcze raz");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("!> ");
                        coding_key = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    char[] coding_table = new char[2];
                    coding_table = coding_key.ToCharArray();
                    body.Rotor1_Position = coding_table[0];
                    body.Rotor2_Position = coding_table[1];
                    body.Rotor3_Position = coding_table[2];
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nUstalony klucz kodowania: \n => " + body.Rotor1_Position + body.Rotor2_Position + body.Rotor3_Position);
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("\nPodaj tekst do zaszyfrowania(uwaga: tylko duże litery!)");
                    Console.Write("!> ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    string tekst = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    int rozmiar = tekst.Length;
                    char[] Chars_To_Encrypt = new char[rozmiar];
                    Chars_To_Encrypt = tekst.ToCharArray();

                    char[] Encrypted_Text = new char[rozmiar];
                    char[] Main_Matrix = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

                    // policz odległośc od A do podanej litery
                    int distance = body.Count_Distance(coding_table[0]);

                    for (int x = 0; x < distance; x++)
                    {
                        Main_Matrix = body.Move_array(Main_Matrix);
                    }

                    // Przesuwanie TABLICY DZIALA!
                    // POPRAWIC RESZTE!!!!  ---> reszta działa
                    // zajrzenie do kodu: 28 V 18, i :( ....

                    int i;
                    for (i = 0; i < rozmiar; i++)
                    {
                        char letter = Chars_To_Encrypt[i];                          // bierzemy literkę
                                                                                    // sprawdzenie poboru literek:
                                                                                    // Console.Write(letter);
                        if (letter >= 65 && letter <= 90)                           // sprawdzamy czy się mieści w przedziale <>65<>90<>
                        {
                            body.Rotor1_Encryption();

                            if (body.Rotor2_rotate == true)
                            {
                                Main_Matrix = body.Rotor2_Encryption(Main_Matrix);
                            }

                            if (body.Rotor3_rotate == true)
                            {
                                Main_Matrix = body.Rotor3_Encryption(Main_Matrix);
                            }

                            int var = body.Return_RotorPositionNumber(letter);      // funkcja ktora przeszuka aktualna litere i zamieni ja na odpowiadajaca jej cyfre


                            if (var != 25)
                            {
                                letter = Main_Matrix[var + 1];                              // z tablicy Main_Matrix bierzemy element z pozycji var
                            }
                            else
                            {
                                letter = Main_Matrix[var - 1];
                            }

                            Main_Matrix = body.Move_array(Main_Matrix);             // przesuwamy pozycje znaków w tablicy
                        }
                        Encrypted_Text[i] = letter;                                 // wpisujemy znak do szyfrowanej tablicy
                    }

                    for (int w = 0; w < Chars_To_Encrypt.Length; w++)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("                 " + Chars_To_Encrypt[w]);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("------>");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(Encrypted_Text[w]);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("\n");
                    }

                    Console.WriteLine();
                    Console.ReadKey();
                    Console.WriteLine();
                }
                else if (decyzja == "4")
                {
                    Console.WriteLine();
                    Console.WriteLine("!> Naciśnij dowolny przycisk aby wyjsc...");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Podano niewlasciwa opcje!");
                    Console.Write("Zamykanie programu");
                    Thread.Sleep(500);
                    Console.Write(".");
                    Thread.Sleep(600);
                    Console.Write(".");
                    Thread.Sleep(700);
                    Console.Write(".");
                    Thread.Sleep(800);
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }
            }
        }
    }
}

