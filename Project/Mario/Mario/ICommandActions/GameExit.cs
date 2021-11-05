using System;
using System.Collections.Generic;
using System.Text;

namespace Mario
{
    class GameExit : ICommand
    {
        
        Game1 MyGame;
        public GameExit(Game1 game)
        {
            MyGame = game;
        }
        public void Execute()
        {
            MyGame.Exit();
        }
    }
}

