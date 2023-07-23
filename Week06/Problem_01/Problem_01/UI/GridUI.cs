using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem_01.BL;
using Problem_01.DL;

namespace Problem_01.UI
{
    public class GridUI
    {
        public static void PrintMaze(Cell[,] maze)
        {
            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    Console.Write(maze[x, y].value);
                }
                Console.WriteLine(" ");
            }
        }
    }
}
