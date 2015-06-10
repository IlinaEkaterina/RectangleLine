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
    class myRectangleOne:myRectangle
    {
        public myRectangleOne()
            :base()
        {
            myRect.Fill = System.Windows.Media.Brushes.SlateBlue;
            myRect.Stroke = Brushes.DarkSlateBlue;
            Canvas.SetLeft(myRect, 150);
            Canvas.SetTop(myRect, 150);
        }
    }
}
