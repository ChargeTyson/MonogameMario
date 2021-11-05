using Mario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario
{
    class FireFlower : IItem
    {

        private ISprite fireFlower;

        public int X { get; set; }
        public int Y { get; set; }
        public bool isDeletable { get; set; }

        public FireFlower(SpriteFactory factory, int myX, int myY)
        {
            fireFlower = factory.GetSprite("Item_Flower");
            X = myX * 32;
            Y = myY * 32;
            isDeletable = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            fireFlower.Draw(spriteBatch, X, Y);
        }

        public Rectangle GetHitbox()
        {
            Rectangle OldRect = fireFlower.GetRectangle();
            Rectangle NewRect = new Rectangle(X, Y, OldRect.Width, OldRect.Height);
            return NewRect;
        }
        public void Update()
        {
            fireFlower.Update();
        }
    }
}
