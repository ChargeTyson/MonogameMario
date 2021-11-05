using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario
{
    public interface ISprite
    {

        public void Draw(SpriteBatch spriteBatch, int desintationX, int destinationY);

        public void Update();

        public Rectangle GetRectangle();
    }
}
