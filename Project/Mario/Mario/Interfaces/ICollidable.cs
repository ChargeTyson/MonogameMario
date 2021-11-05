using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mario
{
    interface ICollidable
    {
        public String returnTypeStr();
        public Rectangle GetHitbox();


    }
}
