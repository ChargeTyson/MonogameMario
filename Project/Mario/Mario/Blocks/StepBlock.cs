
namespace Mario.Blocks
{
    class StepBlock : Block
    {

        public StepBlock(SpriteFactory factory, int x, int y) : base(factory, x, y)
        {
            this.blockSprite = base.blockFactory.GetSprite("Block_Step");
        }
    }
}
