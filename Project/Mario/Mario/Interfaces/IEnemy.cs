using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mario.Interfaces
{
    interface IEnemy
    {

        public int X { get; set; }
        public int Y { get; set; }

        public int direction { get; set; }
        
        //When there is a collision event that requires and object to be removed
        //This is changed to true which flags ObjectManager to remove it from its list
        public bool isDeletable { get; set; }

        public void Update();

        public void Collision();

        public void Draw(SpriteBatch spriteBatch);

        public Rectangle GetHitbox();

        public void Kill();




    }
}
