using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sailor.Interfaces.Commands;
using Sailor.World.Abstract;
using Sailor.World.Attack;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Commands.Attack
{
    class ThrowCommand
    {
        bool lastAttack = false;

        public void Execute(IThrower attacker, List<DrawBlok> Surroundings, List<DynamicBlok> ThrowAbles)
        {
            if (attacker.Throw && !lastAttack)
            {
                // Gooit naar rechts
                if (attacker.effect == SpriteEffects.None) { 
                    DynamicBlok temp = new ThrowBlok(new Vector2(
                        attacker.Positie.X + attacker.Frame.Right,
                        attacker.Positie.Y + attacker.Frame.Center.Y),
                        attacker.effect);
                    Surroundings.Add(temp);
                    ThrowAbles.Add(temp);
                }
                // Gooit naar links
                else if (attacker.effect == SpriteEffects.FlipHorizontally)
                {
                    DynamicBlok temp = new ThrowBlok(new Vector2(
                        attacker.Positie.X + attacker.Frame.Left - 16,
                        attacker.Positie.Y + attacker.Frame.Center.Y),
                        attacker.effect);
                    Surroundings.Add(temp);
                    ThrowAbles.Add(temp);
                }
            }
            lastAttack = attacker.Throw;
        }
    }
}
