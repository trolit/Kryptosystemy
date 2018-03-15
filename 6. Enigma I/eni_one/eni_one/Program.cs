using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eni_one
{
    class EnigmaCore
    {
        // zmienne Enigmy
        public char Rotor1_Position = '#';    
        public char Rotor2_Position = '#';
        public char Rotor3_Position = '#';
        public bool Rotor2_rotate = false;
        public bool Rotor3_rotate = false;
        public int Value = 0;

        // Wirnik 1 (+ obsługa wirnika 2)
        public char Rotor1_Encryption(char Letter)
        {
            Value = (int)Letter;                     // bierzemy wartość ASCII znaku
            Value += 4;                              // przesuniecie o 4 pozycji otrzymanego znaku
            char x = Rotor1_Position;                // bierzemy aktualne miejsce wirnika
            int y = (int)x + 4;                      // przesuwamy wirnik o 4 do przodu
            Rotor1_Position = (char)y;               // przestawienie wirnika o tyle samo do przodu (6)
            if((int)Rotor1_Position > (int)'Z')      // jeśli wirnik1 przekroczy wartość 90
            {
                Rotor2_rotate = true;                // zezwól na obrócenie wirnika2
 
                // zaopiekowanie się wirnikiem1          
                char temporary = Rotor1_Position;
                int next = (int)temporary - 26;
                Rotor1_Position = (char)next;
                
                if(Value > 90)                       // jeśli Value osiągnie 91 wracamy do A(65) bo 91-26=65
                {
                    Value -= 26;
                }
            }

            return (char)Value;
        }

        // Wirnik 2 (+ obsługa wirnika3)
        public char Rotor2_Encryption(char Letter)
        {
            Rotor2_rotate = false;                   // zresetowanie zezwolenia do wykonania obrotu
            Value = (int)Letter;
            Value += 3;                              // przesuniecie o 3 pozycji
            char x = Rotor2_Position;                // pobieramy informacje odnośnie aktualnej pozycji wirnika 2
            int y = (int)x + 3;                      // wirnik2 zostaje przesunięty o 3 pozycje do przodu
            Rotor2_Position = (char)y;               // przypisujemy do wirnika2 zaktualizowaną pozycję

            if ((int)Rotor2_Position > (int)'Z')     // jeśli wirnik2 przekroczy wartość 90
            {
                Rotor3_rotate = true;                // zezwól na obrócenie wirnika3

                // zaopiekowanie się wirnikiem2
                char temporary = Rotor2_Position;
                int next = (int)temporary - 26;
                Rotor2_Position = (char)next;

                if (Value > 90)                       // jeśli Value osiągnie 91 wracamy do A(65) bo 91-26=65
                {
                    Value -= 26;
                }
            }

            return (char)Value;
        }

        // Wirnik 3
        public char Rotor3_Encryption(char Letter)
        {
            Rotor3_rotate = false;                   // zresetowanie zezwolenia do wykonania obrotu
            Value = (int)Letter;
            Value += 2;                              // przesuniecie o 2 pozycji
            char x = Rotor3_Position;                // pobieramy informacje odnośnie aktualnej pozycji wirnika 3
            int y = (int)x + 2;                      // wirnik3 zostaje przesunięty o 2 pozycje do przodu
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

            return (char)Value;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            EnigmaCore body = new EnigmaCore();     // ciało Enigmy
            EnigmaCore varx = new EnigmaCore();     // do interesujących zmiennych

            Console.WriteLine("PROJEKT ENIGMA");
            Console.WriteLine("trzy wirniki, bez łącznicy kablowej i odwracania(narazie)");
            Console.WriteLine("Proszę ustalić klucz kodowania np. AGR");
            string coding_key = Console.ReadLine();
            char[] coding_table = new char[2];
            coding_table = coding_key.ToCharArray();
            body.Rotor1_Position = coding_table[0];
            body.Rotor2_Position = coding_table[1];
            body.Rotor3_Position = coding_table[2];
            Console.WriteLine("Ustalony klucz kodowania: " + body.Rotor1_Position + body.Rotor2_Position + body.Rotor3_Position);

            Console.WriteLine("Podaj tekst do zaszyfrowania(tylko duże litery)");
            string tekst = Console.ReadLine();
            int rozmiar = tekst.Length;
            char[] Chars_To_Encrypt = new char[rozmiar];
            Chars_To_Encrypt = tekst.ToCharArray();

            // Szyfrowanie 
            // tutaj kod
            int i;
            for(i = 0; i < rozmiar; i++)
            {
                char letter = Chars_To_Encrypt[i];
                letter = body.Rotor1_Encryption(letter);

                // tu nie wchodzi :(
                if (varx.Rotor2_rotate)
                {
                    Console.WriteLine("wszedlem");
                    letter = body.Rotor2_Encryption(letter);
                }

                // tu nie wchodzi :( 
                if (varx.Rotor3_rotate)
                {
                    letter = body.Rotor3_Encryption(letter);
                }

                Console.Write(letter);
            }

            Console.WriteLine("\nNaciśnij dowolny klawisz aby zakończyć...");
            Console.WriteLine("Naciśnij dowolny klawisz aby zakończyć...");
            Console.ReadKey();
        }
    }
}
