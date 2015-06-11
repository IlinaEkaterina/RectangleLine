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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        bool IsDrawLine = false;
        List<myLine> listLine = new List<myLine>();
        EStates stateLine;
        enum EStates : byte {LineOne = 1, LineTwo, LineTree};

        private void btnRectOne_Click(object sender, RoutedEventArgs e)
        {
           myRectangleOne myRectangle = new myRectangleOne();
           myRectangle.myCanvas = this.mainCanvas;
           mainCanvas.Children.Add(myRectangle.myRectangleOnCanvas);            
        }

        private void btnRectTwo_Click(object sender, RoutedEventArgs e)
        {
            myRectangleTwo myRectangle = new myRectangleTwo();
            myRectangle.myCanvas = this.mainCanvas;
            mainCanvas.Children.Add(myRectangle.myRectangleOnCanvas);
        }

        void changeStateLineRectangle()
        {
            IsDrawLine = true;
            myRectangle.IsRectState = false;
        }

        
        private void btnLine_Click(object sender, RoutedEventArgs e)
        {
            stateLine = EStates.LineOne;
            changeStateLineRectangle();
        }
        private void btnLine2_Click(object sender, RoutedEventArgs e)
        {
            stateLine = EStates.LineTwo;
            changeStateLineRectangle();
        }

        private void btnLine3_Click(object sender, RoutedEventArgs e)
        {
            stateLine = EStates.LineTree;
            changeStateLineRectangle();
        }

        private myLine selectTypeLine()
        {
            myLine myLineCanvas = null;
            switch (stateLine)
            {
                case EStates.LineOne:
                    myLineCanvas = new myLineOne();
                    break;

                case EStates.LineTwo:
                    myLineCanvas = new myLineTwo();
                    break;

                default:
                    myLineCanvas = new myLineTree();
                    break;
            }
            return myLineCanvas;
        }

        private void Cvs_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (IsDrawLine)
            {
                myLine myLineCanvas = selectTypeLine();  

                myLineCanvas.RectangleOne = returnRectangle(e);
                mainCanvas.MouseMove += myLineCanvas.onMouseMove;
                if (returnRectangle(e) != null)
                {
                    mainCanvas.MouseMove += myLineCanvas.reDrawingLine1;
                }
                myLineCanvas.myCanvas = this.mainCanvas;
                myLineCanvas.onMouseDown(sender, e);
                mainCanvas.Children.Add(myLineCanvas.linePainted);
                listLine.Add(myLineCanvas);
            }
        }

        private void btnMove_Click(object sender, RoutedEventArgs e)
        {
            myRectangle.IsRectState = true;
            IsDrawLine = false;
        }

        public Rectangle returnRectangle(MouseButtonEventArgs e)
        {
            bool IsHaveRectangle = false;
            double mouseX = e.GetPosition(mainCanvas).X;
            double mouseY = e.GetPosition(mainCanvas).Y;
            Rectangle mouseRect = new Rectangle();
            for (int i = 0; i < mainCanvas.Children.Count; i++)
            {
                if (typeof(Rectangle) == (mainCanvas.Children[i].GetType()))
                {
                    double rectanglePocitionLeft = Canvas.GetLeft((Rectangle)mainCanvas.Children[i]);
                    double rectanglePocitionTop = Canvas.GetTop((Rectangle)mainCanvas.Children[i]);
                    double rectangleValueWidht = ((Rectangle)mainCanvas.Children[i]).Width;
                    double rectangleValueHeight = ((Rectangle)mainCanvas.Children[i]).Height;
                    bool bInsideByX = mouseX >= rectanglePocitionLeft && mouseX <= rectanglePocitionLeft + rectangleValueWidht;
                    bool bInsideByY = mouseY >= rectanglePocitionTop && mouseY <= rectanglePocitionTop + rectangleValueHeight;
                    
                    if (bInsideByX && bInsideByY)
                    {
                        mouseRect = (Rectangle)mainCanvas.Children[i];
                        IsHaveRectangle = true;
                    }
                }
            }
            if (IsHaveRectangle)
            {
                return mouseRect;
            }
            else
            {
                return null;
            }
         }

        private void Cvs_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (listLine.Count > 0)
            {
                if (listLine[listLine.Count - 1].isDrawing)
                {
                    listLine[listLine.Count - 1].RectangleTwo = returnRectangle(e);
                    if (returnRectangle(e) != null)
                    {
                        mainCanvas.MouseMove += listLine[listLine.Count - 1].reDrawingLine2;
                    }
                    listLine[listLine.Count - 1].isDrawing = false;
                }
            }
        }



    }
}