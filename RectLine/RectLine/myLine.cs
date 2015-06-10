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
        public Line line;
        public Canvas myCvs;
        public bool isDrawing = false;
        Point point;
        public Rectangle RectOne;
        public Rectangle RectTwo;
        
 
        public myLine()
        {
            line = new Line();
            line.StrokeThickness = 2;
        }

        public void onMouseDown(Object sender, MouseButtonEventArgs e)
        {

            point = e.GetPosition(myCvs);
            line.X1 = line.X2 = point.X;
            line.Y1 = line.Y2 = point.Y;
            isDrawing = true;
        }

        public void onMouseMove(Object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                Point pointEnd = e.GetPosition(myCvs);
                line.X2 = pointEnd.X;
                line.Y2 = pointEnd.Y;
            }
        }
 
        public void reDrawingLine1(Object sender, MouseEventArgs e)
        {
             line.X1 = Canvas.GetLeft(RectOne) + RectOne.Width/2;             
             line.Y1 = Canvas.GetTop(RectOne) + RectOne.Height/2;
         
        }

        public void reDrawingLine2(Object sender, MouseEventArgs e)
        {
            line.X2 = Canvas.GetLeft(RectTwo) + RectTwo.Width / 2;
            line.Y2 = Canvas.GetTop(RectTwo) + RectTwo.Height / 2;
        }
    }

}
