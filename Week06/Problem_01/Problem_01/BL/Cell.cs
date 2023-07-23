using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_01.BL
{
    public class Cell
    {
        public char value;
        public int X;
        public int Y;

        public Cell(char value, int X, int Y)
        {
            this.value = value;
            this.X = X;
            this.Y = Y;
        }

        public char GetValue()
        {
            return this.value;
        }

        public void SetValue(char value)
        {
            this.value = value;
        }

        public int GetX()
        {
            return this.X;
        }

        public int GetY()
        {
            return this.Y;
        }

        public bool IsPacmanPresent()
        {
            bool flag = false;
            if (this.value == 'P')
            {
                flag = true;
            }
            return flag;
        }
        
        public bool IsGhostPresent(char G)
        {
            bool flag = false;
            if (this.value == G)
            {
                flag = true;
            }
            return flag;
        }

    }
}
