using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mario
{
    class MarioPowerDown : ICommand
    {
        private Game1 MyGame;
        public MarioPowerDown(Game1 game)
        {
            MyGame = game;
        }

        public void Execute()
        {
            MyGame.mario.DecrementMarioHealth();
        }
    }
}
