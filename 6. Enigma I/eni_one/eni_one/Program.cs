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

        // Wirnik 1
        public char Rotor1_Encryption(char Letter)
        {
            Value = (int)Letter;
            Value += 6;                              // przesuniecie o 6 pozycji otrzymanego znaku
            char x = Rotor1_Position;
            int y = (int)x + 6;
            Rotor1_Position = (char)y;               // przestawienie wirnika o tyle samo do przodu (6)

            if((int)Rotor1_Position > (int)'Z')      // jeśli wirnik1 osiągnie pełny obrót
            {
                char temporary = Rotor2_Position;
                int next = (int)temporary + 1;
                Rotor2_Position = (char)next;

                temporary = Rotor1_Position;
                next = (int)temporary - 26;
                Rotor1_Position = (char)next;
                Value -= 26;
            }

            return (char)Value;
        }

        // Wirnik 2
        public char Rotor2_Encryption(char Letter)
        {
            Value = (int)Letter;
            Value += 8;                              // przesuniecie o 8 pozycji
            char x = Rotor2_Position;
            int y = (int)x + 8;
            Rotor2_Position = (char)y;               // przestawienie wirnika o tyle samo do przodu (8)

            if ((int)Rotor2_Position > (int)'Z')
            {
                char temporary = Rotor3_Position;
                int next = (int)temporary + 1;
                Rotor3_Position = (char)next;

                temporary = Rotor2_Position;
                next = (int)temporary - 26;
                Rotor2_Position = (char)next;
                Value -= 26;
            }

            return (char)Value;
        }

        // Wirnik 3
        public char Rotor3_Encryption(char Letter)
        {
            Value = (int)Letter;
            Value += 5;
            char x = Rotor3_Position;
            int y = (int)x + 5;
            Rotor3_Position = (char)y;               // przestawienie wirnika o tyle samo do przodu (5)

            if ((int)Rotor3_Position > (int)'Z')
            {
                char temporary = Rotor3_Position;
                int next = (int)temporary - 26;
                Rotor2_Position = (char)next;
                Value -= 26;
            }

            return (char)Value;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            EnigmaCore body = new EnigmaCore();
            EnigmaCore varx = new EnigmaCore();

            Console.WriteLine("E N I G M A");
            Console.WriteLine("trzy wirniki, bez łącznicy kablowej i odwracania narazie");
            Console.WriteLine("Punkty przeniesienia obrotu dla wirników: R-F-W i oczywiście dla przekroczenia Z");
            Console.WriteLine("Ustal klucz kodowania np. AGR");
            string coding_key = Console.ReadLine();
            char[] coding_table = new char[2];
            coding_table = coding_key.ToCharArray();
            body.Rotor1_Position = coding_table[0];
            body.Rotor2_Position = coding_table[1];
            body.Rotor3_Position = coding_table[2];
            Console.WriteLine("Klucz kodowania: " + body.Rotor1_Position + body.Rotor2_Position + body.Rotor3_Position);

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
            Console.ReadKey();
        }
    }
}
