using Microsoft.Xna.Framework;
using Sailor.LoadSprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Interfaces.Animation
{
    interface IDrawDoorState
    {
        public Vector2 Positie { get; set; }
        public DoorState state { get; set; }
    }
}
