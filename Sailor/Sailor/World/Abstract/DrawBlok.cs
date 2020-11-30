using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sailor.Interfaces;
using Sailor.Interfaces.Animation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.World.Abstract
{
    public abstract class DrawBlok : IGameObject, IDrawObject
    {
        public Vector2 Positie { get; set; }
        public Rectangle Frame { get; set; }
        public Texture2D CurrentTexture { get; set; }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(CurrentTexture, Positie, Frame, Color.White);
        }
    }
}
