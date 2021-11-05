using System;
using System.Collections.Generic;
using System.Text;

namespace Mario
{
    class MarioStopMoving : ICommand
    {
        private Game1 Game;

        public MarioStopMoving(Game1 myGame)
        {
            Game = myGame;
        }

        public void Execute()
        {
            Game.movementManager.StopMarioMovement();
        }
    }
}
