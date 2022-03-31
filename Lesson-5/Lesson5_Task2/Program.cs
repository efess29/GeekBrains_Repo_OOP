using System;

namespace Lesson5_Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            ComplexNumber n1 = new ComplexNumber();
            ComplexNumber n2 = new ComplexNumber(100, 20.6);
            
            Console.WriteLine(n1);
            Console.WriteLine(n2);
            
            n1.RealA = 50 + 50;
            bool result = (n1 != n2);
            n1.RealB = 20 + 0.6;
            result = (n1 == n2);
            var result2 = n2 + n2;
            result2 = n2 - n2;

            var multiplier = n2 * result2;
            multiplier = n2 * n2;
        }
    }
}
