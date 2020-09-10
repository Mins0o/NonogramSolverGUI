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
        private int[] shape;
        //[row, column]
        private bool[,,] PictureGrid;

        public int[] Shape
        {
            get => shape;
            set => shape = value;
        }

        public Nonogram(int rowCount, int columnCount)
        {
            this.RowCount = rowCount;
            this.ColumnCount = columnCount;
            // PictureGrid[,,0] is confirmed or not,
            // PictureGrid[,,1] is filled or not
            this.PictureGrid = new bool[rowCount, columnCount, 2];
            this.Shape = new int[2] { rowCount, columnCount };
        }

        private void _FillCoordinate(int row, int col)
        {
            this.PictureGrid[row, col, 1] = true;
        }
        // Wrapped _FillCoordinate() --- checks for input validity
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

        private void _ToggleFill(int row, int col)
        {
            this.PictureGrid[row, col,1] = !this.PictureGrid[row, col,1];
        }
        // Wrapped _ToggleCoordinate() --- checks for input validity
        public void ToggleFill(int row, int col)
        {
            if (row >= this.RowCount)
            {
                Console.WriteLine(String.Format("ToggleFill: This puzzle has only {0} rows.\t{2} is used instead of given argument {1}", this.RowCount, row, this.RowCount - 1));
                row = this.RowCount - 1;
            }
            else if (row < 0)
            {
                Console.WriteLine(String.Format("ToggleFill: Negative row number used.\tUsing 0 instead of given argument {0}", row));
                row = 0;
            }
            if (col >= this.ColumnCount)
            {
                Console.WriteLine(String.Format("ToggleFill: This puzzle has only {0} columns.\t{2} is used instead of given argument {1}", this.ColumnCount, col, this.ColumnCount - 1));
                col = this.ColumnCount - 1;
            }
            else if (col < 0)
            {
                Console.WriteLine(String.Format("ToggleFill: Negative column number used\tUsing 0 instead of given argument{0}", col));
                col = 0;
            }
            this._ToggleFill(row, col);
        }

        private bool[] _Lookup(int row, int col)
        {
            return new bool[] { this.PictureGrid[row, col, 0], this.PictureGrid[row, col, 1]};
        }
        // Wrapped _Lookup() --- checks for input validity
        public bool[] Lookup(int row, int col)
        {
            if (row >= this.RowCount)
            {
                Console.WriteLine(String.Format("Lookup: This puzzle has only {0} rows.\t{2} is used instead of given argument {1}", this.RowCount, row, this.RowCount - 1));
                row = this.RowCount - 1;
            }
            else if (row < 0)
            {
                Console.WriteLine(String.Format("Lookup: Negative row number used.\tUsing 0 instead of given argument {0}", row));
                row = 0;
            }
            if (col >= this.ColumnCount)
            {
                Console.WriteLine(String.Format("Lookup: This puzzle has only {0} columns.\t{2} is used instead of given argument {1}", this.ColumnCount, col, this.ColumnCount - 1));
                col = this.ColumnCount - 1;
            }
            else if (col < 0)
            {
                Console.WriteLine(String.Format("Lookup: Negative column number used\tUsing 0 instead of given argument{0}", col));
                col = 0;
            }
            return _Lookup(row, col);

        }

        private bool[][] _RowLookup(int row)
        {
            bool[][] returnArray = new bool[this.ColumnCount][];
            for (int col = 0; col < this.ColumnCount; col++)
            {
                returnArray[col] = new bool[] { this.PictureGrid[row, col, 0], this.PictureGrid[row, col, 1] };
            }
            return returnArray;
        }
        // Wrapped _RowLookup() --- checks for input validity
        public bool[][] RowLookup(int row)
        {
            if (row >= this.RowCount)
            {
                Console.WriteLine(String.Format("RowLookup: This puzzle has only {0} rows.\t{2} is used instead of given argument {1}", this.RowCount, row, this.RowCount - 1));
                row = this.RowCount - 1;
            }
            else if (row < 0)
            {
                Console.WriteLine(String.Format("RowLookup: Negative row number used.\tUsing 0 instead of given argument {0}", row));
                row = 0;
            }
            return _RowLookup(row);
        }

        private bool[][] _ColLookup(int col)
        {
            bool[][] returnArray = new bool[this.RowCount][];
            for (int row = 0; row < this.RowCount; row++)
            {
                returnArray[row] = new bool[] { this.PictureGrid[row, col, 0], this.PictureGrid[row, col, 1] };
            }
            return returnArray;
        }
        //Wrapped _ColLookup() --- checks for input validity
        public bool[][] ColLookup(int col)
        {
            if (col >= this.ColumnCount)
            {
                Console.WriteLine(String.Format("ColLookup: This puzzle has only {0} columns.\t{2} is used instead of given argument {1}", this.ColumnCount, col, this.ColumnCount - 1));
                col = this.ColumnCount - 1;
            }
            else if (col < 0)
            {
                Console.WriteLine(String.Format("ColLookup: Negative column number used\tUsing 0 instead of given argument{0}", col));
                col = 0;
            }
            return _ColLookup(col);
        }

        public void DisplayPicture(int[][] rowHints = null)
        {
            string[] rowFactors = new string[rowHints.Length];
            int i = 0;
            foreach (int[] row in rowHints)
            {
                rowFactors[i++] = string.Join(" ", row.Select(x => x.ToString()).ToArray());
            }
            string formatString = "{0," + this.ColumnCount + "}  ";
            bool rowPrint = (rowFactors != null && rowFactors.Length == this.RowCount);

            if (!rowPrint)
            {
                Console.WriteLine("rowFactors doesn't match the number of rows");
            }

            // Upper border of the displayed picture
            Console.Write(String.Format(formatString, "") + " ");
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
                    Console.Write(String.Format(formatString, rowFactors[row]) + "|");
                }
                for (int col = 0; col < this.ColumnCount; col++)
                {
                    if (PictureGrid[row, col,1])
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
            Console.Write(String.Format(formatString, "") + " ");
            for (int col = 0; col < this.ColumnCount; col++)
            {
                Console.Write("ㅡ");
            }
            Console.Write("\n");
        }

    }
}
