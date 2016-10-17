using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace tiddaj1_Fractals
{
    public class Tree
    {
        //Fields
        private Graphics mainCanvas;
        private Pen pen;

        //Constructor
        public Tree(Graphics mainCanvas)
        {
            this.mainCanvas = mainCanvas;

            Brush brush = new SolidBrush(Color.GreenYellow);
            pen = new Pen(brush);
        }

        //Methods
        public void drawTree(int depth, PointF start, double angle, int lineLength)
        {
            //Base case
            if (depth == 0)
            {
                //Find end to draw to
                PointF end = Mathmatics.findEndPoint(start, angle, lineLength);
                drawLine(start, end);
            }
            else
            {
                //Find end to draw to
                PointF end = Mathmatics.findEndPoint(start, angle, lineLength);
                drawLine(start, end);

                //Recursion here...
                //Pass depth - 1, end will become new start, change angle and make line length smaller
                drawTree(depth - 1, end, angle - 20, lineLength - 10);
                drawTree(depth - 1, end, angle + 20, lineLength - 10);   
            }              
        }

        //Draw line method
        public void drawLine(PointF start, PointF end)
        {
            mainCanvas.DrawLine(pen, start, end);
        }
    }
}
