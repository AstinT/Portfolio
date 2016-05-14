using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GreyScottSimulator
{
    public interface IShadingAlgorithmFactory
    {
        //Creates a shading algorithm depending on what color code is passed in.
        IShadingAlgorithm CreateShadingAlgorithm(int colorCode);
    }
}
