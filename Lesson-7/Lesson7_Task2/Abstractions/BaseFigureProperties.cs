using System;

namespace Lesson7_Task2.Interfaces
{
    public abstract class BaseFigureProperties
    {
        protected double _x;
        protected double _y;
        protected string _color;
        protected bool _isVisible;

        public enum Colors
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

        protected double X
        {
            get => _x;
            set => _x = value;
        }

        protected double Y
        {
            get => _y;
            set => _y = value;
        }

        protected bool IsVisible
        {
            get => _isVisible;
            set => _isVisible = value;
        }
    }
}
