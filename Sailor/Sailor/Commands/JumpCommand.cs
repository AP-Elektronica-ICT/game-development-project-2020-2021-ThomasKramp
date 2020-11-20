using Microsoft.Xna.Framework;
using Sailor.Detection;
using Sailor.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Commands
{
    class JumpCommand
    {
        private Vector2 snelheid;

        public JumpCommand()
        {
            snelheid = new Vector2(0, 0);
        }
        public void Execute(IGameObject transform, Vector2 richting)
        {
            IJumper tempJumper = (IJumper)transform;
            if (tempJumper.Jumped && snelheid.Y <= 0 && !tempJumper.Falling)
            {
                if (snelheid.Y == 0)
                {
                    snelheid.Y = -10f;
                }
                snelheid.Y /= 1.1f;
                if (snelheid.Y > -1 || CollisionDetection.TopCollide(transform, richting))
                {
                    tempJumper.Jumped = false;
                    snelheid.Y = 0;
                }
            }
            else if (CollisionDetection.BottomCollide(transform, richting))
            {
                if (snelheid.Y > 0) tempJumper.Ground = true;
                tempJumper.Falling = false;
                snelheid.Y = 0;
            }
            else
            {
                tempJumper.Jumped = false;
                tempJumper.Falling = true;
                snelheid.Y += 0.1f;
            }
            richting *= snelheid;
            transform.Positie += richting;
            ScrollDetection.TopCollide(transform, richting);
            ScrollDetection.BottomCollide(transform, richting);
        }
    }
}
