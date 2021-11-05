using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Blocks
{
    class Block
    {
        protected SpriteFactory blockFactory;
        
        protected ISprite blockSprite; //  Will hold the sprite for the block

        public int X { get; set; } // Contains the top-left X-coordinate of the block
        public int Y { get; set; } // Contains the top-left y-coordinate of the block
        
        //When there is a collision event that requires and object to be removed
        //This is changed to true which flags ObjectManager to remove it from its list
        public bool isDeletable { get; set; }

        public Block(SpriteFactory factory, int x, int y)
        {
            this.blockFactory = factory;
            this.X = x;
            this.Y = y;
            isDeletable = false;
        }

        public virtual void Update()
        {
            // Only Blocks that update will override and make use of this method
        }

        public Rectangle GetHitbox()
        {
            Rectangle OldRect = blockSprite.GetRectangle();
            Rectangle NewRect = new Rectangle(X, Y, OldRect.Width, OldRect.Height);
            return NewRect;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.blockSprite.Draw(spriteBatch, this.X, this.Y);
        }
    }
}
