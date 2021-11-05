using System;
using System.Collections.Generic;
using System.Text;

namespace Mario.ICommandActions
{
    class NextEnemy : ICommand
    {

        private Game1 myGame;
        // FUNCTIONALITY FOR SPRINT 2
        private int prevTime;
        private int timeNow;
        private bool first;

        public NextEnemy(Game1 myGame)
        {
            this.myGame = myGame;
            first = true;
        }

        public void Execute()
        {
            if (first)
            {
                prevTime = (int)myGame.gt.TotalGameTime.TotalMilliseconds;
                first = false;
            }

            timeNow = (int)myGame.gt.TotalGameTime.TotalMilliseconds;
            if (timeNow - prevTime >= 250)
            {
                myGame.Manager.NextEnemy();

                prevTime = timeNow;
            }
        }
    }
}
