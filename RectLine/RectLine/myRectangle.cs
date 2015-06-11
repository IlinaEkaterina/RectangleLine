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
        public Rectangle myRectangleOnCanvas;
        public Canvas myCanvas;
        protected double _beginX, _beginY, _currX, _currY;
        protected bool _IsMouseDown = false;       
        public static bool IsRectState;

        public myRectangle()
        {
            myRectangleOnCanvas = new Rectangle();
            myRectangleOnCanvas.Height = 40;
            myRectangleOnCanvas.Width = 80;
            myRectangleOnCanvas.StrokeThickness = 2;
            myRectangleOnCanvas.MouseDown += onMouseDown;
            myRectangleOnCanvas.MouseUp += onMouseUp;
            myRectangleOnCanvas.MouseMove += onMouseMove;
        }

        protected void onMouseDown(Object sender, MouseButtonEventArgs e)
        {
            if (IsRectState)
            {
                Rectangle rectanglePressMouse = sender as Rectangle;
                _beginX = e.GetPosition(myCanvas).X;
                _beginY = e.GetPosition(myCanvas).Y;
                _IsMouseDown = true;
                rectanglePressMouse.CaptureMouse();
            }
        }

        protected void onMouseMove(Object sender, MouseEventArgs e)
        {
            if (_IsMouseDown)
            {
                Rectangle rectanglePressMouse = sender as Rectangle;
                _currX = e.GetPosition(myCanvas).X;
                _currY = e.GetPosition(myCanvas).Y;
                rectanglePressMouse.SetValue(Canvas.LeftProperty, _currX);
                rectanglePressMouse.SetValue(Canvas.TopProperty, _currY);
            }
        }
        protected void onMouseUp(Object sender, MouseButtonEventArgs e)
        {
            _beginY = _currY;
            _beginX = _currX;
            Rectangle rectanglePressMouse = sender as Rectangle;
            _IsMouseDown = false;
            rectanglePressMouse.ReleaseMouseCapture();
        }
    }
}
