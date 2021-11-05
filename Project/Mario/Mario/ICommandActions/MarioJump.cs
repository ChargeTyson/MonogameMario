using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mario
{
    class MarioJump:ICommand
    {
        private Game1 MyGame;
        public MarioJump(Game1 game)
        {
            MyGame = game;
        }

        public void Execute()
        {
            MyGame.movementManager.Jump();
            MyGame.mario.MarioJump();
        }
    }
}
