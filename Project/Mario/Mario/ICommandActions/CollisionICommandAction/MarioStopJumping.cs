using System;
using System.Collections.Generic;
using System.Text;

namespace Mario
{
    class MarioStopJumping : ICommand
    {
        private Game1 Game;

        public MarioStopJumping(Game1 myGame)
        {
            Game = myGame;
        }

        public void Execute()
        {
            Game.movementManager.StopMarioJump();
        }
    }
}