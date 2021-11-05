using Mario.Blocks;
using Mario.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mario
{
    class ObjectBuilder
    {

        private WorldInfo worldInfo;
        private SpriteFactory spriteFactory;
        private LinkedList<ObjectInfo> objectList;

        public ObjectBuilder(WorldInfo myWorldInfo, SpriteFactory mySpriteFactory, LinkedList<ObjectInfo> myObjectList)
        {
            worldInfo = myWorldInfo;
            spriteFactory = mySpriteFactory;
            objectList = myObjectList;

        }

        public void buildObjects()
        {

            BlockFactory blockFactory = new BlockFactory(spriteFactory);

            foreach (ObjectInfo objectInfo in objectList)
            {
                switch (objectInfo.typeName)
                {
                    case "block":
                        buildBlock(objectInfo, blockFactory);
                        break;

                    case "item":
                        buildItem(objectInfo);
                        break;

                    case "enemy":
                        buildEnemy(objectInfo);
                        break;

                }
            }
        }


        //The reason these methods are split up is because block are implemented with inheritance and other objects use interfaces
        private void buildBlock(ObjectInfo blockInfo, BlockFactory blockFactory)
        {
            //Inheritance
            Block blockToAdd = blockFactory.GetBlock(blockInfo.className, blockInfo.xValue, blockInfo.yValue);

            if (worldInfo.blockList.ContainsKey(blockInfo.xValue))
            {
                LinkedList<Block> currentblockList = worldInfo.blockList[blockInfo.xValue];
                currentblockList.AddLast(blockToAdd);
            }
            else
            {
                LinkedList<Block> newBlockList = new LinkedList<Block>();
                newBlockList.AddLast(blockToAdd);
                worldInfo.blockList.Add(blockInfo.xValue, newBlockList);
            }

        }

        private void buildItem(ObjectInfo itemInfo)
        {
            Type itemType = Type.GetType("Mario." + itemInfo.className);
            IItem itemToAdd = (IItem)Activator.CreateInstance(itemType, spriteFactory, itemInfo.xValue, itemInfo.yValue);

            if (worldInfo.itemList.ContainsKey(itemInfo.xValue))
            {
                //Reflection
                LinkedList<IItem> currentItemList = worldInfo.itemList[itemInfo.xValue];
                currentItemList.AddLast(itemToAdd);
            }
            else
            {
                LinkedList<IItem> newItemList = new LinkedList<IItem>();
                newItemList.AddLast(itemToAdd);
                worldInfo.itemList.Add(itemInfo.xValue, newItemList);
            }


        }

        private void buildEnemy(ObjectInfo enemyInfo)
        {
            Type enemyType = Type.GetType("Mario." + enemyInfo.className);
            IEnemy enemyToAdd = (IEnemy)Activator.CreateInstance(enemyType, spriteFactory, enemyInfo.xValue, enemyInfo.yValue);


            if (worldInfo.enemyList.ContainsKey(enemyInfo.xValue))
            {
                LinkedList<IEnemy> currentEnemyList = worldInfo.enemyList[enemyInfo.xValue];
                currentEnemyList.AddLast(enemyToAdd);
            }
            else
            {
                LinkedList<IEnemy> newEnemyList = new LinkedList<IEnemy>();
                newEnemyList.AddLast(enemyToAdd);
                worldInfo.enemyList.Add(enemyInfo.xValue, newEnemyList);
            }

        }




    }
}
