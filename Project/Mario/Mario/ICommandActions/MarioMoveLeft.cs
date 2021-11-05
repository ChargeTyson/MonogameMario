using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mario
{
    class MarioMoveLeft : ICommand
    {
        private Game1 MyGame;

        public MarioMoveLeft(Game1 Game)
        {
            MyGame = Game;
        }


        public void Execute()
        {
            MyGame.movementManager.MoveLeft();
            MyGame.mario.SetRightFace(false);
            //MyGame.mario.MarioSetIdleAnimation();
            MyGame.mario.MarioMoveLeft();
        }
    }
}
