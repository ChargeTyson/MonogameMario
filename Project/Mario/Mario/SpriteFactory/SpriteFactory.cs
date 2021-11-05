using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Mario
{
    public class SpriteFactory
    {
        private ContentManager content;
        private Dictionary<String, SpriteInfo> factoryTable = new Dictionary<String, SpriteInfo>();



        public SpriteFactory(ContentManager myContent)
        {
            content = myContent;
            LoadFactory();
        }

        private void LoadFactory()
        {
            /*
             * Load each spritesheet from the content loader.
             */
            Texture2D MarioSpritesheet = content.Load<Texture2D>("Mario_Sprites");
            Texture2D GoombaSpritesheet = content.Load<Texture2D>("Goomba_MarioWorld");
            Texture2D RedKoopaSpritesheet = content.Load<Texture2D>("Red_Koopa_Troopa");
            Texture2D GreenKoopaSpritesheet = content.Load<Texture2D>("Green_Koopa_Troopa");
            Texture2D BlockSpritesheet = content.Load<Texture2D>("Blocks");
            Texture2D ItemSpritesheet = content.Load<Texture2D>("Items");
            Texture2D LevelOneOneSpritesheet = content.Load<Texture2D>("Level1-1");

            /*
             * Read the XML file of each character/enemy. The parser can handle different
             * formats of XML file but we isolated them since they differ
             */
            XMLReader MarioReader = new XMLReader("../../../SpriteFactory/XMLSprite/Mario_Sprites_Data.xml", factoryTable, MarioSpritesheet);
            XMLReader GoombaReader = new XMLReader("../../../SpriteFactory/XMLSprite/Goomba_Sprites_Data.xml", factoryTable, GoombaSpritesheet);
            XMLReader RedKoopaReader = new XMLReader("../../../SpriteFactory/XMLSprite/Red_Koopa_Sprites_Data.xml", factoryTable, RedKoopaSpritesheet);
            XMLReader GreenKoopaReader = new XMLReader("../../../SpriteFactory/XMLSprite/Green_Koopa_Sprites_Data.xml", factoryTable, GreenKoopaSpritesheet);
            XMLReader BlockReader = new XMLReader("../../../SpriteFactory/XMLSprite/Block_Sprites_Data.xml", factoryTable, BlockSpritesheet);
            XMLReader ItemReader = new XMLReader("../../../SpriteFactory/XMLSprite/Item_Sprites_Data.xml", factoryTable, ItemSpritesheet);
            XMLReader LevelOneOneReader = new XMLReader("../../../SpriteFactory/XMLSprite/Level_1-1_Sprites_Data.xml", factoryTable, LevelOneOneSpritesheet);
        }

        /*
         * Method gets SpriteInfo with spritesheet and queue of source rectangles.
         */
        public ISprite GetSprite(String key)
        {
            if(factoryTable.TryGetValue(key, out SpriteInfo currentInfo))
            {
                Texture2D currentSpritesheet = currentInfo.spritesheet;
                Queue<Rectangle> currentRectangles = currentInfo.rectangles;
                return new SpriteObject(currentSpritesheet, currentRectangles);
            }
            else // will return a default sprite if the key wasn't in the dictionary
            {
                Texture2D DefaultSprite = content.Load<Texture2D>("Default_Sprite");
                Queue<Rectangle> DefaultQueue = new Queue<Rectangle>();
                DefaultQueue.Enqueue(new Rectangle(0, 0, 20, 20));
                return new SpriteObject(DefaultSprite, DefaultQueue);
            }
        }
    }
}
