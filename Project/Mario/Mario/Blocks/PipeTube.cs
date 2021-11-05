using System;
namespace Mario.Blocks
{
    class PipeTube : Block
    {
        public PipeTube(SpriteFactory factory, int x, int y) : base(factory, x, y)
        {
            this.blockSprite = base.blockFactory.GetSprite("Block_Pipe_Tube");
        }
    }
}
