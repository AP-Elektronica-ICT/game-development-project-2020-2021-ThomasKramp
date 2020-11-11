using Microsoft.Xna.Framework;
using Sailor.Detection;
using Sailor.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Commands
{
    class JumpCommand : IGameCommands
    {
        public Vector2 snelheid;
        public static bool Jumped = false;
        public static bool HitGround = false;
        int groundTeller = 0;

        public JumpCommand()
        {
            snelheid = new Vector2(0, 0);
        }
        public void Execute(ITransform transform, Vector2 richting)
        {
            if (Jumped && snelheid.Y <= 0)
            {
                if (snelheid.Y == 0)
                {
                    snelheid.Y = -10f;
                }
                snelheid.Y /= 1.1f;
                if (snelheid.Y > -1 || CollisionDetection.TopCollide(transform, richting))
                {
                    Jumped = false;
                    snelheid.Y = 0;
                }
            }
            else if (CollisionDetection.BottomCollide(transform, richting))
            {
                // Dient om doorheen heel de ground animatie te gaan
                if (snelheid.Y > 0 || groundTeller < 9)
                {
                    if (groundTeller > 9) groundTeller = 0;
                    else groundTeller++;
                    HitGround = true;
                }
                else HitGround = false;
                snelheid.Y = 0;
            }
            else
            {
                snelheid.Y += 0.1f;
            }
            richting *= snelheid;
            transform.positie += richting;
            ScrollDetection.TopCollide(transform, richting);
            ScrollDetection.BottomCollide(transform, richting);
        }
    }
}
