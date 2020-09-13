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
            test.Solve(nng.RowHint, nng.ColHint);

            Nonogram nng2 = new Nonogram(3, 5);
            nng2.FillCoordinate(0, 1);
            nng2.FillCoordinate(0, 3);
            nng2.FillCoordinate(1, 1);
            nng2.FillCoordinate(1, 4);
            nng2.FillCoordinate(2, 3);
            nng2.FillCoordinate(2, 4);
            nng2.DisplayPuzzle();
            nng2.DisplayPicture();

            Nonogram nng3 = new Nonogram(3, 5);
            nng3.FillCoordinate(0, 1);
            nng3.FillCoordinate(0, 3);
            nng3.FillCoordinate(1, 2);
            nng3.FillCoordinate(1, 0);
            nng3.FillCoordinate(1, 4);
            nng3.FillCoordinate(2, 3);
            nng3.FillCoordinate(2, 4);
            nng3.DisplayPuzzle();

            Nonogram nng4 = new Nonogram(3, 5);
            nng4.FillCoordinate(0, 1);
            nng4.FillCoordinate(0, 3);
            nng4.FillCoordinate(1, 2);
            nng4.FillCoordinate(1, 1);
            nng4.FillCoordinate(1, 0);
            nng4.FillCoordinate(1, 4);
            nng4.FillCoordinate(2, 3);
            nng4.FillCoordinate(2, 4);
            nng4.DisplayPuzzle();


            Nonogram wikipedia = new Nonogram(20, 30);
            {
                wikipedia.FillCoordinate(0, 0);
                wikipedia.FillCoordinate(0, 1);
                wikipedia.FillCoordinate(0, 2);
                wikipedia.FillCoordinate(0, 3);
                wikipedia.FillCoordinate(0, 4);
                wikipedia.FillCoordinate(0, 5);
                wikipedia.FillCoordinate(0, 6);
                wikipedia.FillCoordinate(0, 7);
                wikipedia.FillCoordinate(0, 9);
                wikipedia.FillCoordinate(0, 10);
                wikipedia.FillCoordinate(0, 11);
                wikipedia.FillCoordinate(0, 12);
                wikipedia.FillCoordinate(0, 13);
                wikipedia.FillCoordinate(0, 14);
                wikipedia.FillCoordinate(0, 15);
                wikipedia.FillCoordinate(0, 17);
                wikipedia.FillCoordinate(0, 18);
                wikipedia.FillCoordinate(0, 19);
                wikipedia.FillCoordinate(0, 20);
                wikipedia.FillCoordinate(0, 21);
                wikipedia.FillCoordinate(0, 23);
                wikipedia.FillCoordinate(0, 24);
                wikipedia.FillCoordinate(0, 25);
                wikipedia.FillCoordinate(0, 26);
                wikipedia.FillCoordinate(0, 27);
                wikipedia.FillCoordinate(0, 28);
                wikipedia.FillCoordinate(0, 29);
            }
            int[][,] range = new int[20][,] {
                /* 1 */new int[4, 2] { { 0, 8 }, { 9, 16 }, { 17, 22 }, { 23, 29 } },
                /* 2 */new int[4, 2] { { 2, 7} , { 10, 14 } , { 18, 22 } , { 25, 29 } },
                /* 3 */new int[4, 2] { { 3, 6 } , { 11, 14 } , { 18, 21 } , { 25, 28 } },
                /* 4 */new int[4, 2] { { 3, 7 } , { 12, 15 } , { 18, 21 } , { 25, 27 } },
                /* 5 */new int[4, 2] { { 4, 7 } , { 12, 15 } , { 17, 19 } , { 25, 27 } },
                /* 6 */new int[4, 2] { { 4, 7 } , { 12, 17 } , { 17, 19 } , { 24, 26 } },
                /* 7 */new int[3, 2] { { 4, 8 } , { 13, 18 } , { 24, 26 } },
                /* 8 */new int[3, 2] { { 5, 8 } , { 13, 18 } , { 24, 25 } },
                /* 9 */new int[3, 2] { { 5, 9 } , { 14, 17 } , { 23, 25 } },
                /* 10 */new int[3, 2] { { 6, 9 } , { 14, 18 } , { 23, 25 } },
                /* 11 */new int[3, 2] { { 6, 10 } , { 14, 18 } , { 22, 24 } },
                /* 12 */new int[3, 2] { { 7, 10 } , { 13, 19 } , { 22, 24 } },
                /* 13 */new int[4, 2] { { 7, 10 } , { 13, 15 } , { 16, 19 } , { 22, 23 } },
                /* 14 */new int[4, 2] { { 7, 11 } , { 12, 15 } , { 16, 20 } , { 21, 23 } },
                /* 15 */new int[4, 2] { { 8, 11 } , { 12, 14 } , { 17, 20 } , { 21, 23 } },
                /* 16 */new int[2, 2] { { 8, 14 } , { 17 , 22 } },
                /* 17 */new int[2, 2] { { 9, 13 } , { 17 , 22 } },
                /* 18 */new int[2, 2] { { 9, 12 } , { 18 , 21 } },
                /* 19 */new int[2, 2] { { 9, 12 } , { 18 , 21 } },
                /* 20 */new int[2, 2] { { 10, 11 } , { 19 , 20 } }
            };
            for (int line = 1; line < 20; line++)
            {
                int len = range[line].Length / 2;
                for (int chunk = 0; chunk < len; chunk++)
                {
                    int end = range[line][chunk, 1];
                    for (int start = range[line][chunk, 0]; start < end; start++)
                    {
                        wikipedia.FillCoordinate(line, start);
                    }
                }
            }
            wikipedia.DisplayPuzzle();

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
