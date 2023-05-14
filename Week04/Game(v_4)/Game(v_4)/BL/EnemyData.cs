using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_v_4_.BL
{
    class EnemyData
    {
        public int enemyX;
        public int enemyY;
        public int enemyHealth;
        public int enemySteps;
        public int enemyCollision;

        public string enemyDirection;

        public bool isEnemyDead;
        public bool enemyPresence;
        public bool removeCharacter;

        public List<FireCoordinates> bullets = new List<FireCoordinates>();

        public void AddinFireList(int xPos, int yPos)
        {
            FireCoordinates fire = new FireCoordinates(xPos, yPos);
            bullets.Add(fire);
        }
        public void RemovefromFireList(int idx)
        {
            bullets.RemoveAt(idx);
        }

        public void AddEnemySteps()
        {
            enemySteps++;
        }

        public void AddEnemyCollisions()
        {
            enemyCollision++;
        }

        public void EnemyHealth()
        {
            enemyHealth = enemyHealth - 10;
            if (enemyHealth == 0)
            {
                isEnemyDead = true;
                removeCharacter = true;
            }
        }




    }
}
