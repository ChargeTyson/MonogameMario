using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario
{
    class SpriteInfo 
    {

        public Queue<Rectangle> rectangles { get; set; }
        public Texture2D spritesheet { get; set; }

        public SpriteInfo(Queue<Rectangle> myRectangles, Texture2D mySpritesheet)
        {
            rectangles = myRectangles;
            spritesheet = mySpritesheet;
        }
    }
}
