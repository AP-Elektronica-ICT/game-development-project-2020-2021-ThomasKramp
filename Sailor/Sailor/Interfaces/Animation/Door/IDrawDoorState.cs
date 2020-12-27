using Microsoft.Xna.Framework;
using Sailor.LoadSprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Interfaces.Animation.Door
{
    interface IDrawDoorState : IGameObject
    {
        public Vector2 Positie { get; set; }
        public Rectangle Frame { get; set; }
        public DoorState State { get; set; }
    }
}
