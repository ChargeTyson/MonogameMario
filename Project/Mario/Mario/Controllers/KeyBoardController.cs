using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mario
{
    public class KeyboardController : IController
    {

        private Dictionary<Keys, ICommand> KeyBindings;
        private Game1 MyGame;

        internal HashSet<Keys> Set=new HashSet<Keys>();

        private Boolean Enabled = true;

        public void Enable()
        {
            Enabled = true;
        }
        public void Disable()
        {
            Enabled = false;
        }

        public KeyboardController(Game1 game)
        {
            KeyBindings = new Dictionary<Keys, ICommand>();
            MyGame = game;
            Set.Add(Keys.F);
        }
        public void RegisterCommand(Keys key, ICommand command)
        {
            KeyBindings.Add(key, command);
        }

        public void Update()
        {
            Keys[] PressedKeys = Keyboard.GetState().GetPressedKeys();

            if (PressedKeys.Length == 0)
            {
                new MarioSetIdleAnimation(MyGame).Execute();
            }

            if (Enabled)
            {
                foreach (Keys key in PressedKeys)
                {
                    if (key.CompareTo(Keys.F) == 0 && !Set.Contains(Keys.F))
                    {
                        KeyBindings[key].Execute();
                        Set.Add(key);
                    }
                    else if (key.CompareTo(Keys.F) != 0)
                    {
                        if (KeyBindings.ContainsKey(key)) 
                        { 
                            KeyBindings[key].Execute();
                        }
                    }


                }
            }
            //Set.Clear();
        }
    }
}

