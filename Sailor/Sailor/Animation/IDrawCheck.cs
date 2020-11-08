using Microsoft.Xna.Framework;
using Sailor.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Animation
{
    interface IDrawCheck
    {
        public void Check(IDrawEffect transform, Vector2 richting);
    }
}
