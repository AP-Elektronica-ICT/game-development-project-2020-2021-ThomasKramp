using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Interfaces.Commands
{
    interface IThrower : IGameObject
    {
        public bool Throw { get; set; }
        public int Levens { get; set; }
        public SpriteEffects effect { get; set; }
    }
}
