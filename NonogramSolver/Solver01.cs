using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonogramSolver
{
    class Solver01
    {

        public void Solve(int[][] rowHints, int[][] colHints, Nonogram puzzle)
        {
            // Check hint length with the puzzle shape
            int[] shape = puzzle.Shape;
            if(rowHints.Length != shape[0] || colHints.Length != shape[1])
            {
                Console.WriteLine("The hints doesn't match the shape of the puzzle");
                return;
            }


        }
    }
}
