using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_v_4_.BL
{
    class HeroData
    {
        public int heroX;
        public int heroY;
        public int princeHealth;
        public int rightSteps;
        public int loadedArrow;
        public int score;
        public int bomb;

        public int wallX;
        public int wallY;
        public int wallSize;

        public char heart = Convert.ToChar(3);
        public char fruit = Convert.ToChar(147);

        public bool checkBush;
        public bool gameExit;
        public bool isFire;


        public List<FireCoordinates> arrows = new List<FireCoordinates>();

        public void AddinFireList(int xPos, int yPos)
        {
            FireCoordinates fire = new FireCoordinates(xPos, yPos);
            arrows.Add(fire);
        }
        public void RemovefromFireList(int idx)
        {
            arrows.RemoveAt(idx);
        }

        public void AddRightStep()
        {
            rightSteps++;
            if (rightSteps >= 25)
            {
                rightSteps = 25;
            }
        }

        public void AddScore(int num)
        {
            score = score + num;
        }

        public void HeroHealth(int num)
        {
            princeHealth = princeHealth - num;
            if (princeHealth < 0)
            {
                princeHealth = 0;
            }
        }

        public void RecoverHealth()
        {
            princeHealth = princeHealth + 40;
            if (princeHealth > 100)
            {
                princeHealth = 100;
            }
        }

        public void Reload()
        {
            if (loadedArrow <= 0)
            {
                isFire = false;
            }
            if (isFire == false)
            {
                loadedArrow++;
            }
            if (loadedArrow == 9)
            {
                isFire = true;
            }
        }










    }
}
