using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mario
{
    class MarioFireFlowerAction : ICommand
    {
        private Game1 MyGame;
        private SpriteFactory factory;
        public MarioFireFlowerAction(Game1 game,SpriteFactory factory)
        {
            MyGame = game;
            this.factory = factory;
        }

        public void Execute()
        {
            List<int> MarioData= MyGame.mario.MarioFireFlowerAction();


            MyGame.projectileController.AddProjectile(new FireBall(MarioData[0],MarioData[1],MarioData[2],factory));
        }
    }
}
