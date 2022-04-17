using System;
using File_Manager.Entities;

namespace File_Manager.Helpers
{
    /// <summary>
    /// Представляет класс методов для работы с выводом информации об ошибках / исключениях
    /// </summary>
    class ErrorLogHelper
    {
        /// <summary>
        /// Представляет метод вывода сообщений об ошибке
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        /// <param name="textColor"></param>
        /// <param name="backgroundColor"></param>
        public static void PrintExceptionMessage(string msg, int posX, int posY,
           ConsoleColor textColor, ConsoleColor backgroundColor)
        {
            try
            {
                Console.ForegroundColor = textColor;
                Console.BackgroundColor = backgroundColor;

                Console.SetCursorPosition(posX, posY);
                Console.Write(msg);

                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }

            catch (Exception e)
            {
                ErrorLog.AddError(e.Message, Properties.Settings.Default.LogFilePath);
                PrintExceptionMessage("Exception:", 120 / 2 - e.Message.Length / 2, 22, ConsoleColor.White, ConsoleColor.Black);
                PrintExceptionMessage(e.Message, 120 / 2 - e.Message.Length / 2, 23, ConsoleColor.White, ConsoleColor.Black);
            }
        }
    }
}
