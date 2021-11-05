using System;
using System.Collections.Generic;
using System.Text;

namespace Mario
{
    class MarioSquat : ICommand
    {
        private Game1 MyGame;
        public MarioSquat(Game1 Game)
        {
            MyGame = Game;
        }


        public void Execute()
        {
            MyGame.mario.MarioSquat();
        }
    }
}
