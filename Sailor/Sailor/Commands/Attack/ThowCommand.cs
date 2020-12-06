using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sailor.Detection;
using Sailor.Interfaces;
using Sailor.Interfaces.Commands;
using Sailor.World;
using Sailor.World.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Commands.Attack
{
    class ThowCommand
    {
        IGameObject AttackObject;
        bool lastAttack = false;
        int punchWidth = 75;
        int punchHeight = 10;

        public void Execute(IThrower Attacker, List<DynamicBlok> Targets)
        {
            if (Attacker.Throw && !lastAttack)
            {
                if (Attacker.effect == SpriteEffects.None)
                {
                    AttackObject = new PunchBlok(new Vector2(
                        Attacker.Positie.X + Attacker.Frame.Center.X,
                        Attacker.Positie.Y + Attacker.Frame.Center.Y),
                        new Rectangle(0, 0, punchWidth, punchHeight));

                    AttackDetection.LeftCollide(AttackObject, Targets);
                }
                else if (Attacker.effect == SpriteEffects.FlipHorizontally)
                {
                    AttackObject = new PunchBlok(new Vector2(
                        Attacker.Positie.X + Attacker.Frame.Center.X,
                        Attacker.Positie.Y + Attacker.Frame.Center.Y),
                        new Rectangle(0, 0, -punchWidth, punchHeight));

                    AttackDetection.LeftCollide(AttackObject, Targets);
                }
            }
            lastAttack = Attacker.Throw;
        }
    }
}
