using System;
using System.Collections.Generic;
using System.Text;

namespace Mario
{
    class GameReset : ICommand
    {

        Game1 MyGame;
        public GameReset(Game1 game)
        {
            MyGame = game;
        }
        public void Execute()
        {
            MyGame.Reset();
        }
    }
}

