using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mario
{
    class Level1_1A : ILevel
    {
        private int X;
        private int Y;
        private ISprite Sprite;

        public Level1_1A(SpriteFactory myFactory, int myX, int myY)
        {
            Sprite = myFactory.GetSprite("Level_1-1_A");
            X = myX * 32;
            Y = myY * 32;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, X, Y);
        }

        public Rectangle GetHitbox()
        {
            Rectangle OldRect = Sprite.GetRectangle();
            Rectangle NewRect = new Rectangle(X, Y, OldRect.Width, OldRect.Height);
            return NewRect;
        }
    }
}
