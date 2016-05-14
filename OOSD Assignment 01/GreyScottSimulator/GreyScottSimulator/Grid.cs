using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyScottSimulator
{
    public class Grid
    {
        //Constants
        private const int GRID_SIZE = 128;
        private const int SEED_START = (GRID_SIZE / 4) - 1;
        private const int SEED_END = GRID_SIZE - SEED_START - 1;

        //Fields
        private Cell[,] cellsArray;

        //Constructor
        public Grid(Graphics canvas)
        {
            //Creates cells 2d array
            cellsArray = new Cell[GRID_SIZE, GRID_SIZE];
            //Creates all the cells
            CreateAllCells(canvas);
            //Sets all neightbours for each cell
            SetNeighboursAllCells();
            //Seeds a specific area
            Seed();
        }

        //Methods
        //Creates all cells
        private void CreateAllCells(Graphics canvas)
        {
            for (int i = 0; i < GRID_SIZE; i++)
            {
                for (int j = 0; j < GRID_SIZE; j++)
                {
                    //Creates cell
                    Cell newCell = new Cell(canvas);
                    //assigns to a location in 2d array
                    cellsArray[i, j] = newCell;
                }
            }
        }
        
        //Sets neighbours for all cells
        private void SetNeighboursAllCells()
        {
            int north, east, south, west;

            for (int i = 0; i < GRID_SIZE; i++)
            {
                for (int j = 0; j < GRID_SIZE; j++)
                {
                    //North
                    //If at the top of the grid
                    if (j == 0)
                    {
                        north = GRID_SIZE - 1;
                    }
                    else
                    {
                        north = j - 1;
                    }

                    //South
                    //If at the bottom of the grid
                    if (j == GRID_SIZE - 1)
                    {
                        south = 0;
                    }
                    else
                    {
                        south = j + 1;
                    }

                    //West
                    //If on the left of the grid
                    if (i == 0)
                    {
                        west = GRID_SIZE - 1;
                    }
                    else
                    {
                        west = i - 1;
                    }

                    //East
                    //If on the right of the grid
                    if (i == GRID_SIZE - 1)
                    {
                        east = 0;
                    }
                    else
                    {
                        east = i + 1;
                    }                    

                    //Assign all 8 neighbours to current cell
                    cellsArray[i, j].neighbours[0] = cellsArray[west, north]; //0
                    cellsArray[i, j].neighbours[1] = cellsArray[i, north]; //1
                    cellsArray[i, j].neighbours[2] = cellsArray[east, north]; //2
                    cellsArray[i, j].neighbours[3] = cellsArray[east, j]; //3
                    cellsArray[i, j].neighbours[4] = cellsArray[east, south]; //4
                    cellsArray[i, j].neighbours[5] = cellsArray[i, south]; //5
                    cellsArray[i, j].neighbours[6] = cellsArray[west, south]; //6
                    cellsArray[i, j].neighbours[7] = cellsArray[west, j]; //7
                }
            }
        }

        //Seed an area in the middle of the grid
        private void Seed()
        {
            for (int i = SEED_START; i < SEED_END; i++)
            {
                for (int j = SEED_START; j < SEED_END; j++)
                {
                    //A seeded cell starts with A = 0 and B = 1
                    cellsArray[i, j].conA = 0;
                    cellsArray[i, j].conB = 1;
                }
            }
        }

        //Calculate Next A and Next B values
        //Passed in a ILaplacianMachine object, feedA and killB
        public void CalculateNextANextBAllCells(ILaplacianMachine machine, double feedA, double killB)
        {
            for (int i = 0; i < GRID_SIZE; i++)
            {
                for (int j = 0; j < GRID_SIZE; j++)
                {
                    //Calls the CalculateNextConcentrations method on the current cell
                    //Gets passed the ILaplacianMachine object, feedA and killB
                    cellsArray[i, j].CalculateNextConcentraions(machine, feedA, killB);
                }
            }
        }

        //Updates all cells conA and conB, using UpdateA and UpdateB method
        public void UpdateConAConBAllCells()
        {
            for (int i = 0; i < GRID_SIZE; i++)
            {
                for (int j = 0; j < GRID_SIZE; j++)
                {
                    cellsArray[i, j].UpdateA();
                    cellsArray[i, j].UpdateB();
                }
            }
        }

        //Updates all cells brush, using the UpdateBrush method
        public void UpdateBrushAllCells(CellBrush brush)
        {
            for (int i = 0; i < GRID_SIZE; i++)
            {
                for (int j = 0; j < GRID_SIZE; j++)
                {
                    cellsArray[i, j].UpdateBrush(brush);
                }
            }
        }

        //Draw all cells to canvas
        //Passed the i and j location
        public void DrawAllCells()
        {
            for (int i = 0; i < GRID_SIZE; i++)
            {
                for (int j = 0; j < GRID_SIZE; j++)
                {
                    cellsArray[i, j].Draw(i, j);
                }
            }
        }
    }
}
