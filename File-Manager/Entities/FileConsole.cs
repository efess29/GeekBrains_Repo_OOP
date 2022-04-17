using System;

namespace File_Manager.Entities
{
    /// <summary>
    /// Представляет класс вывода одинарной внешней границы
    /// </summary>
    internal class BorderLine
    {
        public string topLeft;
        public string topRight;
        public string bottomLeft;
        public string bottomRight;
        public string lineX;
        public string lineY;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="BorderLine"/>
        /// </summary>
        /// <param name="n"></param>
        public BorderLine(int n)
        {
            topLeft = "┌";
            topRight = "┐";
            bottomLeft = "└";
            bottomRight = "┘";
            lineX = "─";
            lineY = "│";
        }
    }

    /// <summary>
    /// Представляет класс вывода двойной внешней границы
    /// </summary>
    internal class BorderLineDouble
    {
        public string topLeft;
        public string topRight;
        public string bottomLeft;
        public string bottomRight;
        public string lineA;
        public string lineB;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="BorderLineDouble"/>
        /// </summary>
        /// <param name="n"></param>
        public BorderLineDouble(int n)
        {
            topLeft = "╔";
            topRight = "╗";
            bottomLeft = "╚";
            bottomRight = "╝";
            lineA = "═";
            lineB = "║";
        }
    }
}
