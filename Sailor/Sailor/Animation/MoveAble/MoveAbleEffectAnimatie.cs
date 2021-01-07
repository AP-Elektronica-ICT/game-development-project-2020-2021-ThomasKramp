using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sailor.Interfaces.Animation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Animation.MoveAble
{
    public class MoveAbleEffectAnimatie
    {
        public void Update(IDrawEffect transform, Vector2 richting)
        {
            if (richting.X < 0) transform.effect = SpriteEffects.FlipHorizontally;
            if (richting.X > 0) transform.effect = SpriteEffects.None;
        }
    }
}
