using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem_01.DL;
using Problem_01.UI;

namespace Problem_01.BL
{
    public class Ghost
    {
        public int X;
        public int Y;
        public string GhostDirection;
        public char GhostCharacter;
        public float Speed;
        public char PreviousItem;
        public float DeltaChange;
        public Grid MazeGrid;

        public Ghost(int X, int Y, char GhostCharacter, string GhostDirection, float Speed, char PreviousItem, Grid MazeGrid)
        {
            this.X = X;
            this.Y = Y;
            this.GhostCharacter = GhostCharacter;
            this.GhostDirection = GhostDirection;
            this.Speed = Speed;
            this.PreviousItem = PreviousItem;
            this.MazeGrid = MazeGrid;
        }


        public void SetDirection(string dir)
        {
            this.GhostDirection = dir;
        }

        public string GetDirection()
        {
            return this.GhostDirection;
        }

        public char GetCharacter()
        {
            return this.GhostCharacter;
        }

        public void ChangeDelta()
        {
            DeltaChange = DeltaChange + Speed;
        }

        public float GetDelta()
        {
            return this.DeltaChange;
        }

        public void SetDeltaZero()
        {
            DeltaChange = 0;
        }

        public void Move()
        {
            ChangeDelta();

            if (Math.Floor(GetDelta()) == 1)
            {
                if (GhostCharacter == 'H')
                {
                    MoveHorizontal(MazeGrid);
                }
                SetDeltaZero();
            }
        }

        public void Remove()
        {
            if (MazeGrid.FindGhost(this.GhostCharacter))
            {
                this.MazeGrid[this.X, this.Y] = new Cell(' ', X, Y);
            }
             
        }











    }
}
