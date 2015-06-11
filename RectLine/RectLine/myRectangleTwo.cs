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
    class myRectangleTwo : myRectangle
    {
         public myRectangleTwo()
            :base()
        {
            myRectangleOnCanvas.Fill = System.Windows.Media.Brushes.LawnGreen;
            myRectangleOnCanvas.Stroke = Brushes.LimeGreen;
            myRectangleOnCanvas.RadiusX = 10;
            myRectangleOnCanvas.RadiusY = 10;
            Canvas.SetLeft(myRectangleOnCanvas, 40);
            Canvas.SetTop(myRectangleOnCanvas, 40);

        }
    }
}
