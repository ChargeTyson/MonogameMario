using System;
using System.Collections.Generic;
using System.Text;

namespace Mario
{
    class BlockInfo
    {

        //No need for setters
        public int xValue { get; }
        public int yValue { get; }

        public String className { get; }

        public BlockInfo(String myClassName, int myXValue, int myYValue)
        {
            className = myClassName;

            //Multiply X and Y values by 16 to scale for pixel sizes
            xValue = myXValue;
            yValue = myYValue;
        }

    }
}
