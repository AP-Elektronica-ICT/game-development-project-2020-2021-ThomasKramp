using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Interfaces
{
    interface IDrawAble : IGameObject
    {
        // Geeft een foutmelding
        // private Texture2D texture { get; set; }
        public Texture2D CurrentTexture { get; set; }
        public void Draw(SpriteBatch spriteBatch) { }
    }
}
