using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.LoadSprites
{
    class LoadBackground
    {
        public List<Texture2D> textureList { get; set; }

        public LoadBackground()
        {
            textureList = new List<Texture2D>();
        }

        public void LoadSprites(ContentManager Content)
        {
            System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo($"Content\\Background\\Tile");
            for (int i = 1; i <= directory.GetFiles().Length; i++)
            {
                textureList.Add(Content.Load<Texture2D>($"Background\\Tile\\TileBG{i}"));
            }
        }
    }
}
