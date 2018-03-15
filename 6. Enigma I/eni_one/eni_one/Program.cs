using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eni_one
{
    class EnigmaCore
    {
        public char Rotor1_Position;    
        public char Rotor2_Position;
        public char Rotor3_Position;
        public int Value;

        // Wirnik 1 (+ obsługa wirnika 2)
        public char Rotor1_Encryption(char Letter)
        {
            Value = (int)Letter;
            Value += 4;                              // przesuniecie o 4 pozycji otrzymanego znaku
            char x = Rotor1_Position;                // bierzemy aktualne miejsce wirnika
            int y = (int)x + 4;                      // przesuwamy wirnik o 4 do przodu
            Rotor1_Position = (char)y;               // przestawienie wirnika o tyle samo do przodu (6)

            if((int)Rotor1_Position > (int)'Z')      // jeśli wirnik1 przekroczy wartość 90
            {
                char temporary = Rotor2_Position;    // weź aktualną pozycję wirnika2
                int next = (int)temporary + 1;       // przerzuć go do przodu o 1
                if(next > (int)'Z')                  // jeśli wirnik2 przekroczy wartość 90
                {
                    next -= 26;                      // zresetuj wirnik2
                }
                Rotor2_Position = (char)next;        // wirnik2 zresetowany


                if((int)Rotor1_Position > (int)'Z')  // zaopiekowanie się wirnikiem1
                {
                    temporary = Rotor1_Position;
                    next = (int)temporary - 26;
                    Rotor1_Position = (char)next;
                }

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
            Value = (int)Letter;
            Value += 3;                              // przesuniecie o 3 pozycji
            char x = Rotor2_Position;                // pobieramy informacje odnośnie aktualnej pozycji wirnika 2
            int y = (int)x + 3;                      // wirnik2 zostaje przesunięty o 3 pozycje do przodu
            Rotor2_Position = (char)y;               // przypisujemy do wirnika2 zaktualizowaną pozycję

            if ((int)Rotor2_Position > (int)'Z')     // jeśli wirnik2 przekroczy wartość 90
            {
                char temporary = Rotor3_Position;
                int next = (int)temporary + 1;
                if (next > (int)'Z')                  // jeśli wirnik3 przekroczy wartość 90
                {
                    next -= 26;                       // zresetuj wirnik3
                }
                Rotor3_Position = (char)next;         // wirnik3 zresetowany

                if ((int)Rotor2_Position > (int)'Z')  // zaopiekowanie się wirnikiem2
                {
                    temporary = Rotor2_Position;
                    next = (int)temporary - 26;
                    Rotor2_Position = (char)next;
                }

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
            Value = (int)Letter;
            Value += 2;                              // przesuniecie o 2 pozycji
            char x = Rotor3_Position;                // pobieramy informacje odnośnie aktualnej pozycji wirnika 3
            int y = (int)x + 2;                      // wirnik3 zostaje przesunięty o 2 pozycje do przodu
            Rotor3_Position = (char)y;               // przypisujemy do wirnika3 zaktualizowaną pozycję

            if ((int)Rotor3_Position > (int)'Z')
            {
                char temporary = Rotor3_Position;
                int next = (int)temporary - 26;
                Rotor2_Position = (char)next;
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

            Console.WriteLine("E N I G M A");
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
                letter = body.Rotor2_Encryption(letter);
                letter = body.Rotor3_Encryption(letter);
                Console.Write(letter);
            }

            Console.WriteLine("\nNaciśnij dowolny klawisz aby zakończyć...");
            Console.WriteLine("\nNaciśnij dowolny klawisz aby zakończyć...");
            Console.WriteLine("\nNaciśnij dowolny klawisz aby zakończyć...");
            Console.ReadKey();
        }
    }
}
