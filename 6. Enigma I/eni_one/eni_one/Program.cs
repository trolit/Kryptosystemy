using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eni_one
{
    class EnigmaCore
    {
        //-------------------------------------------------------------------------------------------------//
        // Zmienne Enigma
        public char Rotor1_Position = '#';           // śledzi aktualną pozycję wirnika 1  
        public char Rotor2_Position = '#';           
        public char Rotor3_Position = '#';
        public bool Rotor2_rotate = false;           // domyślnie false!
        public bool Rotor3_rotate = false;           // domyślnie false!
        public int Value = 0;                        // przechowuje wartości liczbowe liter, domyślnie 0
        //-------------------------------------------------------------------------------------------------//

        #region Enigma Encryption
        //-------------------------------------------------------------------------------------------------//
        // Wirnik 1 (+ obsługa Wirnika 2)
        // "FAST ROTOR"
        // Przejście o: (tu należy wprowadzić wartość)
        //-------------------------------------------------------------------------------------------------//
        public char Rotor1_Encryption(char Letter)
        {
                                                     // ZASADA DZIAŁANIA WIRNIKA 1:
            char x = Rotor1_Position;                // bierzemy aktualne miejsce wirnika 1
            int y = (int)x + 7;                      // przesuwamy pozycje wirnika o 7
            Rotor1_Position = (char)y;               // przestawiamy wirnik o tyle samo do przodu 

            if((int)Rotor1_Position > (int)'Z')      // jeśli wirnik1 przekroczy wartość 90(czyli
                                                     // w nomenklaturze fizycznej budowy wirnika
                                                     // pozycje 26)
            {
                Rotor2_rotate = true;                // zezwól na obrócenie wirnika2
 
                // zaopiekowanie się stanem Wirnika 1      
                char temporary = Rotor1_Position;
                int next = (int)temporary - 26;      // obróć mechanizm 
                Rotor1_Position = (char)next;
            }

            Value = Rotor1_Position;   // ta linijka wow?
            return (char)Value;
        }
        //-------------------------------------------------------------------------------------------------//


        //-------------------------------------------------------------------------------------------------//
        // Wirnik 2 (+ obsługa Wirnika 3)
        // "MEDIUM ROTOR"
        // Przejście o: (tu należy wprowadzić wartość)
        //-------------------------------------------------------------------------------------------------//
        public char Rotor2_Encryption(char Letter)
        {
            Rotor2_rotate = false;                   // zresetowanie zezwolenia do wykonania obrotu
            char x = Rotor2_Position;                // pobieramy informacje odnośnie aktualnej pozycji wirnika 2
            int y = (int)x + 4;                      // wirnik2 zostaje przesunięty o 6 pozycje do przodu
            Rotor2_Position = (char)y;               // przypisujemy do wirnika2 zaktualizowaną pozycję

            if ((int)Rotor2_Position > (int)'Z')     // jeśli wirnik2 przekroczy wartość 90
            {
                Rotor3_rotate = true;                // zezwól na obrócenie wirnika3

                // zaopiekowanie się wirnikiem2
                char temporary = Rotor2_Position;
                int next = (int)temporary - 26;
                Rotor2_Position = (char)next;
            }

            Value = Rotor2_Position;
            return (char)Value;
        }
        //-------------------------------------------------------------------------------------------------//


        //-------------------------------------------------------------------------------------------------//
        // Wirnik 3
        // "SLOW ROTOR"
        // Przejście o: tu wprowadź wartość
        //-------------------------------------------------------------------------------------------------//
        public char Rotor3_Encryption(char Letter)
        {
            Rotor3_rotate = false;                   // zresetowanie zezwolenia do wykonania obrotu
            char x = Rotor3_Position;                // pobieramy informacje odnośnie aktualnej pozycji wirnika 3
            int y = (int)x + 3;                      // wirnik3 zostaje przesunięty o 9 pozycje do przodu
            Rotor3_Position = (char)y;               // przypisujemy do wirnika3 zaktualizowaną pozycję

            if ((int)Rotor3_Position > (int)'Z')     // jeśli wirnik3 przekroczy wartość 90
            {
                char temporary = Rotor3_Position;
                int next = (int)temporary - 26;
                Rotor3_Position = (char)next;
            }

            Value = Rotor3_Position;
            return (char)Value;
        }
        //-------------------------------------------------------------------------------------------------//
        #endregion
        #region Enigma Encryption+tracking
        //-------------------------------------------------------------------------------------------------//
        // Wirnik 1 (+ obsługa Wirnika 2)
        // "FAST ROTOR"
        // Przejście o: (tu należy wprowadzić wartość)
        //-------------------------------------------------------------------------------------------------//
        public char Rotor1_Encryption_tracked(char Letter)
        {
            // ZASADA DZIAŁANIA WIRNIKA 1:
            char x = Rotor1_Position;                // bierzemy aktualne miejsce wirnika 1
            Console.WriteLine("[rotor1]-rotor1_position: " + x);
            Console.ReadKey();
            int y = (int)x + 7;                      // przesuwamy pozycje wirnika o 7
            Rotor1_Position = (char)y;               // przestawiamy wirnik o tyle samo do przodu 
            Console.WriteLine("[rotor1]-rotor1_position + 7: " + Rotor1_Position);
            Console.ReadKey();

            bool is_true = false;
            Console.Write("[rotor1]-rotor1_position(" + Rotor1_Position + ") > Z?: ");   
            if ((int)Rotor1_Position > (int)'Z')      // jeśli wirnik1 przekroczy wartość 90(czyli
                                                      // w nomenklaturze fizycznej budowy wirnika
                                                      // pozycje 26)
            {
                is_true = true;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("YES.");
                Console.ReadKey();
                Console.ForegroundColor = ConsoleColor.White;
                Rotor2_rotate = true;                // zezwól na obrócenie wirnika2
                Console.WriteLine("\n[rotor1]-rotor2_rotation: TRUE");
                // zaopiekowanie się stanem Wirnika 1      
                char temporary = Rotor1_Position;
                Console.WriteLine("[rotor1]-rotor1_position: " + Rotor1_Position + " - 26");
                Console.ReadKey();
                int next = (int)temporary - 26;      // obróć mechanizm 
                Rotor1_Position = (char)next;
                Console.WriteLine("[rotor1]-rotor1_position: " + Rotor1_Position);
                Console.ReadKey();
            }
            if (is_true == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("NO.\n");
                Console.ReadKey();
                Console.ForegroundColor = ConsoleColor.White;
            }

            Value = Rotor1_Position;   // ta linijka wow?
            return (char)Value;
        }
        //-------------------------------------------------------------------------------------------------//


        //-------------------------------------------------------------------------------------------------//
        // Wirnik 2 (+ obsługa Wirnika 3)
        // "MEDIUM ROTOR"
        // Przejście o: (tu należy wprowadzić wartość)
        //-------------------------------------------------------------------------------------------------//
        public char Rotor2_Encryption_tracked(char Letter)
        {
            Console.WriteLine("[rotor2]-rotor2_rotation: FALSE");
            Console.ReadKey();
            Rotor2_rotate = false;                   // zresetowanie zezwolenia do wykonania obrotu
            char x = Rotor2_Position;                // pobieramy informacje odnośnie aktualnej pozycji wirnika 2
            Console.WriteLine("[rotor2]-rotor2_position: " + x);
            Console.ReadKey();
            int y = (int)x + 4;                      // wirnik2 zostaje przesunięty o 6 pozycje do przodu
            Rotor2_Position = (char)y;               // przypisujemy do wirnika2 zaktualizowaną pozycję
            Console.WriteLine("[rotor2]-rotor2_position + 4: " + Rotor2_Position);
            Console.ReadKey();

            bool is_true = false;
            Console.Write("[rotor2]-rotor2_position(" + Rotor2_Position + ") > Z?: ");
            if ((int)Rotor2_Position > (int)'Z')     // jeśli wirnik2 przekroczy wartość 90
            {
                is_true = true;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("YES.");
                Console.ReadKey();
                Console.ForegroundColor = ConsoleColor.White;
                Rotor3_rotate = true;                // zezwól na obrócenie wirnika3
                Console.WriteLine("\n[rotor2]-rotor3_rotation: TRUE");
                Console.ReadKey();

                // zaopiekowanie się wirnikiem2
                char temporary = Rotor2_Position;
                Console.WriteLine("[rotor2]-rotor2_position: " + Rotor2_Position + " - 26");
                Console.ReadKey();
                int next = (int)temporary - 26;
                Rotor2_Position = (char)next;
                Console.WriteLine("[rotor2]-rotor2_position: " + Rotor2_Position);
                Console.ReadKey();
            }
            if (is_true == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("NO.\n");
                Console.ReadKey();
                Console.ForegroundColor = ConsoleColor.White;
            }

            Value = Rotor2_Position;
            return (char)Value;
        }
        //-------------------------------------------------------------------------------------------------//


        //-------------------------------------------------------------------------------------------------//
        // Wirnik 3
        // "SLOW ROTOR"
        // Przejście o: tu wprowadź wartość
        //-------------------------------------------------------------------------------------------------//
        public char Rotor3_Encryption_tracked(char Letter)
        {
            Console.WriteLine("[rotor3]-rotor3_rotation: FALSE");
            Console.ReadKey();
            Rotor3_rotate = false;                   // zresetowanie zezwolenia do wykonania obrotu
            char x = Rotor3_Position;                // pobieramy informacje odnośnie aktualnej pozycji wirnika 3
            Console.WriteLine("[rotor3]-rotor3_position: " + x);
            Console.ReadKey();
            int y = (int)x + 3;                      // wirnik3 zostaje przesunięty o 9 pozycje do przodu
            Rotor3_Position = (char)y;               // przypisujemy do wirnika3 zaktualizowaną pozycję
            Console.WriteLine("[rotor3]-rotor3_position + 3: " + Rotor3_Position);
            Console.ReadKey();

            bool is_true = false;
            Console.Write("[rotor3]-rotor3_position(" + Rotor3_Position + ") > Z?: ");
            if ((int)Rotor3_Position > (int)'Z')     // jeśli wirnik3 przekroczy wartość 90
            {
                is_true = true;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("YES.");
                Console.ReadKey();
                Console.ForegroundColor = ConsoleColor.White;
                char temporary = Rotor3_Position;
                Console.WriteLine("[rotor3]-rotor3_position: " + Rotor3_Position + " - 26");
                Console.ReadKey();
                int next = (int)temporary - 26;
                Rotor3_Position = (char)next;
                Console.WriteLine("[rotor3]-rotor3_position: " + Rotor3_Position);
                Console.ReadKey();
            }
            if (is_true == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("NO.\n");
                Console.ReadKey();
                Console.ForegroundColor = ConsoleColor.White;
            }

            Value = Rotor3_Position;
            return (char)Value;
        }
        //-------------------------------------------------------------------------------------------------//
        #endregion


        public char Rotor1_Decryption(char Letter)
        {
            // ZASADA DZIAŁANIA WIRNIKA 1:
            char x = Rotor1_Position;                // bierzemy aktualne miejsce wirnika 1
            int y = (int)x - 7;                      // przesuwamy pozycje wirnika o 7 w tył
            Rotor1_Position = (char)y;               // przestawiamy wirnik

            if ((int)Rotor1_Position < (int)'A')      // jeśli wirnik1 < A 
            {
                Rotor2_rotate = true;                // zezwól na obrócenie wirnika2

                // zaopiekowanie się stanem Wirnika 1      
                char temporary = Rotor1_Position;
                int next = (int)temporary + 26;      // obróć mechanizm 
                Rotor1_Position = (char)next;
            }

            Value = Rotor1_Position;   // ta linijka wow?
            return (char)Value;
        }

        public char Rotor2_Decryption(char Letter)
        {
            Rotor2_rotate = false;                   // zresetowanie zezwolenia do wykonania obrotu
            char x = Rotor2_Position;                // pobieramy informacje odnośnie aktualnej pozycji wirnika 2
            int y = (int)x - 4;                      // wirnik2 zostaje przesunięty o 6 pozycje do przodu
            Rotor2_Position = (char)y;               // przypisujemy do wirnika2 zaktualizowaną pozycję

            if ((int)Rotor2_Position < (int)'A')     // jeśli wirnik2 przekroczy wartość 90
            {
                Rotor3_rotate = true;                // zezwól na obrócenie wirnika3

                // zaopiekowanie się wirnikiem2
                char temporary = Rotor2_Position;
                int next = (int)temporary + 26;
                Rotor2_Position = (char)next;
            }

            Value = Rotor2_Position;
            return (char)Value;
        }

        public char Rotor3_Decryption(char Letter)
        {
            Rotor3_rotate = false;                   // zresetowanie zezwolenia do wykonania obrotu
            char x = Rotor3_Position;                // pobieramy informacje odnośnie aktualnej pozycji wirnika 3
            int y = (int)x - 3;                      // wirnik3 zostaje przesunięty o 9 pozycje do przodu
            Rotor3_Position = (char)y;               // przypisujemy do wirnika3 zaktualizowaną pozycję

            if ((int)Rotor3_Position < (int)'A')     // jeśli wirnik3 przekroczy wartość 90
            {
                char temporary = Rotor3_Position;
                int next = (int)temporary + 26;
                Rotor3_Position = (char)next;
            }

            Value = Rotor3_Position;
            return (char)Value;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            EnigmaCore body = new EnigmaCore();     // ciało Enigmy

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                               PROJEKT ENIGMA");
            Console.WriteLine("                             Opracowano: 03.2018");
            Console.WriteLine("                                Wersja: 1.13");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("============================================================================");
            Console.WriteLine("Szczegóły odnośnie projektu:");
            Console.WriteLine("Obecna implementacja Enigmy(1.13) składa się z trzech wirników(niem. Walzen),");
            Console.WriteLine("bez reflektora(niem. Umkehrwalze) i łącznicy kablowej(niem. Steckerbrett)");
            Console.WriteLine("warto mieć na uwadzę, że Enigma miała różne wersje w rzeczywistości. Jedną");
            Console.WriteLine("z najtrudniejszych do rozszyfrowania była Enigma dla Kriegsmarine z racji");
            Console.WriteLine("wprowadzenia tzw. kodu dziennego. Operatorzy wykorzystywali kod a następnie");
            Console.WriteLine("go niszczyli. Szczegóły i więcej informacji odnośnie Enigmy znajdziesz");
            Console.WriteLine("w linkach/literaturze, które zostały zamieszczone w dokumencie projektu");
            Console.WriteLine("*ENIGMA z WW2 miała słabość, która polegała na tym, że szyfrowana litera");
            Console.WriteLine("nigdy nie mogła być zaszyfrowana w samą siebie.");
            Console.WriteLine("============================================================================");
            Console.WriteLine("Menu wyboru: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. Zaszyfruj wiadomość.");
            Console.WriteLine("2. Zaszyfruj wiadomość +tracking.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("3. Odszyfruj wiadomość. (niedostępne)");
            Console.WriteLine("4. Odszyfruj wiadomość +tracking. (niedostępne)");
            Console.WriteLine("5. Łącznica kablowa. (niedostępne)");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("6. Koniec programu.");
            Console.WriteLine("============================================================================");
            Console.WriteLine("kolorem zielonym oznaczono dostępne funkcje");
            int wybor = Convert.ToInt32(Console.ReadLine());
            if (wybor == 1)
            {
                Console.WriteLine("Proszę ustalić klucz kodowania np. AGR - tylko duże litery!");
                string coding_key = Console.ReadLine();
                char[] coding_table = new char[2];
                coding_table = coding_key.ToCharArray();
                body.Rotor1_Position = coding_table[0];
                body.Rotor2_Position = coding_table[1];
                body.Rotor3_Position = coding_table[2];
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nUstalony klucz kodowania: \n => " + body.Rotor1_Position + body.Rotor2_Position + body.Rotor3_Position);
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("\nPodaj tekst do zaszyfrowania(tylko duże litery!)");
                string tekst = Console.ReadLine();
                int rozmiar = tekst.Length;
                char[] Chars_To_Encrypt = new char[rozmiar];
                Chars_To_Encrypt = tekst.ToCharArray();

                // Szyfrowanie 
                // tutaj kod
                int i;
                for (i = 0; i < rozmiar; i++)
                {
                    char letter = Chars_To_Encrypt[i];
                    if ((int)letter >= 65 && (int)letter <= 90)
                    {
                        letter = body.Rotor1_Encryption(letter);

                        // gdy rotor2 może wykonać operacje
                        if (body.Rotor2_rotate == true)
                        {
                            letter = body.Rotor2_Encryption(letter);
                        }

                        if (body.Rotor3_rotate == true)
                        {
                            letter = body.Rotor3_Encryption(letter);
                        }

                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(letter);
                    }
                    else
                    {
                        Console.Write(letter);
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine("\n\n\nSzyfrowanie wiadomości zakończone.");
            }
            // ---------------------------------->
            else if(wybor == 2)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("informacja o trybie TRACKING: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("każdą informację zatwierdzaj przyciskiem ENTER jeśli chcesz przejść dalej.");
                Console.WriteLine("<<kliknij enter>>");
                Console.ReadKey();
                Console.WriteLine("Proszę ustalić klucz kodowania np. AGR - tylko duże litery!");
                string coding_key = Console.ReadLine();
                char[] coding_table = new char[2];
                coding_table = coding_key.ToCharArray();
                body.Rotor1_Position = coding_table[0];
                body.Rotor2_Position = coding_table[1];
                body.Rotor3_Position = coding_table[2];
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nUstalony klucz kodowania: \n => " + body.Rotor1_Position + body.Rotor2_Position + body.Rotor3_Position);
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("\nPodaj tekst do zaszyfrowania(tylko duże litery!)");
                string tekst = Console.ReadLine();
                int rozmiar = tekst.Length;
                char[] Chars_To_Encrypt = new char[rozmiar];
                Chars_To_Encrypt = tekst.ToCharArray();

                // tablica zapisujaca zaszyfrowany kod
                char[] encrypted_array = new char[rozmiar];

                // Szyfrowanie 
                // tutaj kod
                int i;
                for (i = 0; i < rozmiar; i++)
                {
                    char letter = Chars_To_Encrypt[i];
                    char copy = letter;
                    if ((int)letter >= 65 && (int)letter <= 90)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("[input]: " + letter);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadKey();
                        letter = body.Rotor1_Encryption_tracked(letter);
                        Console.WriteLine("[rotor1]-exit: " + copy + "->" + letter);
                        copy = letter;

                        // gdy rotor2 może wykonać operacje
                        if (body.Rotor2_rotate == true)
                        {
                            Console.WriteLine("[rotor2]-in: " + letter);
                            Console.ReadKey();
                            letter = body.Rotor2_Encryption_tracked(letter);                          
                            Console.WriteLine("[rotor2]-exit: " + copy + "->" + letter);
                            Console.ReadKey();
                            copy = letter;
                        }

                        if (body.Rotor3_rotate == true)
                        {
                            Console.WriteLine("[rotor3]-in: " + letter);
                            Console.ReadKey();
                            letter = body.Rotor3_Encryption_tracked(letter);
                            Console.WriteLine("[rotor3]-exit: " + copy + "->" + letter);
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("[whitespace]-ignore");
                        Console.ReadKey();
                    }

                    // tu tablice
                    encrypted_array[i] = letter;
                }
                Console.WriteLine("######################");
                Console.WriteLine("[track]-end of process.");
                string encrypted = new string(encrypted_array);

                Console.Write("[output]: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(tekst);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" -> ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(encrypted + "\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
            }
            else if(wybor == 3)
            {
                Console.WriteLine("Proszę ustalić klucz kodowania np. AGR - tylko duże litery!");
                string coding_key = Console.ReadLine();
                char[] coding_table = new char[2];
                coding_table = coding_key.ToCharArray();
                body.Rotor1_Position = coding_table[0];
                body.Rotor2_Position = coding_table[1];
                body.Rotor3_Position = coding_table[2];
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nUstalony klucz kodowania: \n => " + body.Rotor1_Position + body.Rotor2_Position + body.Rotor3_Position);
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("\nPodaj tekst do odszyfrowania(tylko duże litery!)");
                string tekst = Console.ReadLine();
                int rozmiar = tekst.Length;
                char[] Chars_To_Encrypt = new char[rozmiar];
                Chars_To_Encrypt = tekst.ToCharArray();

                // Szyfrowanie 
                // tutaj kod
                int i;
                for (i = 0; i < rozmiar; i++)
                {
                    char letter = Chars_To_Encrypt[i];
                    if ((int)letter >= 65 && (int)letter <= 90)
                    {
                        letter = body.Rotor1_Decryption(letter);

                        // gdy rotor2 może wykonać operacje
                        if (body.Rotor2_rotate == true)
                        {
                            letter = body.Rotor2_Decryption(letter);
                        }

                        if (body.Rotor3_rotate == true)
                        {
                            letter = body.Rotor3_Decryption(letter);
                        }

                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(letter);
                    }
                    else
                    {
                        Console.Write(letter);
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine("\n\n\nOdszyfrowanie wiadomości zakończone.");
            }
            else if(wybor == 4)
            {
                Console.WriteLine("\nNaciśnij dowolny klawisz aby zakończyć...");
            }
            Console.ReadKey();
        }
    }
}
