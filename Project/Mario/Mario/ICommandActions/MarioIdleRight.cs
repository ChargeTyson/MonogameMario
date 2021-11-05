using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mario
{
    class MarioIdleRight : ICommand
    {
        Game1 MyGame;
        public MarioIdleRight(Game1 game)
        {
            MyGame = game;
        }
        public void Execute()
        {
            MyGame.mario.SetRightFace(true);
            MyGame.mario.MarioSetIdleAnimation();            
        }
    }
}
