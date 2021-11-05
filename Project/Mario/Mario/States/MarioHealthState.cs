using System;
using System.Collections.Generic;
using System.Text;

namespace Mario
{
    class MarioHealthState
    {
        private int health = 1;
        public MarioHealthState()
        {

        }

        public int GetHealthInt()
        {
            return health;  //debug tool
        }

        public string GetHealthStr()
        {
            if (health == 1)
            {
                return "_Small";
            }
            else if (health == 2)
            {
                return "_Big";
            }
            //else if(health == 3)
            else
            {
                return "_Fire";
            }
            //else
            //{
            //    return "_Small";    //consider changing to a dead state later.
            //}
            
        }
        public void IncrementHealth()
        {
            if(health<3) health++;
        }
        public void DecrementHealth()
        {
            if(health>1)    health--;
        }
        public void MarioBecomeFire()
        {
            health = 3;
        }

    }
}
