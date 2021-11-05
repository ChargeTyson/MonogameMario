
namespace Mario.Blocks
{
    class BrickBlock : Block
    {

        public BrickBlock(SpriteFactory factory, int x, int y) : base (factory, x, y)
        {
            this.blockSprite = base.blockFactory.GetSprite("Block_Brick");
        }
    }
}
