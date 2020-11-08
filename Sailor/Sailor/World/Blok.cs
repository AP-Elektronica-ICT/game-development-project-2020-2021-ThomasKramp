using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.World
{
    public class Blok
    {
        private Texture2D texture { get; set; }
        public Vector2 Positie { get; set; }
        public Rectangle rectangle { get; set; }

        public Blok(Texture2D blokTexture, Vector2 positie)
        {
            texture = blokTexture;
            Positie = positie;
            rectangle = new Rectangle(0,0, texture.Width, texture.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Positie, Color.White);
        }
    }
}
