using System;
using File_Manager.Entities;

namespace File_Manager.Helpers
{
    /// <summary>
    /// Представляет класс методов для внешнего оформления файловой "консоли"
    /// </summary>
    class FileConsoleHelper
    {
        /// <summary>
        /// Представляет метод вывода одинароной внешней границы для кнопок (пунктов меню)
        /// </summary>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        /// <param name="sizeX"></param>
        /// <param name="sizeY"></param>
        /// <param name="textColor"></param>
        /// <param name="backgroundColor"></param>
        public static void PrintBorderLine(int posX, int posY, int sizeX, int sizeY,
            ConsoleColor textColor, ConsoleColor backgroundColor)
        {
            try
            {
                var SizeX = posX + sizeX;
                var SizeY = posY + sizeY;
                var b = new BorderLine(0);
                Console.ForegroundColor = textColor;
                Console.BackgroundColor = backgroundColor;

                for (var y = posY; y < SizeY; y++)
                    for (var x = posX; x < SizeX; x++)
                    {
                        if (y == posY && x == posX)
                        {
                            Console.SetCursorPosition(x, y);
                            Console.Write(b.topLeft);
                        }

                        if (y == posY && x > posX && x < SizeX - 1)
                        {
                            Console.SetCursorPosition(x, y);
                            Console.Write(b.lineX);
                        }

                        if (y == posY && x == SizeX - 1)
                        {
                            Console.SetCursorPosition(x, y);
                            Console.Write(b.topRight);
                        }

                        if (y > posY && y < SizeY - 1 && x == posX ||
                            y > posY && y < SizeY - 1 && x == SizeX - 1)
                        {
                            Console.SetCursorPosition(x, y);
                            Console.Write(b.lineY);
                        }

                        if (y == SizeY - 1 && x == posX)
                        {
                            Console.SetCursorPosition(x, y);
                            Console.Write(b.bottomLeft);
                        }

                        if (y == SizeY - 1 && x > posX && x < SizeX - 1)
                        {
                            Console.SetCursorPosition(x, y);
                            Console.Write(b.lineX);
                        }

                        if (y == SizeY - 1 && x == SizeX - 1)
                        {
                            Console.SetCursorPosition(x, y);
                            Console.Write(b.bottomRight);
                        }
                    }

                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }

            catch (Exception e)
            {
                ErrorLogHelper.PrintExceptionMessage("Exception:", 120 / 2 - e.Message.Length / 2, 22, ConsoleColor.White, ConsoleColor.Black);
                ErrorLogHelper.PrintExceptionMessage(e.Message, 120 / 2 - e.Message.Length / 2, 23, ConsoleColor.White, ConsoleColor.Black);
                ErrorLog.AddError(e.Message, Properties.Settings.Default.LogFilePath);
            }
        }


        /// <summary>
        /// Представляет метод вывода двойной внешней границы для панелей
        /// </summary>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        /// <param name="sizeX"></param>
        /// <param name="sizeY"></param>
        /// <param name="text"></param>
        /// <param name="background"></param>
        public static void PrintBorderLineDouble(int posX, int posY, int sizeX, int sizeY,
            ConsoleColor text, ConsoleColor background)
        {
            try
            {
                var SizeY = posY + sizeY;
                var SizeX = posX + sizeX;
                var b = new BorderLineDouble(0);
                Console.ForegroundColor = text;
                Console.BackgroundColor = background;

                for (var y = posY; y < SizeY; y++)
                    for (var x = posX; x < SizeX; x++)
                    {
                        if (y == posY && x == posX)
                        {
                            Console.SetCursorPosition(x, y);
                            Console.Write(b.topLeft);
                        }

                        if (y == posY && x > posX && x < SizeX - 1)
                        {
                            Console.SetCursorPosition(x, y);
                            Console.Write(b.lineA);
                        }

                        if (y == posY && x == SizeX - 1)
                        {
                            Console.SetCursorPosition(x, y);
                            Console.Write(b.topRight);
                        }

                        if (y > posY && y < SizeY - 1 && x == posX ||
                            y > posY && y < SizeY - 1 && x == SizeX - 1)
                        {
                            Console.SetCursorPosition(x, y);
                            Console.Write(b.lineB);
                        }

                        if (y == SizeY - 1 && x == posX)
                        {
                            Console.SetCursorPosition(x, y);
                            Console.Write(b.bottomLeft);
                        }

                        if (y == SizeY - 1 && x > posX && x < SizeX - 1)
                        {
                            Console.SetCursorPosition(x, y);
                            Console.Write(b.lineA);
                        }

                        if (y == SizeY - 1 && x == SizeX - 1)
                        {
                            Console.SetCursorPosition(x, y);
                            Console.Write(b.bottomRight);
                        }
                    }

                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }

            catch (Exception e)
            {
                ErrorLogHelper.PrintExceptionMessage("Exception:", 120 / 2 - e.Message.Length / 2, 22, ConsoleColor.White, ConsoleColor.Black);
                ErrorLogHelper.PrintExceptionMessage(e.Message, 120 / 2 - e.Message.Length / 2, 23, ConsoleColor.White, ConsoleColor.Black);
                ErrorLog.AddError(e.Message, Properties.Settings.Default.LogFilePath);
            }
        }


        /// <summary>
        /// Представляет метод вывода контента в панелях
        /// </summary>
        /// <param name="str"></param>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        /// <param name="textColor"></param>
        /// <param name="backgroundColor"></param>
        public static void PrintString(string str, int posX, int posY,
           ConsoleColor textColor, ConsoleColor backgroundColor)
        {
            try
            {
                Console.ForegroundColor = textColor;
                Console.BackgroundColor = backgroundColor;

                Console.SetCursorPosition(posX, posY);
                Console.Write(str);

                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }

            catch (Exception e)
            {
                ErrorLogHelper.PrintExceptionMessage("Exception:", 120 / 2 - e.Message.Length / 2, 22, ConsoleColor.White, ConsoleColor.Black);
                ErrorLogHelper.PrintExceptionMessage(e.Message, 120 / 2 - e.Message.Length / 2, 23, ConsoleColor.White, ConsoleColor.Black);
                ErrorLog.AddError(e.Message, Properties.Settings.Default.LogFilePath);
            }
        }
    }
}
