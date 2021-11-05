using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mario
{
    class MarioMoveRight : ICommand
    {
        private Game1 MyGame;

        public MarioMoveRight(Game1 Game)
        {
            MyGame = Game;
        }


        public void Execute()
        {
            MyGame.movementManager.MoveRight();
            MyGame.mario.SetRightFace(true);    //run mario idle at the end of move right animation
            MyGame.mario.MarioMoveRight();
        }
    }
}
