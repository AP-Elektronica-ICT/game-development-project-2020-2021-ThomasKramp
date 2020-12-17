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

        public void Execute(IThrower Attacker, List<DrawBlok> Surroundings, List<DynamicBlok> ThrowAbles)
        {
            if (Attacker.Throw && !lastAttack)
            {
                // Gooit naar rechts
                if (Attacker.effect == SpriteEffects.None) { 
                    DynamicBlok temp = new ThrowBlok(new Vector2(
                        Attacker.Positie.X + Attacker.Frame.Right,
                        Attacker.Positie.Y + Attacker.Frame.Center.Y),
                        Attacker.effect);
                    Surroundings.Add(temp);
                    ThrowAbles.Add(temp);
                }
                // Gooit naar links
                else if (Attacker.effect == SpriteEffects.FlipHorizontally)
                {
                    DynamicBlok temp = new ThrowBlok(new Vector2(
                        Attacker.Positie.X + Attacker.Frame.Left - 16,
                        Attacker.Positie.Y + Attacker.Frame.Center.Y),
                        Attacker.effect);
                    Surroundings.Add(temp);
                    ThrowAbles.Add(temp);
                }
            }
            lastAttack = Attacker.Throw;
        }
    }
}
