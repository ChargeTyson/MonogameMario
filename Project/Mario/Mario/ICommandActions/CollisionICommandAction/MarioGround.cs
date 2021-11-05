using System;
using System.Collections.Generic;
using System.Text;

namespace Mario
{
    class MarioGround:ICommand
    {
        private Game1 MyGame;

        public MarioGround(Game1 Game)
        {
            MyGame = Game;
        }

        public void Execute()
        {
            MyGame.mario.Y++;
        }
    }
}
