﻿using System;
using Lesson7_Task2.Interfaces;

namespace Lesson7_Task2.Entities
{
    public sealed class Rectangle : Point, IFigureArea
    {
        private Point[] _vertices = new Point[4];
        private double _width;
        private double _height;

        public Rectangle(double x, double y, double width, double height, bool isVisible = true) : base(x, y, isVisible)
        {
            _width = width;
            _height = height;
            _vertices[0] = new Point(x, y);
            _vertices[1] = new Point(x + _width, y);
            _vertices[2] = new Point(x, y + _height);
            _vertices[3] = new Point(x + _width, y + _height);
        }

        public override void MoveHorizontal(double moveLeft = 0, double moveRight = 0)
        {
            _vertices[0].MoveHorizontal(moveLeft, moveRight);
            _vertices[1].MoveHorizontal(moveLeft, moveRight);
            _vertices[2].MoveHorizontal(moveLeft, moveRight);
            _vertices[3].MoveHorizontal(moveLeft, moveRight);
        }

        public override void MoveVertical(double moveUp = 0, double moveDown = 0)
        {
            _vertices[0].MoveVertical(moveUp, moveDown);
            _vertices[1].MoveVertical(moveUp, moveDown);
            _vertices[2].MoveVertical(moveUp, moveDown);
            _vertices[3].MoveVertical(moveUp, moveDown);
        }

        public override void ChangeColor(Colors colors)
        {
            _vertices[0].ChangeColor(colors);
            _vertices[1].ChangeColor(colors);
            _vertices[2].ChangeColor(colors);
            _vertices[3].ChangeColor(colors);
        }

        public override string CheckIsVisible()
        {
            string result = $"A: {_vertices[0].CheckIsVisible()}" +
                            $"\nB: {_vertices[1].CheckIsVisible()}" +
                            $"\nC: {_vertices[2].CheckIsVisible()}" +
                            $"\nD: {_vertices[3].CheckIsVisible()}";

            Console.WriteLine(result);

            return result;
        }

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

        public double GetArea()
        {
            double square = (_width * _height);

            return square;
        }
    }
}
