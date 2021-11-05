using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mario
{
    public class GamePadController : IController
    {

        private Dictionary<String, ICommand> GamePadCommands;
        private Game1 MyGame;
        private GamePadTranslator translator;

        private Boolean Enabled = true;

        public void Enable()
        {
            Enabled = true;
        }
        public void Disable()
        {
            Enabled = false;
        }

        public GamePadController(Game1 game)
        {
            GamePadCommands = new Dictionary<String, ICommand>();
            translator = new GamePadTranslator(game);
            MyGame = game;
        }
        public void RegisterCommand(String thumbStickKey, ICommand command)
        {
            GamePadCommands.Add(thumbStickKey, command);
        }

        public void Update()
        {
            GamePadState State = GamePad.GetState(PlayerIndex.One);
            String key = translator.GetKey(State);
            if (Enabled)
            {
                if (GamePadCommands.ContainsKey(key))
                {
                    GamePadCommands[key].Execute();
                }

            }
        }
    }
}
