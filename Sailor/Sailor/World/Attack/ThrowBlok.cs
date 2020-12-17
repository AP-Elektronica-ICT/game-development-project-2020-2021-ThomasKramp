using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sailor.Commands.Move;
using Sailor.Detection;
using Sailor.World.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.World.Attack
{
    class ThrowBlok : DynamicBlok
    {
        MoveCommand moveCommand;
        public ThrowBlok(Vector2 positie, SpriteEffects effect)
        {
            Random random = new Random();
            CurrentTexture = Game1.BottleTextures[random.Next(0, 3)];
            this.Positie = positie;
            Frame = new Rectangle(0, 0, CurrentTexture.Width, CurrentTexture.Height);
            this.effect = effect;
            //moveCommand = new ThrowBlokMoveCommand();
            BasicOrigin = new Vector2(Frame.Center.X, Frame.Center.Y);
        }

        public override void Update(GameTime gameTime, List<DrawBlok> Surroundings, List<CharacterBlok> Targets, List<DynamicBlok> Thowables)
        {
            if (effect == SpriteEffects.None)
            {
                richting.X = 5;
                BasicRotation += 0.5f;
            }
            else if (effect == SpriteEffects.FlipHorizontally)
            {
                richting.X = -5;
                BasicRotation -= 0.5f;
            }
            if (CollisionDetection.LeftCollide(this, richting, Surroundings))
            {
                AttackDetection.RightCollide(this, richting, Targets);
                Surroundings.Remove(this);
                Hit = true;
            } else if (CollisionDetection.RightCollide(this, richting, Surroundings))
            {
                AttackDetection.LeftCollide(this, richting, Targets);
                Surroundings.Remove(this);
                Hit = true;
            }
            Positie += richting;
            base.Update(gameTime, Surroundings, Targets, Thowables);
        }
    }
}
