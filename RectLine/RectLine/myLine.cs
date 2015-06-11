using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace RectLine
{
    class myLine
    {
        public Line linePainted;
        public Canvas myCanvas;
        public bool isDrawing = false;
        Point pointLine;
        public Rectangle RectangleOne;
        public Rectangle RectangleTwo;
        
 
        public myLine()
        {
            linePainted = new Line();
            linePainted.StrokeThickness = 2;
        }

        public void onMouseDown(Object sender, MouseButtonEventArgs e)
        {
            pointLine = e.GetPosition(myCanvas);
            linePainted.X1 = linePainted.X2 = pointLine.X;
            linePainted.Y1 = linePainted.Y2 = pointLine.Y;
            isDrawing = true;
        }

        public void onMouseMove(Object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                Point pointEnd = e.GetPosition(myCanvas);
                linePainted.X2 = pointEnd.X;
                linePainted.Y2 = pointEnd.Y;
            }
        }
 
        public void reDrawingLine1(Object sender, MouseEventArgs e)
        {
            linePainted.X1 = Canvas.GetLeft(RectangleOne) + RectangleOne.Width / 2;
            linePainted.Y1 = Canvas.GetTop(RectangleOne) + RectangleOne.Height / 2;         
        }

        public void reDrawingLine2(Object sender, MouseEventArgs e)
        {
            linePainted.X2 = Canvas.GetLeft(RectangleTwo) + RectangleTwo.Width / 2;
            linePainted.Y2 = Canvas.GetTop(RectangleTwo) + RectangleTwo.Height / 2;
        }
    }

}
