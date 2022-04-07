using System;
using Lesson7_Task2.Interfaces;

namespace Lesson7_Task2.Entities
{
    public sealed class Circle : Point, IFigureArea
    {
        private Point _center;
        private double _radius;

        public Circle(double x, double y, double radius) : base(x, y)
        {
            _radius = radius;
            _center = new Point(x, y);
        }

        public override void MoveVertical(double moveUp = 0, double moveDown = 0)
        {
            _center.MoveVertical(moveUp, moveDown);
        }

        public override void MoveHorizontal(double moveLeft = 0, double moveRight = 0)
        {
            _center.MoveHorizontal(moveLeft, moveRight);
        }

        public override string ShowFigure()
        {
            string result = $"Circle: {_center.ShowFigure()}";

            Console.WriteLine(result);

            return result;
        }

        public override void ChangeColor(Colors colours)
        {
            _center.ChangeColor(colours);
        }

        public override string CheckIsVisible()
        {
            string result = $"Circle is visible: {_center.CheckIsVisible()}";

            Console.WriteLine(result);

            return result;
        }

        public double GetArea()
        {
            const double pi = 3.14;

            double square = pi * (_radius * _radius);

            return square;
        }
    }
}
