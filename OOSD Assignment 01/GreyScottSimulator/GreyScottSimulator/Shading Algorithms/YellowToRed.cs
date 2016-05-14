using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GreyScottSimulator
{
    public class YellowToRed : IShadingAlgorithm
    {
        public Color CalculateColor(double conB)
        {
            Color newColor = Color.Empty;

            //Yellow To Red
            double r = 0, g = 0, b = 0;

            double a = (1 - conB);
            double y = Math.Floor(255 * a);
            r = 255; g = y; b = 0;

            //Creates rgb
            newColor = Color.FromArgb((int)r, (int)g, (int)b);

            return newColor;
        }
    }
}
