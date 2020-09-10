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
            Console.Read();
        }
    }
}
