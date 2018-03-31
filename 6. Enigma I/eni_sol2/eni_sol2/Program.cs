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

        public char[] Move_array(char[] array)
        {
            int i = 0;                               // zmienne pomocnicze
            int j = array.Length;
            char tmp = array[j];                     // bierzemy ostatni znak
            array[i] = tmp;                          // ustawiamy go na początku tablicy
            for(i = 1; i < array.Length; i++)        // wypełniamy pozostałymi znakami tablicę
            {
                int value = (int)array[0];
                value += 1;
                if(value > 90)
                {
                    value -= 26;
                }
                array[i] = (char)value;
            }

            return array;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            EnigmaCore body = new EnigmaCore();     // ciało Enigmy

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

            char[] Encrypted_Text = new char[rozmiar];
            char[] Main_Matrix = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

            int i;
            for (i = 0; i < rozmiar; i++)
            {
                char letter = Chars_To_Encrypt[i];                          // bierzemy literkę
                if (letter >= 65 && letter <= 90)                           // sprawdzamy czy się mieści w przedziale 65<>90
                {
                    for (int tmp = 0; tmp < rozmiar; tmp++)
                    {
                        if (letter == Main_Matrix[tmp])                     // szuka gdzie w tablicy jest ta litera
                        {
                            tmp += 1;                                       // przesuwamy literę (narazie o 1)
                            letter = (char)tmp;
                            break;
                        }
                    }
                    Main_Matrix = body.Move_array(Main_Matrix);             // przesuwamy pozycje znaków w tablicy
                }
                Encrypted_Text[i] = letter;
            }

            // wypisanie zaszyfrowanego tekstu:
        }
    }
}
