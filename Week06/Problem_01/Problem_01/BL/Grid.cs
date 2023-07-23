using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem_01.DL;
using Problem_01.UI;

namespace Problem_01.BL
{
    public class Grid
    {
        public Cell[,] maze;
        public int RowSize;
        public int ColSize;

        public Grid(int RowSize, int ColSize, string Path)
        {
            this.RowSize = RowSize;
            this.ColSize = ColSize;
            maze = new Cell[RowSize, ColSize];
            GridDL.LoadMaze(Path, maze);
        }

        public void Draw()
        {
            GridUI.PrintMaze(maze);
        }

        public Cell GetLeftCell(Cell a)
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
            return b;
        }
        
        public Cell GetRightCell(Cell a)
        {
            Cell b = null;
            bool isFounD = false;
            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    if (maze[x, y] == a)
                    {
                        b = maze[x + 1, y];
                        isFounD = true;
                        break;
                    }
                }
                if (isFounD == true)
                {
                    break;
                }
            }
            return b;
        }
        
        public Cell GetUpCell(Cell a)
        {
            Cell b = null;
            bool isFounD = false;
            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    if (maze[x, y] == a)
                    {
                        b = maze[x, y - 1];
                        isFounD = true;
                        break;
                    }
                }
                if (isFounD == true)
                {
                    break;
                }
            }
            return b;
        }
        
        public Cell GetDownCell(Cell a)
        {
            Cell b = null;
            bool isFounD = false;
            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    if (maze[x, y] == a)
                    {
                        b = maze[x, y + 1];
                        isFounD = true;
                        break;
                    }
                }
                if (isFounD == true)
                {
                    break;
                }
            }
            return b;
        }

        public Cell FindPacman()
        {
            Cell b = null;
            bool isFounD = false;
            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    if (maze[x, y].IsPacmanPresent())
                    {
                        b = maze[x, y];
                        isFounD = true;
                        break;
                    }
                }
                if (isFounD == true)
                {
                    break;
                }
            }
            return b;
        }
        
        public Cell FindGhost(char a)
        {
            Cell b = null;
            bool isFounD = false;
            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    if (maze[x, y].IsGhostPresent(a))
                    {
                        b = maze[x, y];
                        isFounD = true;
                        break;
                    }
                }
                if (isFounD == true)
                {
                    break;
                }
            }
            return b;
        }

        public bool IsStoppingCondition()
        {
            return true;
        }


    }
}
