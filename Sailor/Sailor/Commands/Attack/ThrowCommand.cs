﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sailor.Detection;
using Sailor.Interfaces;
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
        IGameObject AttackObject;
        bool lastAttack = false;
        Random random = new Random();

        public void Execute(IThrower Attacker, List<DynamicBlok> Targets)
        {
            if (Attacker.Throw && !lastAttack)
            {
                if (Attacker.effect == SpriteEffects.None)
                {
                    // Moet een texture aan toegevoegd worden
                    AttackObject = new ThrowBlok(null, new Vector2(
                        Attacker.Positie.X + Attacker.Frame.Center.X,
                        Attacker.Positie.Y + Attacker.Frame.Center.Y),
                        Attacker.effect);

                    AttackDetection.LeftCollide(AttackObject, Targets);
                }
                else if (Attacker.effect == SpriteEffects.FlipHorizontally)
                {
                    AttackObject = new ThrowBlok(null, new Vector2(
                        Attacker.Positie.X + Attacker.Frame.Center.X,
                        Attacker.Positie.Y + Attacker.Frame.Center.Y),
                        Attacker.effect);

                    AttackDetection.LeftCollide(AttackObject, Targets);
                }
            }
            lastAttack = Attacker.Throw;
        }
    }
}
