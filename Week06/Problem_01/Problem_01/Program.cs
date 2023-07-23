using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem_01.UI;
using Problem_01.DL;
using Problem_01.BL;

namespace Problem_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Grid test = new Grid(4, 10, "maze.txt");
            Console.ReadKey();
        }
    }
}
