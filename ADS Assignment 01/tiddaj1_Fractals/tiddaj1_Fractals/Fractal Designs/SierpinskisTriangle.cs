using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace tiddaj1_Fractals
{
    public class SierpinskisTriangle
    {
        //Fields
        private Graphics mainCanvas;
        private Pen pen;

        //Constructor
        public SierpinskisTriangle(Graphics mainCanvas)
        {
            this.mainCanvas = mainCanvas;

            Brush brush = new SolidBrush(Color.Blue);
            pen = new Pen(brush);
        }

        //Methods
        public void drawSierpinski(int depth, PointF p1, PointF p2, PointF p3)
        {
            //Base case
            if (depth == 0)
            {
                //Draw triangle
                drawTriangle(p1, p2, p3);
            }
            else
            {
                //Calculating new points for new triangles
                PointF newP1 = Mathmatics.findMidPoint(p1, p3);
                PointF newP2 = Mathmatics.findMidPoint(p1, p2);
                PointF newP3 = Mathmatics.findMidPoint(p2, p3);

                //Recursion here...
                drawSierpinski(depth - 1, p1, newP2, newP1);     //1
                drawSierpinski(depth - 1, newP1, newP3, p3);     //2
                drawSierpinski(depth - 1, newP2, p2, newP3);     //3
            }
        }

        //Draws triangle from 3 points
        private void drawTriangle(PointF p1, PointF p2, PointF p3)
        {
            PointF[] points = new PointF[] {p1, p2, p3};
            mainCanvas.DrawPolygon(pen, points);
        }
    }
}
