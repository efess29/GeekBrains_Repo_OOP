using System;

namespace Lesson3_Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter some text: ");
                var sourceString = Console.ReadLine();

                if (!String.IsNullOrEmpty(sourceString))
                {
                    var targetString = ReverseString(sourceString);
                    Console.WriteLine($"Reversed string is: {targetString}");
                    Console.ReadLine();
                }

                else
                {
                    throw new Exception("Entered string is empty. Enter some text!");
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("Exception information: {0}", e.Message);
                Console.ReadLine();
            }
            
        }

        /// <summary>
        /// Представляет метод возврата строки с обратным порядком букв
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ReverseString(string s)
        {
            try
            {
                if (String.IsNullOrEmpty(s))
                {
                    throw new Exception("Entered string is empty. Enter some text!");
                }

                var charArray = s.ToCharArray();
                Array.Reverse(charArray);

                return new string(charArray);
            }

            catch (Exception e)
            {
                Console.WriteLine("Exception information: {0}", e.Message);
            }

            return String.Empty;
        }
    }
}
