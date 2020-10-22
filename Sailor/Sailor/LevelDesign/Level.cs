using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sailor.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.LevelDesign
{
    class Level
    {
        public List<Texture2D> texture;
        public byte[,] tileArray = new Byte[,]
        {
            {1,1,1,0,0,0 },
            {0,0,0,0,0,0 },
            {1,0,1,0,1,0 },
            {0,1,0,1,0,1 },
        };

        private Blok[,] blokArray = new Blok[4,6];

        public Level(List<Texture2D> texture)
        {
            this.texture = texture;
        }
    }
}
