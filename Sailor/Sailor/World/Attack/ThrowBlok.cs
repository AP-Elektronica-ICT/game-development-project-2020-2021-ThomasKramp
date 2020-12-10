using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sailor.Detection;
using Sailor.World.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.World.Attack
{
    class ThrowBlok : SpecialDrawBlok
    {
        public ThrowBlok(Texture2D blokTexture, Vector2 positie, SpriteEffects effect)
        {
            CurrentTexture = blokTexture;
            this.Positie = positie;
            Frame = new Rectangle(0, 0, CurrentTexture.Width, CurrentTexture.Height);
            this.effect = effect;
        }

        public override void Update(GameTime gameTime, List<DrawBlok> Surroundings, List<DynamicBlok> Targets)
        {
            if (effect == SpriteEffects.None) richting.X = 1;
            else if (effect == SpriteEffects.FlipHorizontally) richting.X = -1;
            BasicRotation++;
            if (CollisionDetection.LeftCollide(this, richting, Surroundings))
            {
                AttackDetection.LeftCollide(this, Targets);
                Surroundings.Remove(this);
            } else if (CollisionDetection.RightCollide(this, richting, Surroundings))
            {
                AttackDetection.RightCollide(this, Targets);
                Surroundings.Remove(this);
            }
            base.Update(gameTime, Surroundings, Targets);
        }
    }
}
