using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Interfaces.Animation
{
    interface IDrawDynamic : IDrawObject
    {
        public bool TextureReset { get; set; }
    }
}
