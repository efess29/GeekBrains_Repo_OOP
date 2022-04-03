using System;

namespace Lesson6_Task2.Entities
{
    public class Circle : Point
    {
        private Point _center;
        private double _radius;

        const double pi = 3.14;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Circle"/>
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="radius"></param>
        public Circle(double x, double y, double radius) : base(x, y)
        {
            _radius = radius;
            _center = new Point(x, y);
        }

        /// <summary>
        /// Представляет переопределение метода перемещения фигуры по горизонтали
        /// </summary>
        /// <param name="moveLeft"></param>
        /// <param name="moveRight"></param>
        public override void MoveHorizontal(double moveLeft = 0, double moveRight = 0)
        {
            _center.MoveHorizontal(moveLeft, moveRight);
        }

        /// <summary>
        /// Представляет переопределение метода перемещения фигуры по вертикали
        /// </summary>
        /// <param name="moveUp"></param>
        /// <param name="moveDown"></param>
        public override void MoveVertical(double moveUp = 0, double moveDown = 0)
        {
            _center.MoveVertical(moveUp, moveDown);
        }

        /// <summary>
        /// Представляет переопределение метода изменения цвета фигуры
        /// </summary>
        /// <param name="colours"></param>
        public override void ChangeColor(FigureColor colour)
        {
            _center.ChangeColor(colour);
        }

        /// <summary>
        /// Представляет переопределение метода проверки видимости фигуры
        /// </summary>
        /// <returns></returns>
        public override string CheckIsVisible()
        {
            string result = $"Circle is visible: {_center.CheckIsVisible()}";

            Console.WriteLine(result);

            return result;
        }

        /// <summary>
        /// Представляет переопределение метода вывода фигуры
        /// </summary>
        /// <returns></returns>
        public override string ShowFigure()
        {
            string result = $"Circle: {_center.ShowFigure()}";

            Console.WriteLine(result);

            return result;
        }

        /// <summary>
        /// Представляет метод вычисления площади окружности
        /// </summary>
        /// <returns></returns>
        public double CalcCircleArea()
        {
            return pi * (_radius * _radius);
        }
    }
}
