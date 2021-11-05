using System;
namespace Mario.Blocks
{
    class PipeEntrance : Block
    {
        public PipeEntrance(SpriteFactory factory, int x, int y) : base(factory, x, y)
        {
            this.blockSprite = base.blockFactory.GetSprite("Block_Pipe_Entrance");
        }
    }
}
