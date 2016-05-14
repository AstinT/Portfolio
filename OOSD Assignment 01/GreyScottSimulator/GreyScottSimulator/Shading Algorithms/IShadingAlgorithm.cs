using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GreyScottSimulator
{
    public interface IShadingAlgorithm
    {
        //Calculates a color with concentration B. Returns a Color
        Color CalculateColor(double conB);
    }
}
