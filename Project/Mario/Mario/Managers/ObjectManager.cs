using Mario.Blocks;
using Mario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mario
{
    class ObjectManager
    {
        //Lists to store all the game objects currently running in the game
        public Dictionary<int, LinkedList<IEnemy>> Enemies { get; set; }
        public Dictionary<int, LinkedList<Block>> Blocks { get; set; }
        public Dictionary<int, LinkedList<IItem>> Items { get; set; }
        public List<ILevel> LevelSections { get; set; }


        private int EnemyIndex;
        private int BlockIndex;
        private int ItemIndex;

        public ObjectManager(WorldInfo worldInfo)
        {

            Enemies = worldInfo.enemyList;
            Blocks = worldInfo.blockList;
            Items = worldInfo.itemList;
            LevelSections = new List<ILevel>();
            EnemyIndex = 0;
            BlockIndex = 0;
            ItemIndex = 0;
        }



        //Draw method loops through each list and calls the draw method from each object
        public void Draw(SpriteBatch spriteBatch)
        {


            /* This is how the Draw (and very similarly Update) will operate in the actual game
             * It will iterate through the whole list to draw (and update) each object
             * for this sprint however we only need to print one object */
            //Draw items
            List<int> itemsKeyList = new List<int>(Items.Keys);
            foreach (int key in itemsKeyList)
            {
                if (Items.TryGetValue(key, out LinkedList<IItem> currentColumn))
                {
                    foreach (IItem item in currentColumn)
                    {
                        item.Draw(spriteBatch);
                    }
                }
            }

            //Draw blocks
            List<int> blockKeyList = new List<int>(Blocks.Keys);
            foreach (int key in blockKeyList)
            {
                if (Blocks.TryGetValue(key, out LinkedList<Block> currentColumn))
                {
                    foreach (Block block in currentColumn)
                    {
                        block.Draw(spriteBatch);
                    }
                }
            }


            //Draw enemies
            List<int> enemyKeyList = new List<int>(Enemies.Keys);
            foreach (int key in enemyKeyList)
            {
                if (Enemies.TryGetValue(key, out LinkedList<IEnemy> currentColumn))
                {
                    foreach (IEnemy enemy in currentColumn)
                    {
                        enemy.Draw(spriteBatch);
                    }
                }
            }

            foreach(ILevel LevelObject in LevelSections)
            {
                LevelObject.Draw(spriteBatch);
            }

        }

        //Update method loops through each list and calls the update method for each object
        public void Update(GameTime gameTime)
        {
            //Update items
            List<int> itemsKeyList = new List<int>(Items.Keys);
            foreach (int key in itemsKeyList)
            {
                if (Items.TryGetValue(key, out LinkedList<IItem> currentColumn))
                {
                    List<IItem> ItemsToRemove = new List<IItem>();
                    foreach (IItem item in currentColumn)
                    {
                        if ((int)gameTime.TotalGameTime.TotalMilliseconds % 200 == 0)
                        {
                            item.Update();
                        }
                        if(item.isDeletable == true)
                        {
                            ItemsToRemove.Add(item);
                        }
                    }
                    foreach(IItem remove in ItemsToRemove)
                    {
                        currentColumn.Remove(remove);
                    }
                }
            }
            

            //Update enemies
            List<int> enemyKeyList = new List<int>(Enemies.Keys);
            Dictionary<Vector2, IEnemy> enemiesToMove = new Dictionary<Vector2, IEnemy>();
            
            foreach (int key in enemyKeyList)
            {
                if (Enemies.TryGetValue(key, out LinkedList<IEnemy> currentColumn))
                {
                    List<IEnemy> EnemiesToRemove = new List<IEnemy>();
                    foreach (IEnemy enemy in currentColumn)
                    {
                        enemy.Update();

                        if (enemy.isDeletable)
                        {
                            EnemiesToRemove.Add(enemy);
                        }

                        //if the enemy moves out of its column, it's put in a
                        //temporary dictionary that will be moved to a new column
                        //outside this loop
                        else if(enemy.X / 32 != key)
                        {
                            enemiesToMove.Add(new Vector2( enemy.X / 32, key), enemy);
                        }
                    }
                    foreach (IEnemy remove in EnemiesToRemove)
                    {
                        currentColumn.Remove(remove);
                    }
                }
            }

            //loop to move all enemies to their correct column for collision
            foreach(Vector2 KeyPair in enemiesToMove.Keys)
            {
                if (!Enemies.ContainsKey((int)KeyPair.X))
                {
                    Enemies.Add((int)KeyPair.X, new LinkedList<IEnemy>());
                }
                Enemies[(int)KeyPair.X].AddLast(enemiesToMove[KeyPair]);
                Enemies[(int)KeyPair.Y].Remove(enemiesToMove[KeyPair]);
            }
            
        }

        //These next few methods are only for Sprint 2
        public void NextEnemy()
        {
            EnemyIndex++;
            if(EnemyIndex >= Enemies.Count)
            {
                EnemyIndex = 0;
            }
        }
        public void NextBlock()
        {
            BlockIndex++;
            if (BlockIndex >= Blocks.Count)
            {
                BlockIndex = 0;
            }
        }
        public void NextItem()
        {
            ItemIndex++;
            if (ItemIndex >= Items.Count)
            {
                ItemIndex = 0;
            }
        }

        public void PreviousEnemy()
        {
            EnemyIndex--;
            if (EnemyIndex < 0)
            {
                EnemyIndex = Enemies.Count - 1;
            }
        }
        public void PreviousBlock()
        {
            BlockIndex--;
            if (BlockIndex < 0)
            {
                BlockIndex = Blocks.Count - 1;
            }
        }
        public void PreviousItem()
        {
            ItemIndex--;
            if (ItemIndex < 0)
            {
                ItemIndex = Items.Count - 1;
            }
        }
    }
}