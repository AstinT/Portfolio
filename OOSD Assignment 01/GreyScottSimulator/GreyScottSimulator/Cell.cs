using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyScottSimulator
{
    public class Cell
    {
        //Constants
        private const int CELL_SIZE = 4; //Pixels
        private const int MAX_NEIGHBOURS = 8;
        private const double CON_A_INITIAL = 1;
        private const double CON_B_INITIAL = 0;

        //Fields
        private Graphics canvas;
        private SolidBrush brush;              

        //Properties
        public double conA { get; set; }
        public double conB { get; set; }
        public double nextA { get; set; }
        public double nextB { get; set; }
        public Cell[] neighbours { get; set; }

        //Constructor
        public Cell(Graphics canvas)
        {
            this.canvas = canvas;            
            conA = CON_A_INITIAL;
            conB = CON_B_INITIAL;
            nextA = 0;
            nextB = 0;
            neighbours = new Cell[MAX_NEIGHBOURS];
            brush = new SolidBrush(Color.Empty); //null
        }

        //Methods
        public void Draw(int i, int j)
        {
            //Cell draws itself to the canvas
            canvas.FillRectangle(brush, (i * CELL_SIZE), (j * CELL_SIZE), CELL_SIZE, CELL_SIZE);
        }

        //Calls CalculateNextA and CalculateNextB method
        public void CalculateNextConcentraions(ILaplacianMachine machine, double feedA, double killB)
        {
            nextA = CalculateNextA(machine, feedA);
            nextB = CalculateNextB(machine, feedA, killB);
        }

        //Calculates nextA and returns it
        private double CalculateNextA(ILaplacianMachine machine, double feedA)
        {
            double newA = 0;
            bool usingA = true;
            //Gets diffA from passed in ILaplacianMachine object
            double diffA = machine.GetDiffA();
            //Calls Calculate method, returns new laplacian value
            double laplacianVal = machine.Calculate(usingA, conA, neighbours);

            double partOne = diffA * laplacianVal;
            double partTwo = conA * (conB * conB);
            double partThree = feedA * (1 - conA);

            newA = conA + partOne - partTwo + partThree;

            //Checks if newA is between 0 and 1
            if (newA > 1)
                newA = 1;

            if (newA < 0)
                newA = 0;

            return newA;
        }

        //Calculates nextB and returns it
        private double CalculateNextB(ILaplacianMachine machine, double feedA, double killB)
        {
            double newB = 0;
            bool usingA = false;
            //Gets diffB from passed in ILaplacianMachine object
            double diffB = machine.GetDiffB();
            ////Calls Calculate method, returns new laplacian value
            double laplacianVal = machine.Calculate(usingA, conB, neighbours);            

            double partOne = diffB * laplacianVal;
            double partTwo = conA * (conB * conB);
            double partThree = (killB + feedA) * conB;

            newB = conB + partOne + partTwo - partThree;

            //Checks if newB is between 0 and 1
            if (newB > 1)
                newB = 1;

            if (newB < 0)
                newB = 0;

            return newB;
        }

        //Sets conA to be equal to nextA
        public void UpdateA()
        {
            conA = nextA;
        }

        //Sets conB to be equal to nextB
        public void UpdateB()
        {
            conB = nextB;
        }
  
        //CellBrush object passed in
        //Calls CreateBrush method, returns a new brush
        public void UpdateBrush(CellBrush cellBrush)
        {
            brush = cellBrush.CreateBrush(conB);
        }
    }
}
