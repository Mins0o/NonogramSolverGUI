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
            nng.ToggleFill(1, 2);
            nng.ToggleFill(1, 3);

            nng.DisplayPuzzle();

            nng.ToggleFill(1, 2);
            nng.DisplayPuzzle();

            PrintJaggedArray2(nng.RowLookup(0));
            PrintJaggedArray2(nng.RowLookup(1));
            PrintJaggedArray2(nng.RowLookup(2));
            PrintJaggedArray2(nng.RowLookup(3));

            Solver01 test = new Solver01();
            test.Solve(nng.RowHint, nng.ColHint, nng);

            Nonogram nng2 = new Nonogram(3, 5);
            nng2.FillCoordinate(0, 1);nng2.FillCoordinate(0, 3);nng2.FillCoordinate(1, 1);nng2.FillCoordinate(1, 4);nng2.FillCoordinate(2, 3);nng2.FillCoordinate(2, 4);
            nng2.DisplayPuzzle();
            nng2.DisplayPicture();

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
