using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyScottSimulator
{
    public class ShadingAlgorithmFactory : IShadingAlgorithmFactory
    {
        public IShadingAlgorithm CreateShadingAlgorithm(int colorCode)
        {
            IShadingAlgorithm newShadingAlgorithm = null;

            switch (colorCode)
            {
                case 0:
                    newShadingAlgorithm = new GrayScale();
                    break;
                case 1:
                    newShadingAlgorithm = new LongRainbow();
                    break;
                case 2:
                    newShadingAlgorithm = new YellowToRed();
                    break;
            }

            return newShadingAlgorithm;
        }
    }
}
