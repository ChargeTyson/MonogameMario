using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Interfaces
{
    interface IItem
    {

        public int X { get; set; }
        public int Y { get; set; }
        
        //When there is a collision event that requires and object to be removed
        //This is changed to true which flags ObjectManager to remove it from its list
        public bool isDeletable { get; set; }

        public void Draw(SpriteBatch spriteBatch);

        public void Update();

        public Rectangle GetHitbox();
        
    }
}
