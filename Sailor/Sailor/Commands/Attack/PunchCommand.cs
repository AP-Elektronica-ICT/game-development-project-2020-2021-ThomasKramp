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
using Sailor.Sound;

namespace Sailor.Commands.Attack
{
    public class PunchCommand
    {
        IGameObject AttackObject;
        bool lastAttack = false;
        int punchHeight = 10;

        public void Execute(IPuncher attacker, List<CharacterBlok> Targets, int strength, int punchRange)
        {
            if (attacker.Punch && !lastAttack)
            {
                PlayCharachterSound.PlayPunch();
                if (attacker.effect == SpriteEffects.None)
                {
                    AttackObject = new PunchBlok(new Vector2(
                        attacker.Positie.X + attacker.Frame.Right,
                        attacker.Positie.Y + attacker.Frame.Center.Y),
                        new Rectangle(0, 0, punchRange, punchHeight));

                    // Zo verwijdert hij 3 levens
                    for (int i = 0; i < strength; i++)
                    {
                        AttackDetection.LeftCollide(AttackObject, Vector2.Zero, Targets);
                    }
                }
                else if (attacker.effect == SpriteEffects.FlipHorizontally)
                {
                    AttackObject = new PunchBlok(new Vector2(
                        attacker.Positie.X + attacker.Frame.Left,
                        attacker.Positie.Y + attacker.Frame.Center.Y),
                        new Rectangle(0, 0, -punchRange, punchHeight));

                    for (int i = 0; i < strength; i++)
                    {
                        AttackDetection.LeftCollide(AttackObject, Vector2.Zero, Targets);
                    }
                }
            }
            lastAttack = attacker.Punch;
        }
    }
}
