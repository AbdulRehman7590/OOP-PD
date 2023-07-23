using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Problem_01.BL;
using Problem_01.UI;

namespace Problem_01.DL
{
    public class GridDL
    {
        public static void LoadMaze(string Path, Cell[,] maze)
        {
            if (File.Exists(Path))
            {
                int row = 0;
                StreamReader file = new StreamReader(Path);
                string record;
                while (!file.EndOfStream)
                {
                    record = file.ReadLine();

                    if (record != null)
                    {
                        for (int x = 0; x < record.Length; x++)
                        {
                            maze[row, x] = new Cell(record[x], row, x);
                        }
                        row++;
                    }
                }
                file.Close();
            }
            else
            {
                Console.WriteLine("Unable to load file");
            }
        }
    }
}
