using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mario
{
    class GamePadTranslator
    {
        private Game1 myGame;
        public GamePadTranslator(Game1 Game){
            myGame = Game;
        }
        public string GetKey(GamePadState state)
        {
            if (state.ThumbSticks.Left.X > 0.5f)
            {
                return "D"; //Key for mario moving right
            }
            else if (state.ThumbSticks.Left.X < -0.5f)
            {
                return "A"; //Key for mario moving right
            }
            else if (state.IsButtonDown(Buttons.A))
            {
                return "Jump"; //Key for mario moving right
            }
            else if (state.IsButtonDown(Buttons.B))
            {
                return "ThrowFireball"; //Key for mario moving right
            }
            else
            {
                return "Idle";   //if nothing return marios idle stance.
            }
        }


    }
}
