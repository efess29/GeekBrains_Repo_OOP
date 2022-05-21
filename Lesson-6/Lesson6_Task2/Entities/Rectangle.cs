using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6_Task2.Entities
{
    public class Rectangle : Point
    {
        private Point[] _vertices = new Point[4];
        private double _width;
        private double _height;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Rectangle"/>
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="isVisible"></param>
        public Rectangle(double x, double y, double width, double height, bool isVisible = true) : base(x, y, isVisible)
        {
            _width = width;
            _height = height;
            _vertices[0] = new Point(x, y);
            _vertices[1] = new Point(x + _width, y);
            _vertices[2] = new Point(x, y + _height);
            _vertices[3] = new Point(x + _width, y + _height);
        }

        /// <summary>
        /// Представляет переопределение метода перемещения фигуры по горизонтали
        /// </summary>
        /// <param name="moveLeft"></param>
        /// <param name="moveRight"></param>
        public override void MoveHorizontal(double moveLeft = 0, double moveRight = 0)
        {
            _vertices[0].MoveHorizontal(moveLeft, moveRight);
            _vertices[1].MoveHorizontal(moveLeft, moveRight);
            _vertices[2].MoveHorizontal(moveLeft, moveRight);
            _vertices[3].MoveHorizontal(moveLeft, moveRight);
        }

        /// <summary>
        /// Представляет переопределение метода перемещения фигуры по вертикали
        /// </summary>
        /// <param name="moveUp"></param>
        /// <param name="moveDown"></param>
        public override void MoveVertical(double moveUp = 0, double moveDown = 0)
        {
            _vertices[0].MoveVertical(moveUp, moveDown);
            _vertices[1].MoveVertical(moveUp, moveDown);
            _vertices[2].MoveVertical(moveUp, moveDown);
            _vertices[3].MoveVertical(moveUp, moveDown);
        }

        /// <summary>
        /// Представляет переопределение метода изменения цвета фигуры
        /// </summary>
        /// <param name="colours"></param>
        public override void ChangeColor(FigureColor color)
        {
            _vertices[0].ChangeColor(color);
            _vertices[1].ChangeColor(color);
            _vertices[2].ChangeColor(color);
            _vertices[3].ChangeColor(color);
        }

        /// <summary>
        /// Представляет переопределение метода проверки видимости фигуры
        /// </summary>
        /// <returns></returns>
        public override string CheckIsVisible()
        {
            string result = $"A: {_vertices[0].CheckIsVisible()}" +
                            $"\nB: {_vertices[1].CheckIsVisible()}" +
                            $"\nC: {_vertices[2].CheckIsVisible()}" +
                            $"\nD: {_vertices[3].CheckIsVisible()}";

            Console.WriteLine(result);

            return result;
        }

        /// <summary>
        /// Представляет переопределение метода вывода фигуры
        /// </summary>
        /// <returns></returns>
        public override string ShowFigure()
        {
            string result = "Rectangle:" +
                              $"\nA: {_vertices[0].ShowFigure()}" +
                              $"\nB: {_vertices[1].ShowFigure()}" +
                              $"\nC: {_vertices[2].ShowFigure()}" +
                              $"\nD: {_vertices[3].ShowFigure()}";
            
            Console.WriteLine(result);

            return result;
        }

        /// <summary>
        /// Представляет метод вычисления площади прямоугольника
        /// </summary>
        /// <returns></returns>
        public double CalcRectangleArea()
        {
            return _width * _height;
        }
    }
}
