using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sailor.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Animation
{
    class AnimatieEffect : IAnimatieEigenschap
    {
        // Gaat ervoor zorgen dat de sprite niet spontaan terugdraait
        private SpriteEffects SpriteEffect;

        public void Check(ITransform transform, Vector2 richting)
        {
            switch (richting.X)
            {
                case -1:
                    SpriteEffect = SpriteEffects.FlipHorizontally;
                    break;
                case 1:
                    SpriteEffect = SpriteEffects.None;
                    break;
                default:
                    break;
            }
            transform.effect = SpriteEffect;
        }
    }
}
