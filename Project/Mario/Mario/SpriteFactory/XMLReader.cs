using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Mario
{

    /*
     * Created with help from:
     * https://stackoverflow.com/questions/642293/how-do-i-read-and-parse-an-xml-file-in-c
     * 
     */


    class XMLReader
    {


        private String filename;
        private Dictionary<String, SpriteInfo> dictionary;
        private Texture2D spriteSheet; //this could be stored as an attribute in the root node

        public XMLReader(String myFileName, Dictionary<String, SpriteInfo> myDictionary, Texture2D mySpritesheet)
        {
            filename = myFileName;
            dictionary = myDictionary;
            spriteSheet = mySpritesheet;
            loadDictionary();
 
        }

       
        private void loadDictionary()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(filename);
            String key = "";

            if (xDoc.HasChildNodes) {

                Parse(xDoc, key);

            }
        }

        private Rectangle getRectangle(XmlAttributeCollection attributes) 
        {

            int x = Int32.Parse(attributes.GetNamedItem("x").Value);
            int y = Int32.Parse(attributes.GetNamedItem("y").Value);
            int width = Int32.Parse(attributes.GetNamedItem("width").Value);
            int height = Int32.Parse(attributes.GetNamedItem("height").Value);

            return new Rectangle(x, y, width, height);
        }

        /*
         * Parses the xml data tree. Adds the name of each node to the key until
         * we reach a leaf node. Then adds all leaf nodes in a given sub-tree to 
         * a queue of textures, then associates that queue with a key in the 
         * dictionary. 
         */
        private void Parse(XmlNode root, String key)
        {
            if (!root.Name.Contains("#document"))
            {
                key += root.Name + "_";
            }
            Boolean addToList = false; //we may not even need this boolean 
            // cycle through each child 
            foreach (XmlNode node in root)
            {
                if (!node.NodeType.Equals(XmlNodeType.Comment))
                {
                    //Makes sure we don't add a queue of frames for each frame node
                    if (!node.Name.Equals("frame"))
                    {
                        Parse(node, key);
                    }
                    else
                    {
                        addToList = true;
                        break; //once we find a leaf node, we can assume all nodes of the same parent are leaf nodes
                    }
                }
            }

            // if we are one level above a leaf node, add leaf nodes to list
            if (addToList)
            { 
                Queue<Rectangle> queue = new Queue<Rectangle>();
                foreach (XmlNode node in root)
                {
                    if (!node.NodeType.Equals(XmlNodeType.Comment))
                    {
                        Rectangle textureRectangle = getRectangle(node.Attributes);
                        //This assumes that frame nodes are in correct order
                        queue.Enqueue(textureRectangle);
                    }

                }
                SpriteInfo textureAndFrames = new SpriteInfo(queue, spriteSheet);
                key = key.Substring(0, key.Length - 1); //Delete the last underscore
                dictionary.Add(key, textureAndFrames);

            } 
            
        }



    }
}
