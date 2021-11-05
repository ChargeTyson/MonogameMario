using Mario.Blocks;
using Mario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Mario
{
    class LevelFactory
    {
        private ContentManager content;
        private SpriteFactory spriteFactory;

        private SpriteBatch spriteBatch;
        private Texture2D background;

        private WorldInfo worldInfo;



        public LevelFactory(ContentManager myContent, SpriteFactory mySpriteFactory, SpriteBatch mySpriteBatch, WorldInfo myWorldInfo)
        {
            content = myContent;
            spriteFactory = mySpriteFactory;
            spriteBatch = mySpriteBatch;
            worldInfo = myWorldInfo;
            loadFactory();
        }

        public void reload()
        {
            loadFactory();
        }

        private void loadFactory()
        {

            worldInfo.resetInfo();

            LinkedList<ObjectInfo> objectList = new LinkedList<ObjectInfo>();
            LevelXMLReader LevelReader = new LevelXMLReader("../../../LevelFactory/WorldInfo/World1-1.xml", objectList);

            //Should this be handled elsewhere?
            //https://www.deviantart.com/banjo2015/art/Paper-Mario-Background-775952503
            background = content.Load<Texture2D>("background");

            ObjectBuilder objectBuilder = new ObjectBuilder(worldInfo, spriteFactory, objectList);
            objectBuilder.buildObjects();

        }

        //This should be handled elsewhere....
        public void DrawBackground()
        {
            spriteBatch.Begin();

            spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.White);

            spriteBatch.End();

        }








    }
}
