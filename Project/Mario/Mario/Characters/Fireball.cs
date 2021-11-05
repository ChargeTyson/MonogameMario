using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mario
{
    class FireBall:IProjectile
    {
        internal Boolean Active = false;
        private int X = 0;
        private int Y = 0;
        private int StartingX;
        private string key = "Item_Fireball";
        private int RightFace = 1;      //1 is true, 0 is false.
        ISprite Sprite;
        private SpriteFactory factory;
        private int Bounce = 0;


        public Boolean isActive()
        {
            return Active;
        }


        public FireBall(int MarioX,int MarioY, int isRightFace, SpriteFactory myFactory)
        {
            X = MarioX + 7; // hard coded offset away from mario.
            Y = MarioY + 20;
            Active = true;
            StartingX = MarioX + 5;
            factory = myFactory;
            Sprite = factory.GetSprite(key);
            this.RightFace = isRightFace;
            Bounce = Y + 10;
            

        }


        public void Update()
        {
            if (RightFace == 1)
            {
                if (X - StartingX <= 150)   //HARDCODED DISTANCE
                {
                    X = X + 5;
                    if (Y < Bounce)
                    {
                        Y = Y + 2;
                    }
                    else
                    {
                        Y = Y - 2;
                    }

                }
                else
                {
                    Active = false;
                }
            }
            else
            {
                if (StartingX - X <= 150 )   // distance away from mario
                {
                    X = X - 5;
                    if (Y < Bounce)
                    {
                        Y = Y + 2;
                    }
                    else
                    {
                        Y = Y - 2;
                    }
                }
                else
                {
                    Active = false;
                }
            }
            Sprite.Update();


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, X, Y);
        }
    }
}
