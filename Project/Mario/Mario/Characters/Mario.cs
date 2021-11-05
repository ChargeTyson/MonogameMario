using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mario
{
    internal class Mario
    {


        private ISprite Sprite; //This object uses the Sprite Factory.
        
        MarioMovementState MarioMovement = new MarioMovementState();
        MarioHealthState MarioHealth = new MarioHealthState();
        
        //MARIO LOCATION
        public int X { get; set; } 
        public int Y { get; set; }
        bool RightFace = true;
        bool squat = false;
        private SpriteFactory Factory;
        private string Key="";
        private int marioSpawn = Game1.screenHeight - 120;
        public bool isJumping;
        private Rectangle HitBox;

        //Fireball BS
        //FireBall FireBall = new FireBall();


        public  Mario(SpriteFactory myFactory,KeyboardController keyboardController)
        {
            this.Factory = myFactory;
            Key = "Mario_Small_Idle_Right";
            Sprite = Factory.GetSprite(Key);    //DEFAULT VALUE WHEN GAME STARTS, GIVE IDLE RIGHT

            X = 300;
            Y = marioSpawn;

            isJumping = false;
            HitBox = Sprite.GetRectangle();
        }

        public void MarioDeath()
        {
            Key = "Mario_Small_Die";


            Sprite = Factory.GetSprite(Key);
        }

        public void MarioSquat()
        {
            squat = true;
            Key = "Mario";
            Key = Key + MarioHealth.GetHealthStr();
            if (RightFace)
            {
                Key = Key + MarioMovement.SquatRight();
            }
            else
            {
                Key = Key + MarioMovement.SquatLeft();
            }
            Sprite = Factory.GetSprite(Key);
        }

        public void IncrementMarioHealth()
        {
            MarioHealth.IncrementHealth();
            this.MarioSetIdleAnimation();

        }

        public void DecrementMarioHealth()
        {
            MarioHealth.DecrementHealth();
            this.MarioSetIdleAnimation();
        }

        public void SetFireFlower()
        {
            MarioHealth.MarioBecomeFire();
            this.MarioSetIdleAnimation();
        }

        public List<int> MarioFireFlowerAction()
        {
            

            //Sprite Stuff
            if (MarioHealth.GetHealthInt() == 3)
            {
                Key = "Mario";
                Key = Key + MarioHealth.GetHealthStr();
                if (!RightFace)
                {
                    Key = Key + MarioMovement.FireBallThrowRight();
                    
                    //FireBall.Active = true;
                    //FireBall.Throw(X, Y, RightFace, Factory);   //DATA CLUMPING, SMELLY
                    
                }
                else
                {
                    Key = Key + MarioMovement.FireBallThrowLeft();
                    //FireBall.Active = true;
                    //FireBall.Throw(X, Y, RightFace, Factory);
                }
                


            }
            List<int> MarioData = new List<int>();
            MarioData.Add(this.X);
            MarioData.Add(this.Y);

            if (RightFace)
            {
                MarioData.Add(1);
            }
            else
            {
                MarioData.Add(0);
            }

            Sprite = Factory.GetSprite(Key);
            return MarioData;
        }

        public void SetRightFace(Boolean isRightFace)
        {
            RightFace = isRightFace;
        }
        public void MarioSetIdleAnimation()
        {
            squat = false;
            if (RightFace)
            {
                Key = "Mario";
                Key = Key + MarioHealth.GetHealthStr();
                Key = Key + MarioMovement.IdleRight();
            }
            else
            {
                Key = "Mario";
                Key = Key + MarioHealth.GetHealthStr();
                Key = Key + MarioMovement.IdleLeft();
            }
            Sprite = Factory.GetSprite(Key);    //change the sprite to wherever mario is facing
        }

        public void MarioMoveRight()
        {
            if (!squat && !isJumping)
            {
                Key = "Mario";
                Key = Key + MarioHealth.GetHealthStr();
                Key = Key + MarioMovement.RunRight();
                Sprite = Factory.GetSprite(Key);
            }
        }
        public void MarioMoveLeft()
        {
            if (!squat && !isJumping)
            {
                Key = "Mario";
                Key = Key + MarioHealth.GetHealthStr();
                Key = Key + MarioMovement.RunLeft();

                Sprite = Factory.GetSprite(Key);
            }
        }

        public void MarioJump()
        {
            Key = "Mario";
            Key = Key + MarioHealth.GetHealthStr();
            

            if (RightFace)
            {
                Key = Key + MarioMovement.JumpRight();
            }
            else
            {
                Key = Key + MarioMovement.JumpLeft();
            }

            Sprite = Factory.GetSprite(Key);

        }

        public void Update(GameTime gameTime)
        {
            if((int) gameTime.TotalGameTime.TotalMilliseconds % 100 == 0)
                Sprite.Update();

            //if (FireBall.Active == true)
            //{
            //    FireBall.Update();
            //}
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            //if (FireBall.Active == true)
            //{
            //    FireBall.Draw(spriteBatch);
            //}

            Sprite.Draw(spriteBatch, X, Y);

        }

        public Rectangle GetHitbox()
        {
            Rectangle NewRect = new Rectangle(X, Y, HitBox.Width, HitBox.Height);
            return NewRect;
        }

        public bool isRightFace()
        {
            return RightFace;
        }
    }
}
