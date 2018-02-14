using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eni_one
{
    class EnigmaCore
    {
        public bool reverse = false;        // odwracanie (faza budowy)
        public int rotor_counter = 1;
        public char Rotor1_StartPosition;
        public char Rotor2_StartPosition;
        public char Rotor3_StartPosition;
        public int Value;

        //  rotor 1 A -> L  (A B C D E F G H I J K L) -  +11
        //  rotor 2 L -> D  (A B C D E F G H I J K L) -  -8
        //  rotor 3 D -> K  (D E F G H I J K L)       -  +7

        // punkt przeniesienia obrotu: R
        // lub gdy przekroczy Z
        public char Rotor1_Encryption(char Letter)
        {
            Value = (int)Letter;
            Value += 11;

            if(Value > (int)'Z')
            {
                Value -= 26;
            }
            else if(Value == (int)'R')
            {
                Value += 1;
            }

            return (char)Value;
        }

        // punkt przeniesienia obrotu: F
        // lub gdy przekroczy Z
        public char Rotor2_Encryption(char Letter)
        {
            Value = (int)Letter;
            Value += 11;

            if (Value > (int)'Z')
            {
                Value -= 26;
            }
            else if (Value == (int)'F')
            {
                Value += 1;
            }

            return (char)Value;
        }

        // punkt przeniesienia obrotu: W
        // lub gdy przekroczy Z
        public char Rotor3_Encryption(char Letter)
        {
            Value = (int)Letter;
            Value += 11;

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

            Console.WriteLine("E  N I G M  A");
            Console.WriteLine("trzy wirniki, bez łącznicy kablowej i odwracania(narazie)");
            Console.WriteLine("Punkty przeniesienia obrotu dla wirników: R-F-W i oczywiście przekroczenie Z");
            Console.WriteLine("Ustal klucz kodowania np. AGR(podawaj po jednej literze");
            Console.WriteLine("Zatwierdzaj przyciskiem ENTER");

            body.Rotor1_StartPosition = Convert.ToChar(Console.ReadLine());
            body.Rotor2_StartPosition = Convert.ToChar(Console.ReadLine());
            body.Rotor3_StartPosition = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Klucz kodowania: " + body.Rotor1_StartPosition + body.Rotor2_StartPosition + body.Rotor3_StartPosition);

            Console.WriteLine("Podaj tekst do zaszyfrowania(tylko duże litery)");
            string tekst = Console.ReadLine();
            int rozmiar = tekst.Length;
            char[] Chars_To_Encrypt = new char[rozmiar];
            Chars_To_Encrypt = tekst.ToCharArray();

            // Szyfrowanie 
            int i;
            for(i = 0; i < rozmiar; i++)
            {
                char ToEncrypt = Chars_To_Encrypt[i];
                if(varx.reverse == false && varx.rotor_counter == 1)
                {
                    ToEncrypt = body.Rotor1_Encryption(ToEncrypt);
                    varx.rotor_counter = 2;
                }

                if(varx.reverse == false && varx.rotor_counter == 2)
                {
                    ToEncrypt = body.Rotor2_Encryption(ToEncrypt);
                    varx.rotor_counter = 3;
                }

                if(varx.reverse == false && varx.rotor_counter == 3)
                {
                    ToEncrypt = body.Rotor3_Encryption(ToEncrypt);
                    varx.reverse = false;
                }

                varx.rotor_counter = 1;

                Console.Write(ToEncrypt);
            }

            Console.WriteLine("\nNaciśnij dowolny klawisz aby zakończyć...");
            Console.ReadKey();
        }
    }
}
