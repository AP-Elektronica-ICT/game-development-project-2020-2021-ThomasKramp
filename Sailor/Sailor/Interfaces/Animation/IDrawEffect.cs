using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sailor.LoadSprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Interfaces.Animation
{
    interface IDrawEffect
    {
        public Vector2 Positie { get; set; }
        public SpriteEffects effect { get; set; }
    }
}
