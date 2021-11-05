using Mario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario
{
    class Coin : IItem
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool isDeletable { get; set; }

        private ISprite coin;

        public Coin(SpriteFactory factory, int myX, int myY)
        {
            coin = factory.GetSprite("Item_Coin");
            X = myX * 32;
            Y = myY * 32;
            isDeletable = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            coin.Draw(spriteBatch, X, Y);
        }

        public Rectangle GetHitbox()
        {
            Rectangle OldRect = coin.GetRectangle();
            Rectangle NewRect = new Rectangle(X, Y, OldRect.Width, OldRect.Height);
            return NewRect;
        }

        public void Update()
        {
            coin.Update();
        }
    }
}
