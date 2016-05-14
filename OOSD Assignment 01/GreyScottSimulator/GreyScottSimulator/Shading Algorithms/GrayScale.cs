using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GreyScottSimulator
{
    public class GrayScale : IShadingAlgorithm
    {
        public Color CalculateColor(double conB)
        {
            Color newColor = Color.Empty;

            //GreyScale
            double x = conB * 255;
            double g = Math.Floor(x);

            //Creates rgb
            newColor = Color.FromArgb((int)g, (int)g, (int)g);

            return newColor;
        }
    }
}
