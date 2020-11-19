using Microsoft.Xna.Framework;
using Sailor.LoadSprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Interfaces
{
    interface IDrawState
    {
        public Vector2 Positie { get; set; }
        public CharacterState state { get; set; }
    }
}
