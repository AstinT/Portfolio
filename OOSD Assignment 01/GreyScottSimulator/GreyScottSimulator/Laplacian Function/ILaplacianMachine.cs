using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreyScottSimulator
{
    public interface ILaplacianMachine
    {
        double Calculate(bool usingA, double x, Cell[] neighbours);
        //Gets diffA
        double GetDiffA();
        //Gets diffB
        double GetDiffB();
    }
}
