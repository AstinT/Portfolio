using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tiddaj1_Fractals
{
    public partial class Form1 : Form
    {
        //Fields
        private Graphics mainCanvas;
        private FractalManager fm;

        //Constructor
        public Form1()
        {
            InitializeComponent();
        }

        //Form load event
        private void Form1_Load(object sender, EventArgs e)
        {
            //Creates graphics using the panel
            mainCanvas = panel.CreateGraphics();

            //Adds anti aliasing to graphics object
            mainCanvas.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            //Creates new Fractal Manager, passing it the graphics object and the panel dimensions
            fm = new FractalManager(mainCanvas, panel.Width, panel.Height);
        }

        //Get depth from input textbox and return it.
        private int getDepth()
        {
            return Convert.ToInt32(tbDepth.Text.ToString());
        }

        //Returns an enum depending on what radio button is selected
        private EFractalValue getSelectedFractal()
        {
            EFractalValue val = EFractalValue.None;

            if (rbSierTri.Checked)
                val = EFractalValue.SierpinskisTriangle;

            if (rbCircles.Checked)
                val = EFractalValue.Circle;

            if (rbTree.Checked)
                val = EFractalValue.Tree;

            if (rbKochSnowflake.Checked)
                val = EFractalValue.KochSnowflake;

            if (rbGrain.Checked)
                val = EFractalValue.Grain;

            return val;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            //Get depth
            int depth = getDepth();

            //Get selected fractal design
            EFractalValue val = getSelectedFractal();

            //Call run passing depth and enum of selected fractal design
            fm.Run(depth, val);
        }
    }
}
