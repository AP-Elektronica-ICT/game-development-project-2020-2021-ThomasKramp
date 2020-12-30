using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sailor.Detection;
using Sailor.Interfaces;
using Sailor.Interfaces.Commands;
using Sailor.World.Attack;
using Sailor.World.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Commands.Attack
{
    class PunchCommand
    {
        IGameObject AttackObject;
        bool lastAttack = false;
        int punchWidth = 75;
        int punchHeight = 10;
        int slaagKracht = 3;

        public void Execute(IPuncher attacker, List<CharacterBlok> Targets)
        {
            if (attacker.Punch && !lastAttack)
            {
                if (attacker.effect == SpriteEffects.None)
                {
                    AttackObject = new PunchBlok(new Vector2(
                        attacker.Positie.X + attacker.Frame.Center.X,
                        attacker.Positie.Y + attacker.Frame.Center.Y),
                        new Rectangle(0, 0, punchWidth, punchHeight));

                    // Zo verwijdert hij 3 levens
                    for (int i = 0; i < slaagKracht; i++)
                    {
                        AttackDetection.LeftCollide(AttackObject, Vector2.Zero, Targets);
                    }
                }
                else if (attacker.effect == SpriteEffects.FlipHorizontally)
                {
                    AttackObject = new PunchBlok(new Vector2(
                        attacker.Positie.X + attacker.Frame.Center.X,
                        attacker.Positie.Y + attacker.Frame.Center.Y),
                        new Rectangle(0, 0, -punchWidth, punchHeight));

                    for (int i = 0; i < slaagKracht; i++)
                    {
                        AttackDetection.LeftCollide(AttackObject, Vector2.Zero, Targets);
                    }
                }
            }
            lastAttack = attacker.Punch;
        }
    }
}
