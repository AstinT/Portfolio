using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyScottSimulator
{
    public class LaplacianDeltaMeans : ILaplacianMachine
    {
        //Constants
        private const double DIFF_A = 1;
        private const double DIFF_B = 0.5;

        public LaplacianDeltaMeans()
        {
            //Nothing here...
        }

        //Methods
        //Calculates Delta Means laplacian value
        //Passed in bool usingA, current cell con x and current cell neighbours
        public double Calculate(bool usingA, double x, Cell[] neighbours)
        {
            double laplacianVal = 0;
            double sumNeighbours = 0;
            double avSumNeighbours = 0;
            double difference = 0;

            //Loops over neighbours array summing conA or conB,
            //Depending on usingA flag
            for (int i = 0; i < neighbours.Length; i++)
            {
                if (usingA == true)
                {
                    sumNeighbours += neighbours[i].conA;
                }
                else
                {
                    sumNeighbours += neighbours[i].conB;
                }
            }

            //Calculates average
            avSumNeighbours = sumNeighbours / neighbours.Length;

            //Calculates difference
            difference = avSumNeighbours - x;
            laplacianVal = difference;

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
