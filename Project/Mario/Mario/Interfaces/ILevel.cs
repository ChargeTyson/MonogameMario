﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mario
{
    interface ILevel
    {
        public void Draw(SpriteBatch spriteBatch);

        public Rectangle GetHitbox();
    }
}
