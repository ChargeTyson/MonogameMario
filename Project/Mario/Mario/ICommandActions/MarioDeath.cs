using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mario
{
    class MarioDeath:ICommand
    {
        private Game1 MyGame;
        public MarioDeath(Game1 game)
        {
            MyGame = game;
        }

        public void Execute()
        {
            int DeathTimer = 0;
            MyGame.keyboardController.Disable();

            while (DeathTimer < 30)
            {
                DeathTimer++;
            }
            DeathTimer = 0;
            //mario death will get the sprite ready.
            MyGame.mario.MarioDeath();
            
            //TODO: Get a pause to happen on collision first, then have mario jump up and fall.

            //movement manager jumps with mario in death sprite mode.
            MyGame.movementManager.Jump();

            while (DeathTimer < 30)
            {
                DeathTimer++;
            }

            MyGame.Reset();
            MyGame.keyboardController.Enable();
        }
    }
}
