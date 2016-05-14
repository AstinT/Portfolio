using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyScottSimulator
{
    public class LaplacianConvolution : ILaplacianMachine
    {
        //Constants
        private const double DIAGONAL = 0.05;
        private const double PERPENDICULAR = 0.2;
        private const double CELL = -1;
        private const double DIFF_A = 1;
        private const double DIFF_B = 0.5;

        //Constructor
        public LaplacianConvolution()
        {
            //Nothing here...
        }

        //Methods
        //Calculates convolution laplacian value
        //Passed in bool usingA, current cell con x and current cell neighbours
        public double Calculate(bool usingA, double x, Cell[] neighbours)
        {
            double laplacianVal = 0;
            double sumAllResults = 0;
            double[] constants = { DIAGONAL, PERPENDICULAR, DIAGONAL, PERPENDICULAR,
                                 DIAGONAL, PERPENDICULAR, DIAGONAL, PERPENDICULAR};

            //Loops over neighbours array, multipling conA by the matching constant held in the constants array
            //Sums them all up
            for (int i = 0; i < neighbours.Length; i++)
            {
                if (usingA == true)
                {
                    sumAllResults += neighbours[i].conA * constants[i];
                }
                else
                {
                    sumAllResults += neighbours[i].conB * constants[i];
                }
            }

            sumAllResults += x * CELL;
            laplacianVal = sumAllResults;

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
