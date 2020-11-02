using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.LoadSprites
{
    class LoadForeground
    {
        public List<Texture2D> textureList { get; set; }

        public LoadForeground()
        {
            textureList = new List<Texture2D>();
        }

        public void LoadSprites(ContentManager Content)
        {
            System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo($"Content\\Foreground\\Tile");
            for (int i = 1; i <= directory.GetFiles().Length; i++)
            {
                textureList.Add(Content.Load<Texture2D>($"Foreground\\Tile\\TileFG{i}"));
            }
        }
    }
}
