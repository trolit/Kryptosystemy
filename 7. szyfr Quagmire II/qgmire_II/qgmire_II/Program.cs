using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qgmire_II
{
    class Quagmire
    {
        static string uzupelnijAlfabet(string a)
        {
            string w = "";
            for (int i = 0; i < a.Length; i++)
                if (w.IndexOf(a[i]) == -1)
                    w += a[i];
            for (char i = 'A'; i <= 'Z'; i++)
                if (w.IndexOf(i) == -1)
                    w += i;
            return w;
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            Quagmire op = new Quagmire();

            Console.WriteLine("Szyfrownie Quagmire II");
            Console.WriteLine("źródło: mattomatti");
            Console.WriteLine("Nacisnij klawisz aby zakonczyc dzialanie programu...");
            Console.ReadKey();
        }
    }
}
