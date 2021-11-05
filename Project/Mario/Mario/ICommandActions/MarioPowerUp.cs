using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mario
{
    class MarioPowerUp : ICommand
    {
        private Game1 MyGame;
        public MarioPowerUp(Game1 game)
        {
            MyGame = game;
        }

        public void Execute()
        {
            MyGame.mario.IncrementMarioHealth();
        }
    }
}
