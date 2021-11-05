using Mario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario
{
    class Star : IItem
    {
        private ISprite star;

        public int X { get; set; }
        public int Y { get; set; }
        public bool isDeletable { get; set; }

        public Star(SpriteFactory factory, int myX, int myY)
        {
            star = factory.GetSprite("Item_Star");
            X = myX * 32;
            Y = myY * 32;
            isDeletable = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            star.Draw(spriteBatch, X, Y);
        }

        public Rectangle GetHitbox()
        {
            Rectangle OldRect = star.GetRectangle();
            Rectangle NewRect = new Rectangle(X, Y, OldRect.Width, OldRect.Height);
            return NewRect;
        }

        public void Update()
        {
            star.Update();
        }
    }
}
