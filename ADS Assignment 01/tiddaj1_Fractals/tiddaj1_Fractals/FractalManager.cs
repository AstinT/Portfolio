using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tiddaj1_Fractals
{
    public class FractalManager
    {
        //Constants
        private const int PADDING = 50;
        private const int CIRCLE_SIZE = 500;
        private const int TREE_INITIAL_ANGLE = -90;
        private const int TREE_INITIAL_SIZE = 120;        
        private const int SNOWFLAKE_LINE_LENGTH = 600;
        private const int SNOWFLAKE_X = 325;
        private const int SNOWFLAKE_Y = 225;
        private const int EQUAL_TRI_ANG = 60;
        private const int GRAIN_LENGTH = 1100;
        private const int GRAIN_ANGLE = -35;

        //Fields
        private Graphics mainCanvas;
        private int panelWidth;
        private int panelHeight;

        //Constructor
        public FractalManager(Graphics mainCanvas, int panelWidth, int panelHeight)
        {
            this.mainCanvas = mainCanvas;
            this.panelWidth = panelWidth;
            this.panelHeight = panelHeight;
        }

        //Methods
        //Checks what enum is passed in and calls the matching Run method
        public void Run(int depth, EFractalValue val)
        {
            //Clear screen
            mainCanvas.Clear(Color.Gray);

            if (val == EFractalValue.SierpinskisTriangle)
                RunSier(depth);

            if (val == EFractalValue.Circle)
                RunCir(depth);

            if (val == EFractalValue.Tree)
                RunTree(depth);

            if (val == EFractalValue.KochSnowflake)
                RunKoch(depth);

            if (val == EFractalValue.Grain)
                RunGrain(depth);
        }

        //Run Sierpinskis triangle
        private void RunSier(int depth)
        {
            //New sierpinskisTriangle
            SierpinskisTriangle SierTri = new SierpinskisTriangle(mainCanvas);

            //Setup 3 points for initial triangle
            PointF p1 = new PointF(panelWidth / 2, PADDING);
            PointF p2 = new PointF(panelWidth - PADDING, panelHeight - PADDING);
            PointF p3 = new PointF(PADDING, panelHeight - PADDING);

            //Draw sierpinski triangle. Pass depth and 3 points for the initial triangle
            SierTri.drawSierpinski(depth, p1, p2, p3);
        }

        //Run Sierpinskis circles
        private void RunCir(int depth)
        {
            //New circle
            Circle circle = new Circle(mainCanvas);

            //Find middle for circle. Offset y by -100
            //Gross code to find middle point..........
            PointF middlePoint = new PointF((panelWidth / 2) - (CIRCLE_SIZE / 2), ((panelHeight / 2) - (CIRCLE_SIZE / 2)) - 100);

            //Draw circles. Pass depth, middle point and circle size
            circle.drawCircles(depth, middlePoint, CIRCLE_SIZE);
        }

        //Run Tree
        private void RunTree(int depth)
        {
            //New tree
            Tree tree = new Tree(mainCanvas);

            //Start point for tree
            PointF start = new PointF(panelWidth / 2, panelHeight - PADDING);

            //Draw tree. Pass depth, start point, initial tree angle and initial branch size
            tree.drawTree(depth, start, TREE_INITIAL_ANGLE, TREE_INITIAL_SIZE);
        }

        //Run Koch Snowflake
        private void RunKoch(int depth)
        {
            //New KochSnowflake
            KochSnowflake koch = new KochSnowflake(mainCanvas);

            //Setup 3 points for initial triangle
            PointF p1 = new PointF(SNOWFLAKE_X, SNOWFLAKE_Y);
            PointF p2 = new PointF(SNOWFLAKE_X + SNOWFLAKE_LINE_LENGTH, SNOWFLAKE_Y);
            PointF p3 = Mathmatics.findEndPoint(p1, EQUAL_TRI_ANG, SNOWFLAKE_LINE_LENGTH);

            //Draw SnowFlake. Pass depth and 3 points to draw triangle
            koch.drawSnowFlake(depth, p3, p2, p1);
        }

        //Run Grain
        private void RunGrain(int depth)
        {
            //New Grain
            Grain grain = new Grain(mainCanvas);

            //Starting point
            PointF start = new PointF(PADDING, panelHeight - PADDING);

            //Draw Grain.Pass depth, Grain length and an angle
            grain.drawGrain(depth, start, GRAIN_LENGTH, GRAIN_ANGLE);
        }
    }
}
