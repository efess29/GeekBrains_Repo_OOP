using System;
using Lesson7_Task2.Interfaces;

namespace Lesson7_Task2.Entities
{
    public class Point : BaseFigureProperties, IFigure
    {
        public Point(double x, double y, bool isVisible = true)
        {
            X = x;
            Y = y;
            IsVisible = isVisible;
        }

        public virtual void MoveHorizontal(double moveLeft = 0, double moveRight = 0)
        {
            X += moveRight;
            X -= moveLeft;
        }

        public virtual void MoveVertical(double moveUp = 0, double moveDown = 0)
        {
            Y += moveUp;
            Y -= moveDown;
        }

        public virtual void ChangeColor(Colors colors)
        {
            _color = colors.ToString();
        }

        public virtual string CheckIsVisible()
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

        public virtual string ShowFigure()
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
