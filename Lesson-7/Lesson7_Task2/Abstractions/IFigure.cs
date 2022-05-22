using System;

namespace Lesson7_Task2.Interfaces
{
    public interface IFigure
    {
        
        void MoveHorizontal(double moveLeft = 0, double moveRight = 0);
        
        void MoveVertical(double moveUp = 0, double moveDown = 0);
        
        void ChangeColor(BaseFigureProperties.Colors colors);
        
        string CheckIsVisible();
        
        string ShowFigure();
    }
}
