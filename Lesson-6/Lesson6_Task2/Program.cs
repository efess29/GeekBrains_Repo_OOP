using System;
using Lesson6_Task2.Entities;

namespace Lesson6_Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("POINT");
            Point point = new Point(0, 0);
            point.ChangeColor(BaseFigure.FigureColor.Red);
            point.ShowFigure();

            point.MoveHorizontal(3, 0);
            point.ChangeColor(BaseFigure.FigureColor.Yellow);
            point.ShowFigure();

            point.MoveVertical(0, 3);
            point.ChangeColor(BaseFigure.FigureColor.Magenta);
            point.ShowFigure();

            point.CheckIsVisible();

            Console.WriteLine("CIRCLE");
            Circle circle = new Circle(0, 0, 8);
            circle.ChangeColor(BaseFigure.FigureColor.Purple);
            circle.ShowFigure();

            var resultCircle = circle.CalcCircleArea();
            Console.WriteLine($"Circle area with {8} radius: {resultCircle}");
            circle.ChangeColor(BaseFigure.FigureColor.Red);
            circle.ShowFigure();

            circle.MoveHorizontal(0, 6);
            circle.ChangeColor(BaseFigure.FigureColor.Blue);
            circle.ShowFigure();

            circle.MoveVertical(5, 0);
            circle.ChangeColor(BaseFigure.FigureColor.Yellow);
            circle.ShowFigure();

            circle.CheckIsVisible();

            Console.WriteLine("RECTANGLE");
            Rectangle rectangle = new Rectangle(1, 1, 5, 7);
            rectangle.ChangeColor(BaseFigure.FigureColor.Blue);
            rectangle.ShowFigure();

            var resultRectangle = rectangle.CalcRectangleArea();
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
