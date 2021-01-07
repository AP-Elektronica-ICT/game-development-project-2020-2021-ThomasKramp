using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Interfaces
{
    public interface IGameObject
    {
        public Vector2 Positie { get; set; }
        public Rectangle Frame { get; set; }
    }
}
