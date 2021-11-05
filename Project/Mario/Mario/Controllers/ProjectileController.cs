using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;


namespace Mario
{
    class ProjectileController
    {
        private List<IProjectile> ActiveProjectiles;
        private SpriteBatch spriteBatch;

        //Consider adding an add object method to list.

        public void AddProjectile(IProjectile projectile)
        {
            ActiveProjectiles.Add(projectile);
        }
        public ProjectileController()
        {
            ActiveProjectiles = new List<IProjectile>();
        }


        public void Update()
        {
            foreach(IProjectile projectile in ActiveProjectiles)
            {
                if (projectile.isActive())
                {
                    projectile.Update();
                }
                
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IProjectile projectile in ActiveProjectiles)
            {

                if (projectile.isActive())
                {
                    projectile.Draw(spriteBatch);
                }
                
            }
        }



    }
}
