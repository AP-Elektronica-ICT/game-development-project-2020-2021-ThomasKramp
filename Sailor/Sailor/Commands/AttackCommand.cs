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

namespace Sailor.Commands
{
    class AttackCommand
    {
        IGameObject PunchObject;
        int punchWidth = 50;
        int punchHeight = 10;
        bool lastAttack = false;

        public void Execute(IAttacker Attacker, List<DynamicBlok> Targets)
        {
            if (Attacker.Attack && !lastAttack)
            {
                if (Attacker.effect == SpriteEffects.None)
                {
                    PunchObject = new PunchBlok(new Vector2(
                        Attacker.Positie.X + Attacker.Frame.Right,
                        Attacker.Positie.Y + Attacker.Frame.Center.Y),
                        new Rectangle(0, 0, punchWidth, punchHeight));

                    AttackDetection.LeftCollide(PunchObject, Targets);
                }
                else if (Attacker.effect == SpriteEffects.FlipHorizontally)
                {
                    PunchObject = new PunchBlok(new Vector2(
                        Attacker.Positie.X + Attacker.Frame.Left,
                        Attacker.Positie.Y + Attacker.Frame.Center.Y),
                        new Rectangle(0, 0, -punchWidth, punchHeight));

                    AttackDetection.LeftCollide(PunchObject, Targets);
                }
            }
            lastAttack = Attacker.Attack;
        }
    }
}
