using Lesson7_Task2.Entities;
using Lesson7_Task2.Interfaces;
using System;

namespace Lesson7_Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===================");
            Console.WriteLine("POINT");
            Point point = new Point(0, 0);
            point.ChangeColor(BaseFigureProperties.Colors.Black);
            point.ShowFigure();

            point.MoveHorizontal(3, 0);
            point.ChangeColor(BaseFigureProperties.Colors.Green);
            point.ShowFigure();

            point.MoveVertical(0, 3);
            point.ChangeColor(BaseFigureProperties.Colors.Magenta);
            point.ShowFigure();

            point.CheckIsVisible();

            Console.WriteLine();
            Console.WriteLine("===================");
            Console.WriteLine("CIRCLE");
            Circle circle = new Circle(0, 0, 8);
            circle.ChangeColor(BaseFigureProperties.Colors.Purple);
            circle.ShowFigure();

            var resultCircle = circle.GetArea();
            Console.WriteLine($"Circle area with radius {8}: {resultCircle}");
            circle.ChangeColor(BaseFigureProperties.Colors.Red);
            circle.ShowFigure();

            circle.MoveHorizontal(0, 6);
            circle.ChangeColor(BaseFigureProperties.Colors.Blue);
            circle.ShowFigure();

            circle.MoveVertical(5, 0);
            circle.ChangeColor(BaseFigureProperties.Colors.Yellow);
            circle.ShowFigure();

            circle.CheckIsVisible();

            Console.WriteLine();
            Console.WriteLine("===================");
            Console.WriteLine("RECTANGLE");
            Rectangle rectangle = new Rectangle(1, 1, 5, 7);
            rectangle.ChangeColor(BaseFigureProperties.Colors.Blue);
            rectangle.ShowFigure();

            var resultRectangle = rectangle.GetArea();
            Console.WriteLine($"Rectangle area: {resultRectangle}");

            rectangle.MoveHorizontal(0, 3);
            rectangle.ShowFigure();

            rectangle.MoveVertical(3, 0);
            rectangle.ShowFigure();

            rectangle.CheckIsVisible();

            Console.ReadLine();
        }
    }
}
