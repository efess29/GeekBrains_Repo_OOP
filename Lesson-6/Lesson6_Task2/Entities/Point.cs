using System;

namespace Lesson6_Task2.Entities
{
    public class Point : BaseFigure
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Point"/>
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="isVisible"></param>
        public Point(double x, double y, bool isVisible = true)
        {
            X = x;
            Y = y;
            IsVisible = isVisible;
        }

        /// <summary>
        /// Представляет переопределение метода перемещения фигуры по горизонтали
        /// </summary>
        /// <param name="moveLeft"></param>
        /// <param name="moveRight"></param>
        public override void MoveHorizontal(double moveLeft = 0, double moveRight = 0)
        {
            X += moveRight;
            X -= moveLeft;
        }

        /// <summary>
        /// Представляет переопределение метода перемещения фигуры по вертикали
        /// </summary>
        /// <param name="moveUp"></param>
        /// <param name="moveDown"></param>
        public override void MoveVertical(double moveUp = 0, double moveDown = 0)
        {
            Y += moveUp;
            Y -= moveDown;
        }

        /// <summary>
        /// Представляет переопределение метода изменения цвета фигуры
        /// </summary>
        /// <param name="colours"></param>
        public override void ChangeColor(FigureColor color)
        {
            _color = color;
        }

        /// <summary>
        /// Представляет переопределение метода проверки видимости фигуры
        /// </summary>
        /// <returns></returns>
        public override string CheckIsVisible()
        {
            if (IsVisible)
            {
                return "Visible";
            }

            else
            {
                return "Is not visible";
            }
        }

        /// <summary>
        /// Представляет переопределение метода вывода фигуры
        /// </summary>
        /// <returns></returns>
        public override string ShowFigure()
        {
            var result = $"Color: {_color}" +
                         $"\nFigure is visible: {_isVisible}" +
                         $"\nCoordinates:" +
                         $"\nX: {_x}" +
                         $"\nY: {_y}";

            Console.WriteLine(result);

            return result;
        }
    }
}
