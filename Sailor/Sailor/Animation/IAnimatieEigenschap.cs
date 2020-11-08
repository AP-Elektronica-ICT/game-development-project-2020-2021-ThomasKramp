using Microsoft.Xna.Framework;
using Sailor.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Animation
{
    interface IAnimatieEigenschap
    {
        public void Check(ITransform transform, Vector2 richting);
    }
}
