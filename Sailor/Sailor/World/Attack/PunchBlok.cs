using Microsoft.Xna.Framework;
using Sailor.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.World.Attack
{
    class PunchBlok : IGameObject
    {
        public PunchBlok(Vector2 position, Rectangle frame)
        {
            Positie = position;
            Frame = frame;
        }
        public Vector2 Positie { get; set; }
        public Rectangle Frame { get; set; }
    }
}
