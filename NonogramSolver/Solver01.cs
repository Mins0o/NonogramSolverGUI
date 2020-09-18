using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonogramSolver
{
    class Solver01
    {
        // I might not use the confirmed bit (bool) in this solver, but maybe I can use the feature in another search-based algorithm
        public Nonogram Solve(int[][] rowHints, int[][] colHints)
        {
            if (!ValidateHints(rowHints, colHints))
            {
                return new Nonogram(1, 1);
            }
            int rowCount = rowHints.Length;
            int columnCount = colHints.Length;
            Nonogram puzzle = new Nonogram(rowCount, columnCount);
            for (int row = 0; row < rowCount; row++)
            {
                foreach (int fillIn in HalfCheck(rowHints[row], columnCount))
                {
                    puzzle.FillCoordinate(row, fillIn, true);
                }
                foreach (int fillIn in FullCheck(rowHints[row], columnCount))
                {
                    puzzle.FillCoordinate(row, fillIn, true);
                }
            }
            for (int col = 0; col < columnCount; col++)
            {
                foreach (int fillIn in HalfCheck(colHints[col], rowCount))
                {
                    puzzle.FillCoordinate(fillIn, col, true);
                }
                foreach (int fillIn in FullCheck(colHints[col], rowCount))
                {
                    puzzle.FillCoordinate(fillIn, col, true);
                }
            }
            return puzzle;
        }

        private bool ValidateHints(int[][] rowHints, int[][] colHints)
        {
            int rowSum = 0;
            int colSum = 0;

            foreach (int[] hints in rowHints)
            {
                rowSum += hints.Sum();
            }
            foreach (int[] hints in colHints)
            {
                colSum += hints.Sum();
            }
            return rowSum == colSum;
        }

        private int[] HalfCheck(int[] hint, int length)
        {
            if (hint.Length == 0)
            {
                return new int[0];
            }
            int diff = 2 * hint.Max() - length;
            int[] arrayToFill;
            if (diff > 0)
            {
                arrayToFill = new int[diff];
                for (int i = 0; i < diff; i++)
                {
                    arrayToFill[i] = length - hint.Max() + i;
                }
                return arrayToFill;
            }
            else
                return new int[0];
        }

        private int[] FullCheck(int[] hint, int length)
        {
            if (hint.Length == 0)
            {
                return new int[0];
            }
            int sum = 0;
            sum += hint.Sum() + hint.Length - 1;
            if (sum == length)
            {
                int[] returnArray = new int[length - hint.Length - 1];
                int fillThisIndex = 0;
                for (int returnIndex = 0; returnIndex < returnArray.Length; returnIndex++)
                {
                    foreach (int blockLength in hint)
                    {
                        returnArray[returnIndex++] = fillThisIndex++;
                    }
                    fillThisIndex++;
                }
                return returnArray;
            }
            return new int[0];
        }

        private int[] OnlyOption(int[] hint, Nonogram puzzle)
        {
            return new int[0];
        }
    }
}
