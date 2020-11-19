using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.LoadSprites
{
    class LoadForeground
    {
        public Dictionary<ForgroundObjects, List<Texture2D>> textureDic { get; set; }

        public LoadForeground()
        {
            textureDic = new Dictionary<ForgroundObjects, List<Texture2D>>();
        }

        public void LoadSprites(ContentManager Content)
        {
            System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo($"Content\\Foreground");
            List<Texture2D> tempList;
            for (int i = 1; i < directory.GetDirectories().Length; i++)
            {
                tempList = new List<Texture2D>();

                ForgroundObjects fgOject = (ForgroundObjects)i;
                System.IO.DirectoryInfo subDirectory = new System.IO.DirectoryInfo($"Content\\Foreground\\{fgOject.ToString()}");

                int lengte = subDirectory.GetFiles().Length;
                for (int j = 1; j < subDirectory.GetFiles().Length + 1; j++)
                {
                    tempList.Add(Content.Load<Texture2D>($"Foreground\\{fgOject.ToString()}\\{fgOject.ToString()}FG{j}"));
                }
                textureDic.Add(fgOject, tempList);
            }
        }
    }
}
