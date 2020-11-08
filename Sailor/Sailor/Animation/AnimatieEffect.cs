﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sailor.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Animation
{
    class AnimatieEffect : IDrawCheck
    {
        public void Check(IDrawEffect transform, Vector2 richting)
        {
            if (richting.X == -1) transform.effect = SpriteEffects.FlipHorizontally;
            if (richting.X == 1) transform.effect = SpriteEffects.None;
        }
    }
}
