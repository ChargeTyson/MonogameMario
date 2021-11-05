using Mario.ICommandActions;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mario
{
    class DataManager
    {
        private Game1 MyGame;
        private SpriteFactory factory;
        public DataManager(Game1 game, KeyboardController keyboardController ,GamePadController gamePadController, CollisionController collisionController,SpriteFactory factory)
        {
            MyGame = game;
            this.factory = factory;
            // this coupling is allowed
            // THIS IS MISSION CONTROL.  ENTER ANY ADDITIONAL KEY MAPPINGS HERE. NOTE YOU NEED A NEW CLASS FILE FOR EACH ACTION
            // EACH ACTION CLASS MUST IMPORT GAME CLASS
            // keyboardController.RegisterCommand(Microsoft.Xna.Framework.Input.Keys.D0, new GameExit(MyGame));

            keyboardController.RegisterCommand(Microsoft.Xna.Framework.Input.Keys.Q, new GameExit(MyGame)); // QUIT GAME
            keyboardController.RegisterCommand(Microsoft.Xna.Framework.Input.Keys.Escape, new GameExit(MyGame));
            keyboardController.RegisterCommand(Microsoft.Xna.Framework.Input.Keys.R, new GameReset(MyGame)); // RESET MARIO BACK TO IDLE STANCE

            keyboardController.RegisterCommand(Microsoft.Xna.Framework.Input.Keys.W, new MarioJump(MyGame)); // MARIO JUMP
            keyboardController.RegisterCommand(Microsoft.Xna.Framework.Input.Keys.A, new MarioMoveLeft(MyGame)); // MOVE MARIO LEFT
            keyboardController.RegisterCommand(Microsoft.Xna.Framework.Input.Keys.S, new MarioSquat(MyGame)); // MARIO SQUAT
            keyboardController.RegisterCommand(Microsoft.Xna.Framework.Input.Keys.D, new MarioMoveRight(MyGame)); // MOVE MARIO RIGHT

            keyboardController.RegisterCommand(Microsoft.Xna.Framework.Input.Keys.Up, new MarioJump(MyGame)); // MARIO JUMP
            keyboardController.RegisterCommand(Microsoft.Xna.Framework.Input.Keys.Left, new MarioMoveLeft(MyGame)); // MOVE MARIO LEFT
            keyboardController.RegisterCommand(Microsoft.Xna.Framework.Input.Keys.Down, new MarioSquat(MyGame)); // MARIO SQUAT
            keyboardController.RegisterCommand(Microsoft.Xna.Framework.Input.Keys.Right, new MarioMoveRight(MyGame)); // MOVE MARIO RIGHT

            keyboardController.RegisterCommand(Microsoft.Xna.Framework.Input.Keys.E, new MarioPowerDown(MyGame)); // HURT MARIO IF ALREADY SMALL DIE.
            keyboardController.RegisterCommand(Microsoft.Xna.Framework.Input.Keys.F, new MarioPowerUp(MyGame)); // POWER UP MARIO
            keyboardController.RegisterCommand(Microsoft.Xna.Framework.Input.Keys.D2, new GameReset(MyGame)); // RESET GAME TODO: Implement Mario death
            // keyboardController.RegisterCommand(Microsoft.Xna.Framework.Input.Keys.D2, new MarioDeath(MyGame)); // DIE MARIO

            keyboardController.RegisterCommand(Microsoft.Xna.Framework.Input.Keys.Y, new NextBlock(MyGame)); // CYCLE RIGHT IN ARRAY OF BLOCKS
            keyboardController.RegisterCommand(Microsoft.Xna.Framework.Input.Keys.T, new PreviousBlock(MyGame)); // CYCLE LEFT IN ARRAY OF BLOCKS

            keyboardController.RegisterCommand(Microsoft.Xna.Framework.Input.Keys.D1, new MarioFireFlowerAction(MyGame,factory));// FIRE FLOWER ANIMATION
            keyboardController.RegisterCommand(Microsoft.Xna.Framework.Input.Keys.Z, new MarioFireFlowerAction(MyGame,factory));// FIRE FLOWER ANIMATION
            keyboardController.RegisterCommand(Microsoft.Xna.Framework.Input.Keys.N, new MarioFireFlowerAction(MyGame,factory));// FIRE FLOWER ANIMATION

            keyboardController.RegisterCommand(Microsoft.Xna.Framework.Input.Keys.O, new PreviousEnemy(MyGame)); // SHIFT LEFT ON ENEMY LIST
            keyboardController.RegisterCommand(Microsoft.Xna.Framework.Input.Keys.P, new NextEnemy(MyGame)); // SHIFT RIGHT ON ENEMY LIST

            keyboardController.RegisterCommand(Microsoft.Xna.Framework.Input.Keys.U, new PreviousItem(MyGame)); // Cycle left in items
            keyboardController.RegisterCommand(Microsoft.Xna.Framework.Input.Keys.I, new NextItem(MyGame)); // Cycle right in items

            collisionController.RegisterCommand("MarioBlockHorizontal", new MarioStopMoving(MyGame));
            collisionController.RegisterCommand("MarioBlockVertical", new MarioStopJumping(MyGame));
            collisionController.RegisterCommand("Reset", new GameReset(MyGame));


            //GamePad Controller
            if (Microsoft.Xna.Framework.Input.GamePad.GetState(PlayerIndex.One).IsConnected)
            {
                gamePadController.RegisterCommand("D", new MarioMoveRight(MyGame));
                gamePadController.RegisterCommand("A", new MarioMoveLeft(MyGame));
                gamePadController.RegisterCommand("Jump", new MarioJump(MyGame));
                gamePadController.RegisterCommand("ThrowFireball", new MarioFireFlowerAction(MyGame,factory));
            }

        }


    }
}
