using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyScottSimulator
{
    public class SimulationManager
    {
        //Fields
        //Values held by SimulationManager
        private Grid cellGrid;
        private ILaplacianMachine machine;
        private CellBrush cellBrush;
        private double feedA;
        private double killB;

        //Constructor
        public SimulationManager(Graphics canvas, ILaplacianMachine machine, CellBrush brush, double feedA, double killB)
        {
            this.machine = machine;
            this.cellBrush = brush;
            this.feedA = feedA;
            this.killB = killB;

            //Creates a grid
            cellGrid = new Grid(canvas);
        }

        //Methods
        //Calculates next a and b
        //Updates con a and b
        //Updates brush
        //Draws to screen
        public void Run()
        {
            cellGrid.CalculateNextANextBAllCells(machine, feedA, killB);
            cellGrid.UpdateConAConBAllCells();
            cellGrid.UpdateBrushAllCells(cellBrush);
            cellGrid.DrawAllCells();
        }

        public void Run5000()
        {
            //Calculate next a and b, Update A and B, 5000 times
            for (int i = 0; i < 5000; i++)
            {
                cellGrid.CalculateNextANextBAllCells(machine, feedA, killB);
                cellGrid.UpdateConAConBAllCells();
            }

            //Updates brush colour, before during to the canvas
            cellGrid.UpdateBrushAllCells(cellBrush);
            cellGrid.DrawAllCells();
        }
    }
}
