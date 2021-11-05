using System;
using System.Collections.Generic;
using System.Text;

namespace Mario.ICommandActions
{
    class NextItem :ICommand
    {

        // FUNCTIONALITY FOR SPRINT 2
        private int prevTime;
        private int timeNow;
        private bool first;

        Game1 MyGame;
        public NextItem(Game1 game)
        {
            MyGame = game;
            first = true;
        }
        public void Execute()
        {
            if (first)
            {
                prevTime = (int)MyGame.gt.TotalGameTime.TotalMilliseconds;
                first = false;
            }

            timeNow = (int)MyGame.gt.TotalGameTime.TotalMilliseconds;
            if (timeNow - prevTime >= 250)
            {
                MyGame.Manager.NextItem();

                prevTime = timeNow;
            }
        }
    }
}
