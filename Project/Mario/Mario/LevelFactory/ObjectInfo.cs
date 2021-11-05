using System;
using System.Collections.Generic;
using System.Text;

namespace Mario
{
    class ObjectInfo
    {

        //No need for setters
        public int xValue { get; }
        public int yValue { get; }

        public String className { get; }
        public String typeName { get; }

        public ObjectInfo(String myTypeName, String myClassName, int myXValue, int myYValue)
        {
            className = myClassName;
            typeName = myTypeName;

            //Multiply X and Y values by 16 to scale for pixel sizes
            xValue = myXValue;
            yValue = myYValue;
        }

    }
}
