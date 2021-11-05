using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Mario.Blocks;

using System.Collections.Generic;
using Mario.Interfaces;
using System.Diagnostics;

using System;
using System.Diagnostics;

namespace Mario
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        internal KeyboardController keyboardController;
        GamePadController GamePadController;
        internal Mario mario;
        SpriteFactory SpriteFactory;
        LevelFactory LevelFactory;
        internal ObjectManager Manager;
        private WorldInfo ObjectListInfo;
        internal MovementManager movementManager;
        private KeyboardState OldState = Keyboard.GetState();
        internal CollisionDetector CManager;
        internal CollisionController CController;
        internal ProjectileController projectileController;

        public static int coinCount; // Holds the number of coins collected in the level

        // Used for Sprint 2, timer to keep keys from being executed too often
        public GameTime gt;

        private Camera camera;
        public static int screenHeight = 448;
        public static int screenWidth = 796;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferHeight = screenHeight;
            _graphics.PreferredBackBufferWidth = screenWidth;
            _graphics.ApplyChanges();
            keyboardController = new KeyboardController(this);
            GamePadController = new GamePadController(this);
            CController = new CollisionController(this);
            

            base.Initialize();
            this.Reset();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);         
            SpriteFactory = new SpriteFactory(Content);
            DataManager dataManager = new DataManager(this, keyboardController, GamePadController, CController, SpriteFactory);
            ObjectListInfo = new WorldInfo();
            LevelFactory = new LevelFactory(Content, SpriteFactory, _spriteBatch, ObjectListInfo);
            Manager = new ObjectManager(ObjectListInfo);
            projectileController = new ProjectileController();

        }

        protected override void Update(GameTime gameTime)
        {
            // Used as timer for keys
            gt = gameTime;

            KeyboardState NewState = Keyboard.GetState();

            CManager.Update();

            GamePadController.Update();
            keyboardController.Update();
            projectileController.Update();


            if (OldState.IsKeyUp(Keys.F) && NewState.IsKeyDown(Keys.F)){
                keyboardController.Set.Clear();
            }
            
            mario.Update(gameTime);
            camera.Update();
            Manager.Update(gameTime);

            OldState = NewState;

            movementManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.CornflowerBlue);

            LevelFactory.DrawBackground();


            _spriteBatch.Begin(transformMatrix: camera.ViewMatrix);

            // TODO: Add your drawing code here

            Manager.Draw(_spriteBatch);
            projectileController.Draw(_spriteBatch);
            mario.Draw(_spriteBatch);

            _spriteBatch.End();

            Debug.WriteLine("Coins: " + coinCount);

            base.Draw(gameTime);

        }

        public void Reset() // this will be refactored after sprint 2. isolating the loading here
        {

            //INITALIZE CLASSES BELOW
            mario = new Mario(SpriteFactory, keyboardController);
            camera = new Camera(mario);
            coinCount = 0;

            LevelFactory.reload();

            //Initialize ObjectManager
            Manager = new ObjectManager(ObjectListInfo);
            movementManager = new MovementManager(mario);

            // Loads new collision manager
            CManager = new CollisionDetector(mario, Manager, CController);

            // Loads all Items into the object manager
            Manager.Items = ObjectListInfo.itemList;

            // Loads all Blocks into the object manager
            Manager.Blocks = ObjectListInfo.blockList;

            ILevel SectionOne = new Level1_1A(SpriteFactory, 0, 12);

            Manager.LevelSections.Add(SectionOne);

            //Loads all Enemies into the object manager
            Manager.Enemies = ObjectListInfo.enemyList;

            //Adds the Items into the Movement Manager
            movementManager.items = ObjectListInfo.itemList;

            //Adds the Enemies into the Movement Manager
            movementManager.enemies = ObjectListInfo.enemyList;


        }
    }
}
