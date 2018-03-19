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
        public int Rotor1_Counter;
        public int Rotor2_Counter;
        public int Rotor3_Counter;
        //-------------------------------------------------------------------------------------------------//


        //-------------------------------------------------------------------------------------------------//
        // Wirnik 1 (+ obsługa Wirnika 2)
        // Przejście o: (tu należy wprowadzić wartość)
        //-------------------------------------------------------------------------------------------------//
        public char Rotor1_Encryption(char Letter, char[] array)
        {
            

            
            Value += 3;
            if(Value <= 25)
            {
                Letter = (char)array[Value];
            }
            else
            {
                Value = 0;
                Value += 3;
                Letter = (char)array[Value];
            }

            return (char)Value;
        }
        //-------------------------------------------------------------------------------------------------//


        //-------------------------------------------------------------------------------------------------//
        // Wirnik 2 (+ obsługa Wirnika 3)
        // Przejście o: (tu należy wprowadzić wartość)
        //-------------------------------------------------------------------------------------------------//
        public char Rotor2_Encryption(char Letter)
        {
            Rotor2_rotate = false;                   // zresetowanie zezwolenia do wykonania obrotu
            Value = (int)Letter;
            Value += 3;                              // przesuniecie o 3 pozycje litery
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

            if (Value > 90)                       // jeśli Value osiągnie 91 wracamy do A(65) bo 91-26=65
            {
                Value -= 26;
            }

            Value = Rotor2_Position;
            return (char)Value;
        }
        //-------------------------------------------------------------------------------------------------//


        //-------------------------------------------------------------------------------------------------//
        // Wirnik 3
        // Przejście o: tu wprowadź wartość
        //-------------------------------------------------------------------------------------------------//
        public char Rotor3_Encryption(char Letter)
        {
            Rotor3_rotate = false;                   // zresetowanie zezwolenia do wykonania obrotu
            Value = (int)Letter;
            Value += 2;                              // przesuniecie o 2 pozycji
            char x = Rotor3_Position;                // pobieramy informacje odnośnie aktualnej pozycji wirnika 3
            int y = (int)x + 3;                      // wirnik3 zostaje przesunięty o 9 pozycje do przodu
            Rotor3_Position = (char)y;               // przypisujemy do wirnika3 zaktualizowaną pozycję

            if ((int)Rotor3_Position > (int)'Z')     // jeśli wirnik3 przekroczy wartość 90
            {
                char temporary = Rotor3_Position;
                int next = (int)temporary - 26;
                Rotor3_Position = (char)next;
            }

            if (Value > 90)                          // jeśli Value osiągnie 91 wracamy do A(65) bo 91-26=65
            {
                Value -= 26;
            }

            Value = Rotor3_Position;
            return (char)Value;
        }
        //-------------------------------------------------------------------------------------------------//
    }

    class Program
    {
        static void Main(string[] args)
        {
            EnigmaCore body = new EnigmaCore();     // ciało Enigmy

            Console.WriteLine("============================================================================");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                               PROJEKT ENIGMA");
            Console.WriteLine("                             Opracowano: 03.2018");
            Console.WriteLine("                                 Wersja: 1.0");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("============================================================================");
            Console.WriteLine("Szczegóły odnośnie projektu:");
            Console.WriteLine("Obecna implementacja Enigmy(1.0) składa się z trzech wirników(niem. Walzen),");
            Console.WriteLine("bez reflektora(niem. Umkehrwalze) i łącznicy kablowej(niem. Steckerbrett)");
            Console.WriteLine("warto mieć na uwadzę, że Enigma miała różne wersje w rzeczywistości. Jedną");
            Console.WriteLine("z najtrudniejszych do rozszyfrowania była Enigma dla Kriegsmarine z racji");
            Console.WriteLine("wprowadzenia tzw. kodu dziennego");
            Console.WriteLine("Szczegóły i więcej informacji odnośnie Enigmy znajdziesz w linkach, które");
            Console.WriteLine("zostały zamieszczone w dokumencie projektu oraz w książce pod tytułem: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("=> ENIGMA - Bliżej prawdy(autor: Marek Grajek)");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("============================================================================");
            Console.WriteLine("Menu wyboru: ");
            Console.WriteLine("1. Zaszyfruj wiadomość.");
            Console.WriteLine("2. Odszyfruj wiadomość(wkrótce...).");
            Console.WriteLine("3. Łącznica kablowa(wkrótce...)");
            Console.WriteLine("4. Koniec programu.");
            Console.WriteLine("============================================================================");

            // tablica pierwszego wirnika
            char[] rotor1_a = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            char[] rotor2_a = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            char[] rotor3_a = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();


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

                body.Rotor1_Counter = (int)body.Rotor1_Position;
                body.Rotor2_Counter = (int)body.Rotor2_Position;
                body.Rotor3_Counter = (int)body.Rotor3_Position;

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
                        letter = body.Rotor1_Encryption(letter, rotor1_a);

                        // gdy rotor2 może wykonać operacje
                        if (body.Rotor2_rotate == true)
                        {
                            letter = body.Rotor2_Encryption(letter);
                        }

                        if (body.Rotor3_rotate == true)
                        {
                            letter = body.Rotor3_Encryption(letter);
                        }

                        Console.Write(letter);
                    }
                    else
                    {
                        Console.Write(letter);
                    }
                }

                Console.WriteLine("\nSzyfrowanie wiadomości zakończone.");
            }
            else if (wybor == 2)
            {
                Console.WriteLine("Proszę podać klucz kodowania niezbędny do odszyfrowania wiadomości\nnp. AGR - tylko duże litery!");
                string coding_key = Console.ReadLine();
                char[] coding_table = new char[2];
                coding_table = coding_key.ToCharArray();
                body.Rotor1_Position = coding_table[0];
                body.Rotor2_Position = coding_table[1];
                body.Rotor3_Position = coding_table[2];

                Console.WriteLine("\nPodaj tekst do odszyfrowania(tylko duże litery!)");
                string tekst = Console.ReadLine();
                int rozmiar = tekst.Length;
                char[] Chars_To_Encrypt = new char[rozmiar];
                Chars_To_Encrypt = tekst.ToCharArray();
            }

            else if (wybor == 4)
            {
                Console.WriteLine("\nNaciśnij dowolny klawisz aby zakończyć...");
            }
            Console.ReadKey();
        }
    }
}
