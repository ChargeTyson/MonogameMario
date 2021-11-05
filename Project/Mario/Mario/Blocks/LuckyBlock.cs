
namespace Mario.Blocks
{
    class LuckyBlock : Block
    {

        public LuckyBlock(SpriteFactory factory, int x, int y) : base(factory, x, y)
        {
            this.blockSprite = base.blockFactory.GetSprite("Block_Lucky_Unbroken");
        }

        public override void Update()
        {
            this.blockSprite.Update();
        }
    }
}
