using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GreyScottSimulator
{
    public class LongRainbow : IShadingAlgorithm
    {
        public Color CalculateColor(double conB)
        {
            Color newColor = Color.Empty;

            //Long Rainbow
            double r = 0, g = 0, b = 0;
            double a = (1 - conB) / 0.2;
            int x = Convert.ToInt32(Math.Floor(a));
            double y = Math.Floor(255 * (a - x));

            switch (x)
            {
                case 0: r = 255; g = y; b = 0; break;
                case 1: r = 255 - y; g = 255; b = 0; break;
                case 2: r = 0; g = 255; b = y; break;
                case 3: r = 0; g = 255 - y; b = 255; break;
                case 4: r = y; g = 0; b = 255; break;
                case 5: r = 255; g = 0; b = 255; break;
            }

            //Creates rgb
            newColor = Color.FromArgb((int)r, (int)g, (int)b);

            return newColor;
        }
    }
}
