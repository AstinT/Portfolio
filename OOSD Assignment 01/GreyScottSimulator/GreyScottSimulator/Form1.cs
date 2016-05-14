using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreyScottSimulator
{
    public partial class Form1 : Form
    {
        //Constants
        private const int GRAYSCALE_CODE = 0;
        private const int LONG_RAINBOW_CODE = 1;
        private const int YELLOW_TO_RED = 2;
        private const int AUTO_START = 20;
        private const int AUTO_END = 80;
        private const double CONVERT = 1000;

        //Fields
        private SimulationManager simulation;
        private Graphics mainCanvas;
        private Graphics bufferCanvas;
        private Bitmap buffer;
        private String lapFileName;
        private String colFileName;

        //Simulation Parameters
        private ILaplacianMachine laplacianMachine;
        private CellBrush cellBrush;
        private double feedA;
        private double killB;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Create graphics object;
            mainCanvas = CreateGraphics();

            //Sets bitmap size for bufferCanvase
            buffer = new Bitmap(128 * 4, 128 * 4);
            //bufferCanvas used for saving image to file
            bufferCanvas = Graphics.FromImage(buffer);          

            //Initializing
            laplacianMachine = null;
            cellBrush = null;
            feedA = 0.0;
            killB = 0.0;
            lapFileName = "";
            colFileName = "";
        }

        //Timer tick
        private void timer_Tick(object sender, EventArgs e)
        {
            //Calls run method at each tick.
            simulation.Run();
        }

        //Gets all Simulation Parameters
        private void GetSimParams()
        {
            //Gets laplacian and cellBrush
            laplacianMachine = GetLaplacianFunction();
            cellBrush = GetCellBrush();
            
            //Try convert textbox string to double
            try
            {
                feedA = Double.Parse(tbFeedA.Text);
                killB = Double.Parse(tbKillB.Text);   
            }
            catch (FormatException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //Checks if simulation parameters have been set
        private bool CheckSimParams()
        {
            if((laplacianMachine != null) && (cellBrush != null)
                && (feedA != 0.0) && (killB != 0.0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Starts a single simulation and draws to the screen
        private void btnStart_Click(object sender, EventArgs e)
        {
            GetSimParams();

            if (CheckSimParams())
            {
                //New simulation
                simulation = new SimulationManager(mainCanvas, laplacianMachine, cellBrush, feedA, killB);
                //Enables timer
                timer.Enabled = true;
            }
            //If parameters haven't been set
            else
                MessageBox.Show("Please enter only numbers and select a laplacian function and a color.");
        }

        //Starts a single simulation but draws to the bufferCanvas to save to file
        private void btn5000Steps_Click(object sender, EventArgs e)
        {
            GetSimParams();

            if (CheckSimParams())
            {
                //New simulation
                simulation = new SimulationManager(bufferCanvas, laplacianMachine, cellBrush, feedA, killB);
                //Runs simulation for 5000 steps
                simulation.Run5000();
                
                //Constucts file name and saves
                String filename = feedA.ToString() + "_" + killB.ToString() + "_" + lapFileName + "_" + colFileName + ".jpg";
                buffer.Save(filename);
            }
            //If parameters haven't been set
            else
                MessageBox.Show("Please enter only numbers and select a laplacian function and a color.");
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            //Gets selected laplacian and colour
            laplacianMachine = GetLaplacianFunction();
            cellBrush = GetCellBrush();

            //Checks if they have been set
            if ((laplacianMachine != null) && (cellBrush != null))
            {
                //Increments feedA
                for (int i = AUTO_START; i < AUTO_END; i++)
                {
                    //Converts i to a double feedA
                    feedA = i / CONVERT;

                    //Increments killB
                    for (int j = AUTO_START; j < AUTO_END; j++)
                    {
                        //Converts J to a double killB
                        killB = j / CONVERT;
                        
                        //New simulation
                        simulation = new SimulationManager(bufferCanvas, laplacianMachine, cellBrush, feedA, killB);
                        //Runs 5000 times
                        simulation.Run5000();

                        //Constucts file name and saves
                        String filename = feedA.ToString() + "_" + killB.ToString() + "_" + lapFileName + "_" + colFileName + ".jpg";
                        buffer.Save(filename);

                        //Starts over...
                    }
                }
            }
            else
                //If parameters haven't been set
                //feedA and killB don't need to be set
                MessageBox.Show("Please select a laplacian function and a color.");
        }

        //Returns the selected Laplacian Function depending on what radio button is selected.
        //Also sets a String variable lapFileName so it can be use when image is saved.
        public ILaplacianMachine GetLaplacianFunction()
        {
            ILaplacianMachine machine;

            if (rbPerpendicular.Checked)
            {
                machine = new LaplacianPerpendicular();
                lapFileName = "per";
            }
            else if (rbConvolution.Checked)
            {
                machine = new LaplacianConvolution();
                lapFileName = "con";
            }
            else if (rbDeltaMeans.Checked)
            {
                machine = new LaplacianDeltaMeans();
                lapFileName = "del";
            }
            else
            {
                machine = null;
            }

            return machine;
        }

        //Returns the selected cellBrush depending on what radio button is selected.
        //Also sets a String variable colFileName so it can be use when image is saved.
        //When CellBrush is created pass it a color code so factory knows what one to use.
        public CellBrush GetCellBrush()
        {
            CellBrush cellBrush;

            if (rbGrayScale.Checked)
            {
                cellBrush = new CellBrush(GRAYSCALE_CODE);
                colFileName = "gray";
            }
            else if (rbLongRainbow.Checked)
            {
                cellBrush = new CellBrush(LONG_RAINBOW_CODE);
                colFileName = "rain";
            }
            else if (rbYellowToRed.Checked)
            {
                cellBrush = new CellBrush(YELLOW_TO_RED);
                colFileName = "yell";
            }
            else
            {
                cellBrush = null;
            }

            return cellBrush;
        }        
    }
}
