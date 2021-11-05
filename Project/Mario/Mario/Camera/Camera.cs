using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Mario
{
    //created with help from https://www.youtube.com/watch?v=C90-LytYM7w&ab_channel=CodingMadeEasy
    class Camera
    {
        Vector2 position;
        Matrix viewMatrix;
        private Mario marioInstance;
        public Matrix ViewMatrix
        {
            get { return viewMatrix;  }
        }

        public int ScreenWidth
        {
            get { return Game1.screenWidth;  }
        }

        public int ScreenHeight
        {
            get { return Game1.screenWidth;  }
        }
        public Camera(Mario player)
        {
            marioInstance = player;
        }

        public void Update()
        {
            position.X = marioInstance.X - (ScreenWidth / 2);
          
            if (position.X < 0)
                position.X = 0;

            if (marioInstance.X < 6720 - (ScreenWidth / 2))
                viewMatrix = Matrix.CreateTranslation(new Vector3(-position, 0));

        }
    }
}
