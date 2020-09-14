using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonogramSolver
{
    class Solver01
    {
        // I might not tuse the confirmed bit (bool) in this solver, but maybe I can use the feature in another search-based algorithm
        public Nonogram Solve(int[][] rowHints, int[][] colHints)
        {
            if (!ValidateHints(rowHints, colHints))
            {
                return new Nonogram(1, 1);
            }
            int rowCount = rowHints.Length;
            int columnCount = colHints.Length;
            Nonogram puzzle = new Nonogram(rowCount, columnCount);

            return puzzle;
        }

        public bool ValidateHints(int[][] rowHints, int[][] colHints)
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
    }
}
