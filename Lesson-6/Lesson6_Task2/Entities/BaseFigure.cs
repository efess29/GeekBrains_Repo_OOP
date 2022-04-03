using System;

namespace Lesson6_Task2
{
    public abstract class BaseFigure
    {
        protected bool _isVisible;
        protected FigureColor _color;
        protected double _x;
        protected double _y;

        /// <summary>
        /// Получает или задает признак видимости фигуры
        /// </summary>
        public bool IsVisible
        {
            get => _isVisible;
            set => _isVisible = value;
        }

        /// <summary>
        /// Получает или задает цвет фигуры
        /// </summary>
        public FigureColor Color
        {
            get => _color;
            set => _color = value;
        }

        /// <summary>
        /// Получает или задает координату по оси X
        /// </summary>
        public double X
        {
            get => _x;
            set => _x = value;
        }

        /// <summary>
        /// Получает или задает координату по оси Y
        /// </summary>
        public double Y
        {
            get => _y;
            set => _y = value;
        }

        public abstract void MoveHorizontal(double moveLeft = 0, double moveRight = 0);

        public abstract void MoveVertical(double moveUp = 0, double moveDown = 0);

        public abstract void ChangeColor(FigureColor color);

        public abstract string CheckIsVisible();

        public abstract string ShowFigure();

        /// <summary>
        /// Представляет перечисление цветов фигуры
        /// </summary>
        public enum FigureColor
        {
            Red,
            Green,
            Blue,
            Yellow,
            Black,
            White,
            Magenta,
            Purple,
        }
    }
}
