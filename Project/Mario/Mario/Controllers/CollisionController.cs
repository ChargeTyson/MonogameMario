using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;


//Holds the list of all potential collisions that may occur in game.
namespace Mario
{
    class CollisionController
    {
        private Game1 MyGame;
        private Dictionary<String, ICommand> CollisionActions;

        public CollisionController(Game1 game)
        {
            this.MyGame = game;
            this.CollisionActions = new Dictionary<String, ICommand>();
        }

        //loads all the collision commands into the table when the game is first initialized
        public void RegisterCommand(String key, ICommand value)
        {
            CollisionActions.Add(key, value);
        }

        //triggers the collision events based on a list of keys
        //key naming convention Object1 + Object2 + Direction (optional)
        //example: Mario_Goomba_Vertical
        //example: RedKoopaTroopa_GreenKoopaTroopa (no direction needed)
        public void CollisionEvent(List<String> keys)
        {
            foreach(String key in keys)
            {
                CollisionActions[key].Execute();
            }
        }

    }
}
