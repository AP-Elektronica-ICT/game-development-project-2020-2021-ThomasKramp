using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sailor.LoadSprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Interfaces
{
    interface IDrawEffect
    {
        public Vector2 positie { get; set; }
        public SpriteEffects effect { get; set; }
        public CharacterState state { get; set; }
    }
}
