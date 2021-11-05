using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mario
{
    class SpriteObject : ISprite
    {

        private Texture2D spritesheet;
        private Queue<Rectangle> sourceRectangles;
        private Rectangle currentRectangle;
        const float SCALE = 2.0f;
        
        public SpriteObject(Texture2D mySpritesheet, Queue<Rectangle> myRectangles)
        {
            spritesheet = mySpritesheet;
            sourceRectangles = myRectangles;
            currentRectangle = sourceRectangles.Peek();
            
        }

        public void Draw(SpriteBatch spriteBatch, int destinationX, int destinationY)
        {
            Vector2 destination = new Vector2(destinationX, destinationY);
            spriteBatch.Draw(spritesheet, destination, currentRectangle, Color.White, 0f, Vector2.Zero, SCALE, SpriteEffects.None, 0f);

        }

        public void Update()
        {
            currentRectangle = sourceRectangles.Dequeue();
            sourceRectangles.Enqueue(currentRectangle);
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(0, 0, currentRectangle.Width * (int)SCALE, currentRectangle.Height * (int)SCALE);
        }
    }
}
