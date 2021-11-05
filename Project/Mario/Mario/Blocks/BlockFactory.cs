using System;
using System.Collections.Generic;
using System.Text;

namespace Mario.Blocks
{
    class BlockFactory
    {
        private SpriteFactory spriteFactory;
        private const int BLOCK_SCALER = 32; //this is how many pixels wide/tall a block is

        public BlockFactory(SpriteFactory mySpriteFactory)
        {
            spriteFactory = mySpriteFactory;
        }

        public Block GetBlock(String blockName, int xCoordinate, int yCoordinate)
        {
            //xCoordinate and yCoordinate come in as column number and y-levels of map, need scaled to pixel count for drawing
            //TODO: Uncomment return statements and remove bottom return statement when possible.
            switch (blockName)
            {
                case "Block_Lucky_Unbroken":
                    return new LuckyBlock(spriteFactory, xCoordinate * BLOCK_SCALER, yCoordinate * BLOCK_SCALER);

                case "Block_Lucky_Broken":
                    return new BrokenLuckyBlock(spriteFactory, xCoordinate * BLOCK_SCALER, yCoordinate * BLOCK_SCALER);

                case "Block_Brick":
                    return new BrickBlock(spriteFactory, xCoordinate * BLOCK_SCALER, yCoordinate * BLOCK_SCALER);

                case "Block_Ground":
                    return new GroundBlock(spriteFactory, xCoordinate * BLOCK_SCALER, yCoordinate * BLOCK_SCALER);

                case "Block_Step":
                    return new StepBlock(spriteFactory, xCoordinate * BLOCK_SCALER, yCoordinate * BLOCK_SCALER);

                case "Block_Pipe_Tube":
                    return new PipeTube(spriteFactory, xCoordinate * BLOCK_SCALER, yCoordinate * BLOCK_SCALER);

                case "Block_Pipe_Entrance":
                    return new PipeEntrance(spriteFactory, xCoordinate * BLOCK_SCALER, yCoordinate * BLOCK_SCALER);

                default: return new GroundBlock(spriteFactory, xCoordinate * BLOCK_SCALER, yCoordinate * BLOCK_SCALER);

            }

        }




    }
}
