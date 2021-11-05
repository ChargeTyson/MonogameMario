using System;
using System.Collections.Generic;
using Mario.Blocks;
using Mario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario
{
    class MovementManager
    {
        //Lists to store all the game objects currently running in the game
        public Dictionary<int, LinkedList<IEnemy>> enemies { get; set; }
        public Dictionary<int, LinkedList<IItem>> items { get; set; }

        // keep track of mario
        private Mario mario;

        //Holds the physics portion of movement
        private static int GRAVITY;
        private int marioXVelocity;
        private int marioYVelocity;

        const int DEFAULT_X_VELOCITY = 5;
        const int DEFAULT_Y_VELOCITY = 0;

        const int GROUND_HEIGHT = 64;

        public MovementManager(Mario mario)
        {
            this.mario = mario;
            this.enemies = new Dictionary<int, LinkedList<IEnemy>>();
            this.items = new Dictionary<int, LinkedList<IItem>>();

            GRAVITY = 10;
            marioXVelocity = DEFAULT_X_VELOCITY;
            marioYVelocity = DEFAULT_Y_VELOCITY;
        }

        public void Update(GameTime gameTime)
        {
            mario.Y += (int)(GRAVITY + marioYVelocity);

            if(!(marioYVelocity >= 0))
            {
                marioYVelocity++;
            } 

            List<int> enemyKeyList = new List<int>(enemies.Keys);
            foreach (int key in enemyKeyList)
            {
                if (enemies.TryGetValue(key, out LinkedList<IEnemy> currentColumn))
                {
                    foreach (IEnemy enemy in currentColumn)
                    {
                        enemy.Y += GRAVITY;

                        if (enemy.Y >= Game1.screenHeight - GROUND_HEIGHT - (enemy.GetHitbox().Height))
                        {
                            enemy.Y = Game1.screenHeight - GROUND_HEIGHT - (enemy.GetHitbox().Height);
                        }
                    }
                }
            }
        }

        public void MoveRight()
        {
            mario.X += marioXVelocity;
        }

        public void MoveLeft()
        {
            mario.X -= marioXVelocity;

            if (mario.X <= 0)
                mario.X = 0;
        }

        public void Jump()
        {
            if (!mario.isJumping)
            {
                mario.isJumping = true;
                marioYVelocity = -26;
            }
           
        }

        public void StopMarioMovement()
        {
        }

        public void StopMarioJump()
        {
            marioYVelocity = 0;
        }
    }
}
