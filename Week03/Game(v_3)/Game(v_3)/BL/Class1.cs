using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_v_3_.BL
{

    class Variables
    {
        public bool checkBush;
        public bool removeCharacter;
        public bool isEnemyDead;
        public bool enemyPresence;
        public bool gameExit;
        public bool isFire;

        public string enemyDirection;

        public int score, rightmove, loadedArrow;
        public int princeHealth, enemyHealth, bomb;
        public int enemySteps, enemyCollision;
    }

    class Coordinates
    {
        public int heroX;
        public int heroY;
        public int enemyX;
        public int enemyY;
        public int wallX;
        public int wallY;
        public int wallSize;
    }

    class HeroFires
    {
        public int fireX;
        public int fireY;

        public HeroFires(int fireX, int fireY)
        {
            this.fireX = fireX;
            this.fireY = fireY;
        }
    }

    class EnemyFires
    {
        public int fireX;
        public int fireY;

        public EnemyFires(int fireX, int fireY)
        {
            this.fireX = fireX;
            this.fireY = fireY;
        }
    }
}
