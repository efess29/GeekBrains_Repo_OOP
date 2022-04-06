using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7_Task1
{
    public sealed class ACoder : ICoder
    {
        /// <summary>
        /// Реализует метод шифрования
        /// </summary>
        /// <returns></returns>
        public string Encode(string s)
        {
            if (s is null)
            {
                throw new ArgumentException($"{nameof(s)} is Null");
            }

            char[] arr = new char[s.Length];
            
            for (int i = 0; i < s.Length; i++)
            {
                var isLow = char.IsLower(s[i]);
                var sCharInt = char.ToLower(s[i]) + 1;
                
                if (isLow)
                {
                    arr[i] = (char)sCharInt;
                }
                
                else
                {
                    arr[i] = char.ToUpper((char)sCharInt);
                }
            }

            return new string(arr);
        }

        /// <summary>
        /// Представляет метод дешифрования
        /// </summary>
        /// <returns></returns>
        public string Decode(string s)
        {
            return String.Empty;
        }
    }
}
