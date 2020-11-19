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
        public static bool Falling = false;
        public static bool Ground = false;

        public JumpCommand()
        {
            snelheid = new Vector2(0, 0);
        }
        public void Execute(IGameObject transform, Vector2 richting)
        {
            if (Jumped && snelheid.Y <= 0 && !Falling)
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
                if (snelheid.Y > 0) Ground = true;
                Falling = false;
                snelheid.Y = 0;
            }
            else
            {
                Jumped = false;
                Falling = true;
                snelheid.Y += 0.1f;
            }
            richting *= snelheid;
            transform.Positie += richting;
            ScrollDetection.TopCollide(transform, richting);
            ScrollDetection.BottomCollide(transform, richting);
        }
    }
}
