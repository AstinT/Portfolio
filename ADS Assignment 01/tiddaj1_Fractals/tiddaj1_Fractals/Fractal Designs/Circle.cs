using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace tiddaj1_Fractals
{
    public class Circle
    {
        //Fields
        private Graphics mainCanvas;
        private Pen pen;

        //Constuctor
        public Circle(Graphics mainCanvas)
        {
            this.mainCanvas = mainCanvas;

            Brush brush = new SolidBrush(Color.Orange);
            pen = new Pen(brush);
        }

        //Method
        public void drawCircles(int depth, PointF location, int size)
        {
            //Base case
            if (depth == 0)
            {
                //Draw circle
                drawCircle(location, size);
            }
            else
            {
                //Draw circle
                drawCircle(location, size);

                //Find new location for right, left and down
                PointF newLocationRight = new PointF(location.X + size / 2 + size / 4, location.Y + size / 4);
                PointF newLocationLeft = new PointF(location.X - size / 2 + size / 4, location.Y + size / 4);
                PointF newLocationDown = new PointF(location.X + size / 4, location.Y + size / 2 + size / 4);

                //Recursion here...
                //Pass depth minus 1, new location and size by half
                drawCircles(depth - 1, newLocationRight, size / 2);                
                drawCircles(depth - 1, newLocationLeft, size / 2);                
                drawCircles(depth - 1, newLocationDown, size / 2);

                //Uncomment this to make a diamond shape
                //Point newLocationUp = new Point(location.X + size / 4, location.Y - size / 2 + size / 4);
                //start(depth - 1, newLocationUp, size / 2);
            }
        }

        //Draw circle method
        private void drawCircle(PointF location, int size)
        {
            mainCanvas.DrawEllipse(pen, location.X, location.Y, size, size);
        }
    }
}
