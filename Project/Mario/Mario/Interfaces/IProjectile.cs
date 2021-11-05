using System;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Text;

namespace Mario
{
    interface IProjectile
    {
        //constructor gets everything that is needed for update.

        public void Update();

        public void Draw(SpriteBatch spriteBatch);

        public Boolean isActive();

    }
}
