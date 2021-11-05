
namespace Mario.Blocks
{
    class GroundBlock : Block
    {

        public GroundBlock(SpriteFactory factory, int x, int y) : base(factory, x, y)
        {
            this.blockSprite = base.blockFactory.GetSprite("Block_Ground_Middle");
        }
    }
}
