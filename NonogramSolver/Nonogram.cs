using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonogramSolver
{
    class Nonogram
    {
        private int _rowCount;
        private int _columnCount;
        // [row, column]
        // PictureGrid[,,0] is for 'confirmed' or not,
        // PictureGrid[,,1] is for 'filled' or not
        private bool[,,] _pictureGrid;

        private int[] _shape;
        public int[] Shape
        {
            get { return _shape; }
        }
        private int[][] _rowHint;
        public int[][] RowHint {
            get {return _rowHint; }
        }
        private int[][] _colHint;
        public int[][] ColHint
        {
            get{ return _colHint; }
        }

        public Nonogram(int rowCount, int columnCount, int[,] fillCoords = null)
        {
            if (rowCount < 1)
            {
                Console.WriteLine("rowCount should be a positive integer. Forcing the argument to be 1. ");
                rowCount = 1;
            }
            if (columnCount < 1)
            {
                Console.WriteLine("columnCount should be a positive integer. Forcing the argument to be 1.");
                columnCount = 1;
            }
            this._rowCount = rowCount;
            this._columnCount = columnCount;
            // PictureGrid[,,0] is for 'confirmed' or not,
            // PictureGrid[,,1] is for 'filled' or not
            this._pictureGrid = new bool[rowCount, columnCount, 2];
            this._shape = new int[2] { rowCount, columnCount };
            this._rowHint = new int[rowCount][];
            this._colHint = new int[columnCount][];

            // Initialize hints
            for (int i = 0; i < rowCount; i++)
            {
                _rowHint[i] = new int[] { };
            }
            for (int i = 0; i < columnCount; i++)
            {
                _colHint[i] = new int[] { };
            }

            // Fill in as coordinates
            if (fillCoords != null)
            {
                int len = fillCoords.Length / 2;
                for (int coord = 0; coord < len; coord++)
                {
                    _FillCoordinate(fillCoords[coord, 0], fillCoords[coord, 1]);
                }
            }
        }

        private void _FillCoordinate(int row, int col, bool confirmed = false)
        {
            _pictureGrid[row, col, 1] = confirmed;
            _pictureGrid[row, col, 1] = true;

            // Update the column and row hints
            UpdateHint(row, col);
            
        }
        // Wrapped _FillCoordinate() --- checks for input validity
        public void FillCoordinate(int row, int col, bool confirmed = false)
        {
            if (row >= _rowCount)
            {
                Console.WriteLine(string.Format("FillCoordinate: This puzzle has only {0} rows.\t{2} is used instead of given argument {1}", _rowCount, row, _rowCount - 1));
                row = _rowCount - 1;
            }
            else if (row < 0)
            {
                Console.WriteLine(string.Format("FillCoordinate: Negative row number used.\tUsing 0 instead of given argument {0}", row));
                row = 0;
            }
            if (col >= _columnCount)
            {
                Console.WriteLine(string.Format("FillCoordinate: This puzzle has only {0} columns.\t{2} is used instead of given argument {1}", _columnCount, col, _columnCount - 1));
                col = _columnCount - 1;
            }
            else if (col < 0)
            {
                Console.WriteLine(string.Format("FillCoordinate: Negative column number used\tUsing 0 instead of given argument{0}", col));
                col = 0;
            }
            _FillCoordinate(row, col, confirmed);
        }

        private void _ToggleFill(int row, int col)
        {
            this._pictureGrid[row, col,1] = !this._pictureGrid[row, col,1];
            UpdateHint(row, col);
        }
        // Wrapped _ToggleCoordinate() --- checks for input validity
        public void ToggleFill(int row, int col)
        {
            if (row >= this._rowCount)
            {
                Console.WriteLine(string.Format("ToggleFill: This puzzle has only {0} rows.\t{2} is used instead of given argument {1}", _rowCount, row, _rowCount - 1));
                row = _rowCount - 1;
            }
            else if (row < 0)
            {
                Console.WriteLine(string.Format("ToggleFill: Negative row number used.\tUsing 0 instead of given argument {0}", row));
                row = 0;
            }
            if (col >= _columnCount)
            {
                Console.WriteLine(string.Format("ToggleFill: This puzzle has only {0} columns.\t{2} is used instead of given argument {1}", _columnCount, col, _columnCount - 1));
                col = _columnCount - 1;
            }
            else if (col < 0)
            {
                Console.WriteLine(string.Format("ToggleFill: Negative column number used\tUsing 0 instead of given argument{0}", col));
                col = 0;
            }
            _ToggleFill(row, col);
        }

        private bool[] _Lookup(int row, int col)
        {
            return new bool[] { _pictureGrid[row, col, 0], _pictureGrid[row, col, 1]};
        }
        // Wrapped _Lookup() --- checks for input validity
        public bool[] Lookup(int row, int col)
        {
            if (row >= _rowCount)
            {
                Console.WriteLine(string.Format("Lookup: This puzzle has only {0} rows.\t{2} is used instead of given argument {1}", _rowCount, row, _rowCount - 1));
                row = _rowCount - 1;
            }
            else if (row < 0)
            {
                Console.WriteLine(string.Format("Lookup: Negative row number used.\tUsing 0 instead of given argument {0}", row));
                row = 0;
            }
            if (col >= _columnCount)
            {
                Console.WriteLine(string.Format("Lookup: This puzzle has only {0} columns.\t{2} is used instead of given argument {1}", _columnCount, col, _columnCount - 1));
                col = _columnCount - 1;
            }
            else if (col < 0)
            {
                Console.WriteLine(string.Format("Lookup: Negative column number used\tUsing 0 instead of given argument{0}", col));
                col = 0;
            }
            return _Lookup(row, col);

        }

        private bool[][] _RowLookup(int row)
        {
            bool[][] returnArray = new bool[_columnCount][];
            for (int col = 0; col < _columnCount; col++)
            {
                returnArray[col] = new bool[] { _pictureGrid[row, col, 0], _pictureGrid[row, col, 1] };
            }
            return returnArray;
        }
        // Wrapped _RowLookup() --- checks for input validity
        public bool[][] RowLookup(int row)
        {
            if (row >= _rowCount)
            {
                Console.WriteLine(String.Format("RowLookup: This puzzle has only {0} rows.\t{2} is used instead of given argument {1}", _rowCount, row, _rowCount - 1));
                row = _rowCount - 1;
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
            bool[][] returnArray = new bool[_rowCount][];
            for (int row = 0; row < _rowCount; row++)
            {
                returnArray[row] = new bool[] { _pictureGrid[row, col, 0], _pictureGrid[row, col, 1] };
            }
            return returnArray;
        }
        //Wrapped _ColLookup() --- checks for input validity
        public bool[][] ColLookup(int col)
        {
            if (col >= _columnCount)
            {
                Console.WriteLine(string.Format("ColLookup: This puzzle has only {0} columns.\t{2} is used instead of given argument {1}", _columnCount, col, _columnCount - 1));
                col = _columnCount - 1;
            }
            else if (col < 0)
            {
                Console.WriteLine(string.Format("ColLookup: Negative column number used\tUsing 0 instead of given argument{0}", col));
                col = 0;
            }
            return _ColLookup(col);
        }

        public void DisplayPicture()
        {
            Console.Write(" ");

            // Upper border of the displayed picture
            for (int col = 0; col < _columnCount; col++)
            {
                Console.Write("__");
            }
            Console.Write("\n");
            // Contents of the displayed picture
            Console.OutputEncoding = Encoding.UTF8;
            for (int row = 0; row < _rowCount; row++)
            {
                Console.Write("|");
                for (int col = 0; col < _columnCount; col++)
                {
                    if (_pictureGrid[row, col, 1])
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
            Console.Write(" ");
            for (int col = 0; col < _columnCount; col++)
            {
                Console.Write("ㅡ");
            }
            Console.Write("\n");
        }

        public void DisplayPuzzle()
        {
            // Prepare the hints to be printed on the left of the picture
            string[] rowFactors = new string[_rowHint.Length];
            int i = 0;
            int maxHint = 0;
            foreach (int[] row in _rowHint)
            {
                rowFactors[i++] = string.Join(" ", row.Select(x => x.ToString()).ToArray());
                if (row.Length > maxHint)
                {
                    maxHint = row.Length;
                }
            }
            string formatString = "{0," + (maxHint * 2 /*- 1*/) + "} ";

            DisplayColHints(maxHint);
            // Upper border of the displayed picture
            Console.Write(string.Format(formatString, "") + " ");
            for (int col = 0; col < _columnCount; col++)
            {
                Console.Write("__");
            }
            Console.Write("\n");

            // Contents of the displayed picture
            Console.OutputEncoding = Encoding.UTF8;
            for (int row = 0; row < _rowCount; row++)
            {
                Console.Write(String.Format(formatString, rowFactors[row]) + "|");
                for (int col = 0; col < _columnCount; col++)
                {
                    if (_pictureGrid[row, col,1])
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
            for (int col = 0; col < _columnCount; col++)
            {
                Console.Write("ㅡ");
            }
            Console.Write("\n");
        }

        private void DisplayColHints(int maxHint)
        {
            /*
             * Takes in an array of integer array and prints them out in right-aligned and rotated 90 CW format.
             */
            int[][] colHints = _colHint;
            string spacing = string.Format("{0," + (maxHint * 2 + 2) + "}","");

            // Make an array with the information of length of each column hints
            int maxLength;
            int[] lengths = new int[colHints.Length];
            for (int col = 0; col < colHints.Length; col++)
            {
                lengths[col] = colHints[col].Length;
            }
            maxLength = lengths.Max();

            // Since some
            for (int hintRow = 0; hintRow < maxLength; hintRow++)
            {
                Console.Write(spacing);
                for (int col = 0; col < colHints.Length; col++)
                {
                    if (maxLength - hintRow - 1 < lengths[col])
                    {
                        Console.Write(string.Format("{0,2}",colHints[col][lengths[col]-maxLength+hintRow]));
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }
                Console.Write("\n");
            }
        }

        private void UpdateHint(int row, int col)
        {
            // Check the fill of one vertical line and one horizontal line with the (row, col) in the middle.
            bool[] columnFill = new bool[_rowCount];
            bool[] rowFill = new bool[_columnCount];
            // Each column is as long as the number of rows and each row is as long as the number of columns

            bool[][] rowLookup = _RowLookup(row);
            bool[][] colLookup = _ColLookup(col);
            for (int i = 0; i < _columnCount; i++)
            {
                rowFill[i] = rowLookup[i][1];
            }
            for (int i = 0; i < _rowCount; i++)
            {
                columnFill[i] = colLookup[i][1];
            }

            // Counting from start of the *Fill array, look for consecutive trues.
            // If consecutive true is not zero, append to the hint list.
            List<int> rowHint = new List<int>();
            List<int> colHint = new List<int>();

            int consecutiveCount = 0;
            bool prev = false;
            foreach (bool filled in rowFill)
            {
                if (filled)
                {
                    consecutiveCount += 1;
                }
                else if (prev)
                {
                    rowHint.Add(consecutiveCount);
                    consecutiveCount = 0;
                }
                prev = filled;
            }
            if (prev)
            {
                rowHint.Add(consecutiveCount);
            }

            consecutiveCount = 0;
            prev = false;

            foreach (bool filled in columnFill)
            {
                if (filled)
                {
                    consecutiveCount += 1;
                }
                else if (prev)
                {
                    colHint.Add(consecutiveCount);
                    consecutiveCount = 0;
                }
                prev = filled;
            }
            if (prev)
            {
                colHint.Add(consecutiveCount);
            }

            // Update the new row and column to property
            _rowHint[row] = rowHint.ToArray();
            _colHint[col] = colHint.ToArray();
        }
    }
}
