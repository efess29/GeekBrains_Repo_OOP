using System;

namespace Lesson7_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            char f = 'а';
            var b = (int)f;
            b++;
            var c = (char)b;

            ACoder g = new ACoder();
            string s = "Alphabet_Check";
            string j = g.Encode(s);
            Console.WriteLine(j);
            Console.WriteLine(g.Decode(j));
            Console.ReadLine();

            Console.WriteLine();
            BCoder b1 = new BCoder();
            Console.WriteLine(b1.Encode(s));
            Console.WriteLine(b1.Decode(b1.Encode(s)));
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
