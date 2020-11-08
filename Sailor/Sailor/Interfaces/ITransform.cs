using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sailor.LoadSprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Interfaces
{
    public interface ITransform
    {
        public Vector2 positie { get; set; }
        public Rectangle frame { get; set; }
        public SpriteEffects effect { get; set; }
        public CharacterState state { get; set; }
    }
}
