using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem_01.DL;
using Problem_01.UI;

namespace Problem_01.BL
{
    public class Pacman
    {
        public int X;
        public int Y;
        public int Score;
        public Grid MazeGrid;

        public Pacman(int X, int Y, Grid MazeGrid)
        {
            this.X = X;
            this.Y = Y;
            this.MazeGrid = MazeGrid;
        }

        public void Draw()
        {
            Cell b = null;
            bool isFounD = false;
            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    if (maze[x, y] == a)
                    {
                        b = maze[x - 1, y];
                        isFounD = true;
                        break;
                    }
                }
                if (isFounD == true)
                {
                    break;
                }
            }
        }









    }
}
