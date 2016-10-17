using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace tiddaj1_Fractals
{
    public class KochSnowflake
    {
        //Constants
        private const int THIRD = 3;

        //Fields
        private Graphics mainCanvas;
        private Pen pen;

        //Constructor
        public KochSnowflake(Graphics mainCanvas)
        {
            this.mainCanvas = mainCanvas;

            Brush brush = new SolidBrush(Color.White);
            pen = new Pen(brush);
        }

        //Methods
        //Call drawCurve three times to make triangle
        public void drawSnowFlake(int depth, PointF p1, PointF p2, PointF p3)
        {
            //Pass depth, start point, end point and an angle
            drawCurve(depth, p1, p2, 60);
            drawCurve(depth, p2, p3, -60);
            drawCurve(depth, p3, p1, -180);
        }

        public void drawCurve(int depth, PointF start, PointF end, float angle)
        {
            //Base case
            if (depth == 0)
            {
                drawLine(start, end);
            }
            else
            {
                //Calculate line length
                float lineLength = Mathmatics.calcDistBetweenPoints(start, end);
                
                //Calculate line segment length. Split into thirds.
                float lineSegLength = (int)lineLength / THIRD;

                //Calculate new p1
                float newP1X = ((end.X - start.X) / THIRD) + start.X;
                float newP1Y = ((end.Y - start.Y) / THIRD) + start.Y;

                //Calculate new p2
                float newP3X = ((end.X - start.X) / THIRD * 2) + start.X;
                float newP3Y = ((end.Y - start.Y) / THIRD * 2) + start.Y;

                PointF newP1 = new PointF(newP1X, newP1Y);
                PointF newP3 = new PointF(newP3X, newP3Y);
                
                //Find top point
                PointF newP2 = Mathmatics.findEndPoint(newP1, angle - 60, lineSegLength);

                //Recursion here...
                drawCurve(depth - 1, start, newP1, angle);
                drawCurve(depth - 1, newP1, newP2, angle + 60);
                drawCurve(depth - 1, newP2, newP3, angle - 60);
                drawCurve(depth - 1, newP3, end, angle);
            }
        }

        //Draw line method
        public void drawLine(PointF start, PointF end)
        {
            mainCanvas.DrawLine(pen, start, end);
        }
    }
}
