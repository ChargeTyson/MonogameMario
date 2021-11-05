using Mario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mario
{
    public class Goomba : IEnemy, ICollidable
    {
        private ISprite CurrentSprite;
        String State;
        private SpriteFactory Factory;
        public int direction { get; set; }
        private int currentFrame;

        public int X { get; set; }
        public int Y { get; set; }
        public bool isDeletable { get; set; }
        private Rectangle HitBox;

        //Again the magiv number 32 is the scaler and should be implemented somewhere else -- technical debt
        public Goomba(SpriteFactory myFactory, int myX, int myY)
        {
            State = "right";
            Factory = myFactory;
            CurrentSprite = Factory.GetSprite("Goomba_Walk_Right");
            X = myX * 32;
            Y = myY * 32;
            direction = 1; // defaults to left == -1, right == 1
            currentFrame = 0;
            HitBox = CurrentSprite.GetRectangle();
            isDeletable = false;
        }

        public void Update()
        {
            X += (direction);
            if (currentFrame >= 10)
            {
                CurrentSprite.Update();
                currentFrame = 0;
            }

            currentFrame++;

        }

        public void Collision()
        {
            //This is not what collision will do in the final game
            //instead it's mimicking what the final result of a collision will be
            //when the enemy collides with a wall it will change directions
            //(in this case however, it's just an arbitrary x value for the purposes of this sprint)
            if(State == "left")
            {
                CurrentSprite = Factory.GetSprite("Goomba_Walk_Right");
                State = "right";
            }
            else if(State == "right")
            {
                CurrentSprite = Factory.GetSprite("Goomba_Walk_Left");
                State = "left";
            }
            direction *= -1;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            CurrentSprite.Draw(spriteBatch, X, Y);
        }

        public Rectangle GetHitbox()
        {
            Rectangle NewRect = new Rectangle(X, Y, HitBox.Width, HitBox.Height);
            return NewRect;
        }

        public void Kill()
        {
            isDeletable = true;
        }

        public String returnTypeStr()
        {
            return "Goomba";
        }
    }
}
