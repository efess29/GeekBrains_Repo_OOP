using System;

namespace Lesson7_Task1
{
    public interface ICoder
    {
        /// <summary>
        /// Представляет метод шифрования
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        string Encode(string s);

        /// <summary>
        /// Представляет метод дешифрования
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        string Decode(string s);
    }
}
