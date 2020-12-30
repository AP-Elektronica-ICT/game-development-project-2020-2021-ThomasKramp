using Microsoft.Xna.Framework;
using Sailor.Detection;
using Sailor.Interfaces;
using Sailor.Interfaces.Commands;
using Sailor.World.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Commands
{
    class JumpCommand
    {
        private Vector2 snelheid;
        private bool grounded = false;

        public JumpCommand()
        {
            snelheid = new Vector2(0, 0);
        }
        public void Execute(IJumper jumper, Vector2 richting, List<DrawBlok> Surroundings)
        {
            if (jumper.Jumped && !jumper.Falling)
            {
                if (grounded)
                {
                    snelheid.Y = -15f;
                    grounded = false;
                }
                snelheid.Y /= 1.1f;
                if (snelheid.Y > -1 || CollisionDetection.TopCollide(jumper, richting, Surroundings))
                {
                    snelheid.Y = 0;
                    jumper.Jumped = false;
                    jumper.Falling = true;
                }
            }
            else if (CollisionDetection.BottomCollide(jumper, richting, Surroundings))
            {
                if (CollisionDetection.TopCollide(jumper, richting, Surroundings))
                {
                    // Indien het spel in deze lus komt
                    // betekent het dat er Right of Left Collsion is
                    // en geen eigenlijke Bottom Collision
                    if (CollisionDetection.LeftCollide(jumper, richting, Surroundings))
                        snelheid.X += 0.001f;
                    else if (CollisionDetection.RightCollide(jumper, richting, Surroundings))
                        snelheid.X -= 0.001f;
                    snelheid.Y = 0f;
                }
                else
                {
                    snelheid.Y = -0.25f;
                    grounded = true;
                    jumper.Falling = false;
                }
            }
            else
            {
                snelheid.Y += 0.1f;
                grounded = false;
                jumper.Jumped = false;
            }
            richting *= snelheid;
            jumper.Positie += richting;
        }
    }
}
