using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace tiddaj1_Fractals
{
    public static class Mathmatics
    {
        //Constant
        private const double DEG_TO_RAD = Math.PI / 180;

        //Methods
        //Finds mid point between 2 points
        //Returns the new mid point
        public static PointF findMidPoint(PointF p1, PointF p2)
        {
            float newX = (p1.X + p2.X) / 2;
            float newY = (p1.Y + p2.Y) / 2;

            return new PointF(newX, newY);
        }

        //Finds a point given a start, angle and line length
        public static PointF findEndPoint(PointF start, double angle, float lineLength)
        {
            float xDelta = (float)(Math.Cos(angle * DEG_TO_RAD) * lineLength);
            float yDelta = (float)(Math.Sin(angle * DEG_TO_RAD) * lineLength);

            float endX = start.X + xDelta;
            float endY = start.Y + yDelta;

            return new PointF(endX, endY);
        }

        //Calculates the distance between 2 points
        public static float calcDistBetweenPoints(PointF start, PointF end)
        {
            float x = start.X - end.X;
            float y = start.Y - end.Y;

            return (float)Math.Sqrt((x * x) + (y * y));
        }
    }
}
