using System;
using System.Collections.Generic;
using System.Text;

namespace Mario
{
    class MarioSetIdleAnimation : ICommand
    {
        Game1 MyGame;
        public MarioSetIdleAnimation(Game1 game)
        {
            MyGame = game;
        }
        public void Execute()
        {
            MyGame.mario.MarioSetIdleAnimation();
        }
    }
}
