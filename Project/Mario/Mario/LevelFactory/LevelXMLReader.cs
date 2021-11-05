using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Mario
{
    class LevelXMLReader
    {

        private String fileName;
        private LinkedList<ObjectInfo> objectList;

        //We can put the world info object into an array if we want to load multiple worlds at once from one xml file
        public LevelXMLReader(String myFileName, LinkedList<ObjectInfo> myObjectList)
        {

            fileName = myFileName;
            objectList = myObjectList;
            loadObjectList();

        }

        private void loadObjectList()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(fileName);
            XmlNode root = xDoc.FirstChild;

            if (xDoc.HasChildNodes)
            {
                //Initalize the first x to -1, this shuold never be seen
                Parse(root, -1);
            }

        }


        private ObjectInfo getItemInfo(String nodeName, XmlAttributeCollection attributes, int currentX)
        {
            
            int y = 13 - Int32.Parse(attributes.GetNamedItem("y").Value);
            String className = attributes.GetNamedItem("class").Value;

            return new ObjectInfo(nodeName, className, currentX, y);
        }


        ////////////////////////////////////////////////////
        // The XML tree has three levels:
        // <World background="">
        //     <Column x="0"> --! This is the x value
        //         <block y="" class="" />
        //         <block y="" class="" />
        //         <item y="" class="" />
        //         <character y="" class="" />
        //     </Column>
        //     <Column x="1">
        //         <block y="" class="" />
        //     ...
        ////////////////////////////////////////////////////
        private void Parse(XmlNode root, int currentX)
        {
            //Look through all x values under the root
            foreach (XmlNode node in root)
            {
                if (node.Name.Equals("Column"))
                {
                    //If we are at an x value, parse its children
                    Parse(node, Int32.Parse(node.Attributes.GetNamedItem("x").Value));
                }
                else
                {
                    //If we are at an object value, add it to the list
                    ObjectInfo currentObjectInfo = getItemInfo(node.Name, node.Attributes, currentX);
                    objectList.AddLast(currentObjectInfo);
                }
            }
        }



    }
}
