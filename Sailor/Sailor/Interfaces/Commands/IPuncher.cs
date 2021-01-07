using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Interfaces.Commands
{
    public interface IPuncher : IGameObject
    {
        public bool Punch { get; set; }
        public int Levens { get; set; }
        public SpriteEffects effect { get; set; }
    }
}
