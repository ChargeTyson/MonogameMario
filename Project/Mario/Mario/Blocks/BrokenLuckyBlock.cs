
namespace Mario.Blocks
{
    class BrokenLuckyBlock : Block
    {

        public BrokenLuckyBlock(SpriteFactory factory, int x, int y) : base(factory, x, y)
        {
            this.blockSprite = base.blockFactory.GetSprite("Block_Lucky_Broken");
        }
    }
}
