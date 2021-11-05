using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mario
{
    class MarioIdleLeft : ICommand
    {
        Game1 MyGame;
        public MarioIdleLeft(Game1 game)
        {
            MyGame = game;
        }
        public void Execute()
        {
            MyGame.mario.SetRightFace(false);
            MyGame.mario.MarioSetIdleAnimation();            
        }
    }
}
