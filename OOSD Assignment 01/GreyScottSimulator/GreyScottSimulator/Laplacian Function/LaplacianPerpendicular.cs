using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyScottSimulator
{
    public class LaplacianPerpendicular : ILaplacianMachine
    {
        //Constants
        private const double H = 2.5 / 127.0;
        private const double RH = 1.0 / H / H;
        private const double DIFF_A = 0.00002;
        private const double DIFF_B = 0.00001;

        //Constructor
        public LaplacianPerpendicular()
        {
            //Nothing here...
        }
        
        //Methods
        //Calculates perpendicular laplacian value
        //Passed in bool usingA, current cell con x and current cell neighbours
        public double Calculate(bool usingA, double x, Cell[] neighbours)
        {            
            double laplacianVal = 0;
            double sumNeighbours = 0;

            //Loops through array getting all perpendicular neighbours conA or conB and sums
            //Depending on usingA flag
            for (int i = 1; i < neighbours.Length; i+=2)
			{
                if(usingA == true)
                {
                    sumNeighbours += neighbours[i].conA;
                }
                else
                {
                    sumNeighbours += neighbours[i].conB;
                }
			}

            //Calculates laplacian value
            laplacianVal = RH * (sumNeighbours - (4 * x));

            return laplacianVal;
        }

        //Return DIFF_A constant
        public double GetDiffA()
        {
            return DIFF_A;
        }

        //Return DIFF_B constant
        public double GetDiffB()
        {
            return DIFF_B;
        }
    }
}
