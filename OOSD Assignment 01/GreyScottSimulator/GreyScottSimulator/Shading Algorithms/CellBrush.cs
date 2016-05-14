using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyScottSimulator
{
    public class CellBrush
    {
        //Fields
        private int colorCode;
        private IShadingAlgorithmFactory factory;

        //Constructor
        public CellBrush(int colorCode)
        {
            this.colorCode = colorCode;
            //Creates new ShadingAlgorithmFactory
            factory = new ShadingAlgorithmFactory();
        }

        //Method
        //Creates a new brush and returns it
        public SolidBrush CreateBrush(double conB)
        {
            SolidBrush newBrush = null;
            Color newColor = Color.Empty;

            //factory creates a shading algorithm depending on what the colorCode is
            IShadingAlgorithm newShadingAlgorithm = factory.CreateShadingAlgorithm(colorCode);
            
            //calls the CalculateColor, passes in conB and returns a color
            newColor = newShadingAlgorithm.CalculateColor(conB);
            //Creates a new brush with color
            newBrush = new SolidBrush(newColor);

            return newBrush;
        }
    }
}
