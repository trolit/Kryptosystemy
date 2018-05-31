﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            local += 1;                              // przesuwamy pozycje wirnika o 1
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

    class Program
    {
        static void Main(string[] args)
        {
            EnigmaCore body = new EnigmaCore();     // ciało Enigmy

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("------------------------------");
            Console.WriteLine("Enigma - sol2");
            Console.WriteLine("Wersja: 1.0");
            Console.WriteLine("Ostatnia łatka: 28.05.18");
            Console.WriteLine("------------------------------\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Proszę ustalić klucz kodowania np. AGR - tylko duże litery!");
            string coding_key = Console.ReadLine();
            char[] coding_table = new char[2];
            coding_table = coding_key.ToCharArray();
            body.Rotor1_Position = coding_table[0];
            body.Rotor2_Position = coding_table[1];
            body.Rotor3_Position = coding_table[2];
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nUstalony klucz kodowania: \n => " + body.Rotor1_Position + body.Rotor2_Position + body.Rotor3_Position);
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\nPodaj tekst do zaszyfrowania(uwaga: tylko duże litery!)");
            string tekst = Console.ReadLine();
            int rozmiar = tekst.Length;
            char[] Chars_To_Encrypt = new char[rozmiar];
            Chars_To_Encrypt = tekst.ToCharArray();

            char[] Encrypted_Text = new char[rozmiar];
            char[] Main_Matrix = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

            // Przesuwanie TABLICY DZIALA!
            // POPRAWIC RESZTE!!!!
            // zajrzenie do kodu: 28 V 18, i O_O ....

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

                            int var = body.Return_RotorPositionNumber(letter);

                            letter = Main_Matrix[var];                              // z tablicy liter wybieramy element rozmiar + 1   

                            Main_Matrix = body.Move_array(Main_Matrix);             // przesuwamy pozycje znaków w tablicy
                }
                Encrypted_Text[i] = letter;                                 // wpisujemy znak do tablicy
            }

            // wypisanie zaszyfrowanego tekstu:
            for(int w = 0; w < Encrypted_Text.Length; w++)
            {
                Console.Write(Encrypted_Text[w]);
            }

            Console.ReadKey();
        }
    }
}
