using Mario.Blocks;
using Mario.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mario
{
    class WorldInfo
    {

        public Dictionary<int, LinkedList<Block>> blockList { get; set; }
        public Dictionary<int, LinkedList<IItem>> itemList { get; set; }
        public Dictionary<int, LinkedList<IEnemy>> enemyList { get; set; }

        public WorldInfo()
        {

            resetInfo();


        }

        public void resetInfo()
        {
            blockList = new Dictionary<int, LinkedList<Block>>();
            itemList = new Dictionary<int, LinkedList<IItem>>();
            enemyList = new Dictionary<int, LinkedList<IEnemy>>();
        }
    }
}
