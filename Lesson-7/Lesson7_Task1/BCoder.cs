using System;

namespace Lesson7_Task1
{
    public sealed class BCoder : ICoder
    {
        /// <summary>
        /// Реализует метод дешифрования
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string Decode(string s)
        {
            return Encode(s);
        }

        /// <summary>
        /// Реализует метод шифрования
        /// </summary>
        /// <param name="s"></param>
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
                int firstRusLow = 1072;
                int lastRusLow = 1103;

                int firstEngLow = 97;
                int lastEngLow = 122;

                var isLow = char.IsLower(s[i]);
                var sCharInt = (int)char.ToLower(s[i]);
                
                if (sCharInt >= firstRusLow && sCharInt <= lastRusLow)
                {
                    sCharInt = lastRusLow - (sCharInt - firstRusLow);
                }
                
                if (sCharInt >= firstEngLow && sCharInt <= lastEngLow)
                {
                    sCharInt = lastEngLow - (sCharInt - firstEngLow);
                }

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
    }
}
