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
            nng.FillCoordinate(3, 2);
            nng.DisplayPicture(new string[] {"0","0","0","1"});
            PrintJaggedArray2(nng.RowLookup(1));
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
