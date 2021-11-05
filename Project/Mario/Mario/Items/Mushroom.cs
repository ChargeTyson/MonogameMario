using Mario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario
{
    class Mushroom : IItem
    {

        private ISprite mushroom;

        public int X { get; set; }
        public int Y { get; set; }
        public bool isDeletable { get; set; }

        public Mushroom(SpriteFactory factory, int myX, int myY)
        {
            mushroom = factory.GetSprite("Item_Mushroom");
            X = myX * 32;
            Y = myY * 32;
            isDeletable = false;
        }

        public Rectangle GetHitbox()
        {
            Rectangle OldRect = mushroom.GetRectangle();
            Rectangle NewRect = new Rectangle(X, Y, OldRect.Width, OldRect.Height);
            return NewRect;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            mushroom.Draw(spriteBatch, X, Y);
        }

        public void Update()
        {
            // Not needed for Mushroom
        }
    }
}
