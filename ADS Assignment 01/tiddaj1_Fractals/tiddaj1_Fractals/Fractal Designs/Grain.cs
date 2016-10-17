using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace tiddaj1_Fractals
{
    public class Grain
    {
        //Constants
        private const int BRANCH_NUM = 12;

        //Fields
        private Graphics mainCanvas;
        private Pen pen;

        //Constructor
        public Grain(Graphics mainCanvas)
        {
            this.mainCanvas = mainCanvas;

            Brush brush = new SolidBrush(Color.Wheat);
            pen = new Pen(brush);
        }

        //Methods
        public void drawGrain(int depth, PointF start, float length, float angle)
        {
            //Base case
            if(depth == 0)
            {
                //Find new point to draw too
                PointF end = Mathmatics.findEndPoint(start, angle, length);
                drawLine(start, end);
            }
            else
            {
                //Find new point to draw too
                PointF end = Mathmatics.findEndPoint(start, angle, length);
                drawLine(start, end);

                //Calculate segement size
                float lineSeg = length / BRANCH_NUM;

                //Loop over branch num
                for (int i = 2; i <= BRANCH_NUM; i++)
                {
                    PointF newPoint = Mathmatics.findEndPoint(start, angle, lineSeg * i);

                    //Recursion here...
                    drawGrain(depth - 1, newPoint, length / BRANCH_NUM, angle + 45);
                    drawGrain(depth - 1, newPoint, length / BRANCH_NUM, angle - 45);
                }                
            }
        }

        //Draw line method
        public void drawLine(PointF start, PointF end)
        {
            mainCanvas.DrawLine(pen, start, end);
        }
    }
}
