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
    class myRectangle
    {
        public Rectangle myRect;
        public Canvas myCvs;
        protected double _beginX, _beginY, _currX, _currY;
        protected bool _IsMouseDown = false;       
        public static bool IsRectState;

        public myRectangle()
        { 
            myRect = new Rectangle();
            myRect.Height = 40;
            myRect.Width = 80;            
            myRect.StrokeThickness = 2;            
            myRect.MouseDown += onMouseDown;
            myRect.MouseUp += onMouseUp;
            myRect.MouseMove += onMouseMove;
        }

        protected void onMouseDown(Object sender, MouseButtonEventArgs e)
        {
            if (IsRectState)
            {
                Rectangle rect = sender as Rectangle;
                _beginX = e.GetPosition(myCvs).X;
                _beginY = e.GetPosition(myCvs).Y;
                _IsMouseDown = true;
                rect.CaptureMouse();
            }
        }

        protected void onMouseMove(Object sender, MouseEventArgs e)
        {
            if (_IsMouseDown)
            {
                Rectangle rect = sender as Rectangle;                
                _currX = e.GetPosition(myCvs).X;
                _currY = e.GetPosition(myCvs).Y;
                rect.SetValue(Canvas.LeftProperty, _currX);
                rect.SetValue(Canvas.TopProperty, _currY);
            }
        }
        protected void onMouseUp(Object sender, MouseButtonEventArgs e)
        {
            _beginY = _currY;
            _beginX = _currX;
            Rectangle rect = sender as Rectangle;
            _IsMouseDown = false;
            rect.ReleaseMouseCapture();
        }
    }
}
