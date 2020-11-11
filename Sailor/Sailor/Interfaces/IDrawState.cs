using Microsoft.Xna.Framework;
using Sailor.LoadSprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Interfaces
{
    interface IDrawState
    {
        public Vector2 positie { get; set; }
        public CharacterState state { get; set; }
    }
}
