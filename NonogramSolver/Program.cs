using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonogramSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            Nonogram nng = new Nonogram(4, 4);
            nng.FillCoordinate(3, 1);
            nng.FillCoordinate(3, 3);
            nng.FillCoordinate(1, 1);

            int[][] rowHint = new int[4][];
            {
                rowHint[0] = new int[] { 0 };
                rowHint[1] = new int[] { 1 };
                rowHint[2] = new int[] { 0 };
                rowHint[3] = new int[] { 1, 1 };
            }
            int[][] colHint = new int[4][];
            {
                colHint[0] = new int[] { 0 };
                colHint[1] = new int[] { 1,1 };
                colHint[2] = new int[] { 0 };
                colHint[3] = new int[] { 1 };
            }
            nng.DisplayPicture(rowHint, colHint);
            PrintJaggedArray2(nng.RowLookup(0));
            PrintJaggedArray2(nng.RowLookup(1));
            PrintJaggedArray2(nng.RowLookup(2));
            PrintJaggedArray2(nng.RowLookup(3));

            Solver01 test = new Solver01();
            test.Solve(rowHint, rowHint, nng);
            Console.Read();
        }

        static void PrintArray<T>(T[] array)
        {
            Console.Write("{");
            for (int i = 0; i < array.Length - 1; i++)
            {
                Console.Write(array[i] + ", ");
            }
            Console.WriteLine(array[array.Length - 1] + "}");
        }
        static void PrintJaggedArray1<T>(T[][] array)
        {
            Console.Write("{");
            for (int i = 0; i < array.Length - 1; i++)
            {
                Console.Write(array[i][0] + ", ");
            }
            Console.WriteLine(array[array.Length - 1][0] + "}");
        }
        static void PrintJaggedArray2<T>(T[][] array)
        {
            Console.Write("{");
            for (int i = 0; i < array.Length - 1; i++)
            {
                Console.Write(array[i][1] + ", ");
            }
            Console.WriteLine(array[array.Length - 1][1] + "}");
        }
    }
}
