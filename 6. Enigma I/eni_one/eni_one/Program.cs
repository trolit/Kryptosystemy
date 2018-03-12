using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eni_one
{
    class EnigmaCore
    {
        public bool reverse = false;
        public int turn_rotor = 1;
        public char Rotor1_StartPosition;
        public char Rotor2_StartPosition;
        public char Rotor3_StartPosition;
        public int Value;

        //  rotor 1 A -> G  przejście +6
        //  rotor 2 L -> D  przejście +6
        //  rotor 3 D -> K  przejście +6

        // Wirnik 1
        public char Rotor1_Encryption(char Letter)
        {
            Value = (int)Letter;
            Value += 10;             // przesuniecie o 10 pozycji

            if(Value > (int)'Z')     // jeśli wirnik1 osiągnie pełny obrót
            {
                char temporary = Rotor2_StartPosition;
                int next = (int)temporary + 1;
                Rotor2_StartPosition = (char)next;
                Value -= 26;
            }

            return (char)Value;
        }

        // Wirnik 2
        public char Rotor2_Encryption(char Letter)
        {
            Value = (int)Letter;
            Value += 10;            // przesuniecie o 10 pozycji

            if (Value > (int)'Z')
            {
                char temporary = Rotor3_StartPosition;
                int next = (int)temporary + 1;
                Rotor3_StartPosition = (char)next;
                Value -= 26;
            }

            return (char)Value;
        }

        // Wirnik 3
        public char Rotor3_Encryption(char Letter)
        {
            Value = (int)Letter;
            Value += 26;

            if (Value > (int)'Z')
            {
                Value -= 26;
            }
            else if (Value == (int)'W')
            {
                Value += 1;
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
            body.Rotor1_StartPosition = coding_table[0];
            body.Rotor2_StartPosition = coding_table[1];
            body.Rotor3_StartPosition = coding_table[2];
            Console.WriteLine("Klucz kodowania: " + body.Rotor1_StartPosition + body.Rotor2_StartPosition + body.Rotor3_StartPosition);

            Console.WriteLine("Podaj tekst do zaszyfrowania(tylko duże litery)");
            string tekst = Console.ReadLine();
            int rozmiar = tekst.Length;
            char[] Chars_To_Encrypt = new char[rozmiar];
            Chars_To_Encrypt = tekst.ToCharArray();

            // Szyfrowanie 
            // tutaj kod

        
            Console.WriteLine("\nNaciśnij dowolny klawisz aby zakończyć...");
            Console.ReadKey();
        }
    }
}
