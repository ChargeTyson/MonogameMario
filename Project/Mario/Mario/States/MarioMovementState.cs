using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mario
{
    class MarioMovementState
    {

        public string IdleRight()
        {
            return "_Idle_Right";  //change velocity to something reasonable later
        }
        public string IdleLeft()
        {
            return "_Idle_Left";
        }
        public string RunRight()
        {
            return "_Run_Right";  //change velocity to something reasonable later
        }
        public string RunLeft()
        {
            return "_Run_Left";  //change velocity to something reasonable later
        }

        public string FireBallThrowLeft()
        {
            return "_Throw_Left";
        }
        public string FireBallThrowRight()
        {
            return "_Throw_Right";
        }

        public string JumpRight()
        {
            return "_Jump_Right";
        }
        public string JumpLeft()
        {
            return "_Jump_Left";
        }
        public string SquatLeft()
        {
            return "_Crouch_Left";
        }
        public string SquatRight()
        {
            return "_Crouch_Right";
        }
    }
}
