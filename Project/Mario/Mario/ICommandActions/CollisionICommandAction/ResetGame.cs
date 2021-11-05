using System;
using System.Collections.Generic;
using System.Text;

namespace Mario
{
    class ResetGame : ICommand
    {
        private Game1 MyGame;

        public ResetGame(Game1 Game)
        {
            MyGame = Game;
        }

        public void Execute()
        {
            MyGame.Reset();
        }
    }
}
