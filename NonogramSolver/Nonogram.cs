using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonogramSolver
{
    class Nonogram
    {
        private int RowCount;
        private int ColumnCount;
        //[row, column]
        private bool[,] PictureGrid;

        public Nonogram(int rowCount, int columnCount)
        {
            this.RowCount = rowCount;
            this.ColumnCount = columnCount;
            this.PictureGrid = new bool[rowCount, columnCount];
        }

        // Nested fillCoordinate() --- checks for input validity
        public void FillCoordinate(int row, int col)
        {
            if (row >= this.RowCount)
            {
                Console.WriteLine(String.Format("FillCoordinate: This puzzle has only {0} rows.\t{2} is used instead of given argument {1}", this.RowCount, row, this.RowCount - 1));
                row = this.RowCount - 1;
            }
            else if (row < 0)
            {
                Console.WriteLine(String.Format("FillCoordinate: Negative row number used.\tUsing 0 instead of given argument {0}", row));
                row = 0;
            }
            if (col >= this.ColumnCount)
            {
                Console.WriteLine(String.Format("FillCoordinate: This puzzle has only {0} columns.\t{2} is used instead of given argument {1}", this.ColumnCount, col, this.ColumnCount - 1));
                col = this.ColumnCount - 1;
            }
            else if (col < 0)
            {
                Console.WriteLine(String.Format("FillCoordinate: Negative column number used\tUsing 0 instead of given argument{0}", col));
                col = 0;
            }
            this._FillCoordinate(row, col);
        }
        private void _FillCoordinate(int row, int col)
        {
            this.PictureGrid[row, col] = true;
        }

        //Nested toggleCoordinate() --- checks for input valididy
        public void ToggleCoordinate(int row, int col)
        {
            if (row >= this.RowCount)
            {
                Console.WriteLine(String.Format("ToggleCoordinate: This puzzle has only {0} rows.\t{2} is used instead of given argument {1}", this.RowCount, row, this.RowCount - 1));
                row = this.RowCount - 1;
            }
            else if (row < 0)
            {
                Console.WriteLine(String.Format("ToggleCoordinate: Negative row number used.\tUsing 0 instead of given argument {0}", row));
                row = 0;
            }
            if (col >= this.ColumnCount)
            {
                Console.WriteLine(String.Format("ToggleCoordinate: This puzzle has only {0} columns.\t{2} is used instead of given argument {1}", this.ColumnCount, col, this.ColumnCount - 1));
                col = this.ColumnCount - 1;
            }
            else if (col < 0)
            {
                Console.WriteLine(String.Format("ToggleCoordinate: Negative column number used\tUsing 0 instead of given argument{0}", col));
                col = 0;
            }
            this._ToggleCoordinate(row, col);
        }
        private void _ToggleCoordinate(int row, int col)
        {
            this.PictureGrid[row, col] = !this.PictureGrid[row, col];
        }
        public void DisplayPicture(string[] rowFactors = null)
        {

            string formatString = "{0," + this.ColumnCount + "}  ";
            bool rowPrint = (rowFactors != null && rowFactors.Length == this.RowCount);

            if (!rowPrint)
            {
                Console.WriteLine("rowFactors doesn't match the number of rows");
            }

            // Upper border of the displayed picture
            Console.Write(String.Format(formatString, "")+" ");
            for (int col = 0; col < this.ColumnCount; col++)
            {
                Console.Write("__");
            }
            Console.Write("\n");

            // Contents of the displayed picture
            Console.OutputEncoding = Encoding.UTF8;
            for (int row = 0; row < this.RowCount; row++)
            {
                if (rowPrint)
                {
                    Console.Write(String.Format(formatString, rowFactors[row])+"|");
                }
                for (int col = 0; col < this.ColumnCount; col++)
                {
                    if (PictureGrid[row, col])
                    {
                        Console.Write("██");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }
                Console.Write("|\n");
            }

            // Bottom border of the displayed picture
            Console.Write(String.Format(formatString, "")+" ");
            for (int col = 0; col < this.ColumnCount; col++)
            {
                Console.Write("ㅡ");
            }
            Console.Write("\n");
        }
    }
}
