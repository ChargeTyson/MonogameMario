using Mario.Blocks;
using Mario.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mario
{
    class CollisionDetector
    {
        private Mario Player;
        private ObjectManager Manager;
        private int InvincibleTimer;
        const int TIMELIMIT=30;
        private List<String> Keys;
        private CollisionController Controller;
        private Rectangle MarioHitBox;

        public CollisionDetector(Mario myPlayer, ObjectManager myManager, CollisionController myController)
        {
            Player = myPlayer;
            Manager = myManager;
            Keys = new List<String>();
            Controller = myController;
            MarioHitBox = Player.GetHitbox();
        }


        public void Update()
        {
            MarioHitBox = Player.GetHitbox();
            int MarioColumnOne = MarioHitBox.X / 32 - 1;
            int MarioColumnTwo = MarioHitBox.X / 32;
            int MarioColumnThree = MarioHitBox.X / 32 + 1;

            CheckMarioToEnemyCollisions(MarioColumnOne);   //abstracting the complexity to another method
            CheckMarioToEnemyCollisions(MarioColumnTwo);
            CheckMarioToEnemyCollisions(MarioColumnThree);

            CheckMarioToItemCollisions(MarioColumnOne);   //abstracting the complexity to another method
            CheckMarioToItemCollisions(MarioColumnTwo);
            CheckMarioToItemCollisions(MarioColumnThree);

            CheckMarioToBlockCollisions(MarioColumnOne);   //abstracting the complexity to another method
            CheckMarioToBlockCollisions(MarioColumnTwo);
            CheckMarioToBlockCollisions(MarioColumnThree);

            CheckMarioToLevelCollisions();

            if (InvincibleTimer != TIMELIMIT)
            {
                InvincibleTimer++;
            }
            CheckEnemyCollision();
            //check items

            if(Player.Y > 400 || Player.Y < -200)
            {
                Keys.Add("Reset");
            }

            Controller.CollisionEvent(Keys);

            Keys.Clear();
        }
        private void CheckMarioToEnemyCollisions(int column)
        {

            if (Manager.Enemies.TryGetValue(column, out LinkedList<IEnemy> currentEnemyColumn))
                {
                foreach (IEnemy enemy in currentEnemyColumn)
                    {
                    Rectangle Intersection = Rectangle.Intersect(MarioHitBox, enemy.GetHitbox());
                    if(Intersection.Width >= Intersection.Height && Intersection.Y > MarioHitBox.Center.Y && InvincibleTimer == TIMELIMIT)
                    {
                        enemy.Kill();
                    }
                    else if (MarioHitBox.Intersects(enemy.GetHitbox()) && InvincibleTimer == TIMELIMIT)
                    {
                        Player.DecrementMarioHealth();
                        InvincibleTimer = 0;
                    }
                }
            }

        }

        private void CheckMarioToItemCollisions(int column)
        {
            //Deal with items
            LinkedList<IItem> itemsToRemove = new LinkedList<IItem>();
            if (Manager.Items.TryGetValue(column, out LinkedList<IItem> currentItemColumn))
            {
                foreach (IItem item in currentItemColumn)
                {
                    if (MarioHitBox.Intersects(item.GetHitbox()))
                    {
                        if (item.GetType().Equals(Type.GetType("Mario.Mushroom")))
                        {
                            Player.IncrementMarioHealth();
                            item.isDeletable = true;
                        }
                        if (item.GetType().Equals(Type.GetType("Mario.Coin")))
                        {
                            Game1.coinCount++;
                            //Trying to remove the item in the loop will crash the program
                            item.isDeletable = true;
                        }
                        if (item.GetType().Equals(Type.GetType("Mario.FireFlower")))
                        {
                            Player.SetFireFlower();
                            item.isDeletable = true;
                        }
                        if (item.GetType().Equals(Type.GetType("Mario.Mushroom1Up")))
                        {
                            item.isDeletable = true;
                        }
                    }
                }
            }

        }

        private void CheckMarioToBlockCollisions(int column)
        {

            if (Manager.Blocks.TryGetValue(column, out LinkedList<Block> currentColumn))
            {
                foreach (Block block in currentColumn)
                {
                    if (MarioHitBox.Intersects(block.GetHitbox()))
                    {
                        //set marios gravity or dy to 0 so he does not fade through the ground
                        //Delete item after mario touches it

                        //rectangle of the intersection between the two rectangles
                        Rectangle Intersection = Rectangle.Intersect(MarioHitBox, block.GetHitbox());

                        //if it's a horizontal collision and mario is still facing the same direction this stops him from moving

                        if (Intersection.Width < Intersection.Height)
                        {
                            Keys.Add("MarioBlockHorizontal");
                            if (Player.isRightFace() == true)
                            {
                                Player.X = block.X - MarioHitBox.Width;
                            }
                            else
                            {
                                Player.X = block.X + block.GetHitbox().Width;
                            }
                        }

                        else if (Intersection.Width >= Intersection.Height)
                        {
                            Keys.Add("MarioBlockVertical");
                            if (Player.Y > block.Y)
                            {
                                Player.Y = block.Y + block.GetHitbox().Height + 5;
                            }
                            else
                            {
                                Keys.Add("MarioBlockVertical");
                                if(Player.Y > block.Y)
                                {
                                    Player.Y = block.Y + block.GetHitbox().Height + 5;
                                }
                                else
                                {
                                    Player.Y = block.Y - MarioHitBox.Height - 9;
                                    Player.isJumping = false;
                                }
                            }
                            Player.isJumping = false;
                        }
                    }
                        
                    Controller.CollisionEvent(Keys);

                    Keys.Clear();
                }
            }

        }

        private void CheckMarioToLevelCollisions()
        {
            foreach(ILevel LevelObject in Manager.LevelSections)
            {
                Rectangle LevelHitBox = LevelObject.GetHitbox();
                if (MarioHitBox.Intersects(LevelHitBox))
                {
                    Rectangle Intersection = Rectangle.Intersect(MarioHitBox, LevelHitBox);
                    if (Intersection.Width < Intersection.Height)
                    {
                        Keys.Add("MarioBlockHorizontal");
                        if (Player.isRightFace() == true)
                        {
                            Player.X = LevelHitBox.X - MarioHitBox.Width;
                        }
                        else
                        {
                            Player.X = LevelHitBox.X + LevelHitBox.Width;
                        }
                    }

                    else if (Intersection.Width > Intersection.Height)
                    {
                        Player.Y -= Intersection.Height + 9;
                        Player.isJumping = false;
                    }

                }

            }
        }

        private void CheckEnemyCollision()
        {
            foreach(int key in Manager.Enemies.Keys)
            {
                foreach(IEnemy enemy in Manager.Enemies[key])
                {
                    //checks just the column either in front of them or behind them depending on which direction they face
                    int nextColumn = key + enemy.direction;
                    Rectangle EnemyHitbox = enemy.GetHitbox();
                    Rectangle Collision;
                    if (Manager.Enemies.TryGetValue(nextColumn, out LinkedList<IEnemy> currentEnemyColumn))
                    {
                        foreach (IEnemy target in Manager.Enemies[nextColumn])
                        {
                            Rectangle TargetHitbox = target.GetHitbox();
                            Collision = Rectangle.Intersect(EnemyHitbox, TargetHitbox);
                            if (Collision.Width < Collision.Height)
                            {
                                enemy.Collision();
                                enemy.X += Rectangle.Intersect(EnemyHitbox, TargetHitbox).Width * enemy.direction;
                            }
                        }

                    }

                    //checks the current column for block collision
                    if (Manager.Blocks.TryGetValue(nextColumn, out LinkedList<Block> nextBlockColumn))
                    {
                        foreach (Block target in Manager.Blocks[nextColumn])
                        {
                            Rectangle TargetHitbox = target.GetHitbox();
                            Collision = Rectangle.Intersect(EnemyHitbox, TargetHitbox);
                            if (Collision.Width < Collision.Height)
                            {
                                enemy.Collision();
                                enemy.X += Rectangle.Intersect(EnemyHitbox, TargetHitbox).Width * enemy.direction;

                            }
                        }

                    }

                    //checks the next column for collisions
                    if (Manager.Blocks.TryGetValue(key, out LinkedList<Block> currentBlockColumn))
                    {
                        foreach (Block target in Manager.Blocks[key])
                        {
                            Rectangle TargetHitbox = target.GetHitbox();
                            Collision = Rectangle.Intersect(EnemyHitbox, TargetHitbox);
                            if (Collision.Width < Collision.Height)
                            {
                                enemy.Collision();
                                enemy.X += Rectangle.Intersect(EnemyHitbox, TargetHitbox).Width * enemy.direction;

                            }
                        }

                    }
                }
            }

        }

        private void CheckItemCollision()
        {
            //items don't move yet
        }

    }
}
