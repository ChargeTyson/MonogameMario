using Mario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario
{
    class Mushroom1Up : IItem
    {

        private ISprite mushroom1Up;

        public int X { get; set; }
        public int Y { get; set; }
        public bool isDeletable { get; set; }

        public Mushroom1Up(SpriteFactory factory, int myX, int myY)
        {
            mushroom1Up = factory.GetSprite("Item_OneUp");
            X = myX * 32;
            Y = myY * 32;
            isDeletable = false;
        }

        public Rectangle GetHitbox()
        {
            Rectangle OldRect = mushroom1Up.GetRectangle();
            Rectangle NewRect = new Rectangle(X, Y, OldRect.Width, OldRect.Height);
            return NewRect;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            mushroom1Up.Draw(spriteBatch, X, Y);
        }

        public void Update()
        {
            // Not needed for 1Up
        }
    }
}
