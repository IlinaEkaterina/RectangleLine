﻿using System;
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
        int stateLine;

        enum EStates : byte { LineOne = 1, LineTwo = 2, LineTree = 3 };

        private void btnRectOne_Click(object sender, RoutedEventArgs e)
        {
           myRectangleOne myRectangle = new myRectangleOne();
           myRectangle.myCvs = this.Cvs;
           Cvs.Children.Add(myRectangle.myRect);            
        }

        private void btnRectTwo_Click(object sender, RoutedEventArgs e)
        {
            myRectangleTwo myRectangle = new myRectangleTwo();
            myRectangle.myCvs = this.Cvs;
            Cvs.Children.Add(myRectangle.myRect);
        }

        void changeStateLineRectangle()
        {
            IsDrawLine = true;
            myRectangle.IsRectState = false;
        }

        

        private void btnLine_Click(object sender, RoutedEventArgs e)
        {
            stateLine = (int)EStates.LineOne;
            changeStateLineRectangle();
        }
        private void btnLine2_Click(object sender, RoutedEventArgs e)
        {
            stateLine = (int)EStates.LineTwo;
            changeStateLineRectangle();
        }

        private void btnLine3_Click(object sender, RoutedEventArgs e)
        {
            stateLine = (int)EStates.LineTree;
            changeStateLineRectangle();
        }
       

        private void Cvs_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (IsDrawLine)
            {
                myLine myL=null;

                switch (stateLine)                
                { 
                    case 1: 
                        myL = new myLineOne();
                        break;
                    case 2: 
                        myL = new myLineTwo();
                        break;

                    default:
                        myL = new myLineTree();
                        break;
                }

                myL.RectOne = returnRectangle(e);
                Cvs.MouseMove += myL.onMouseMove;
                if (returnRectangle(e) != null)
                {
                    Cvs.MouseMove += myL.reDrawingLine1;
                }
                myL.myCvs = this.Cvs;
                myL.onMouseDown(sender, e);
                Cvs.Children.Add(myL.line);
                listLine.Add(myL);
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
            double mouseX = e.GetPosition(Cvs).X;
            double mouseY = e.GetPosition(Cvs).Y;
            Rectangle mouseRect = new Rectangle();
            for (int i = 0; i < Cvs.Children.Count; i++)
            {
                if (typeof(Rectangle) == (Cvs.Children[i].GetType()))
                {
                    double rLeft = Canvas.GetLeft((Rectangle)Cvs.Children[i]);
                    double rTop = Canvas.GetTop((Rectangle)Cvs.Children[i]);
                    double rWidht = ((Rectangle)Cvs.Children[i]).Width;
                    double rHeight = ((Rectangle)Cvs.Children[i]).Height;
                    bool bInsideByX = mouseX >= rLeft && mouseX <= rLeft + rWidht;
                    bool bInsideByY = mouseY >= rTop && mouseY <= rTop + rHeight;
                    
                    if (bInsideByX && bInsideByY)
                    {
                        mouseRect = (Rectangle)Cvs.Children[i];
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
                    listLine[listLine.Count - 1].RectTwo = returnRectangle(e);
                    if (returnRectangle(e) != null)
                    {
                        Cvs.MouseMove += listLine[listLine.Count - 1].reDrawingLine2;
                    }
                    listLine[listLine.Count - 1].isDrawing = false;
                }
            }
        }



    }
}