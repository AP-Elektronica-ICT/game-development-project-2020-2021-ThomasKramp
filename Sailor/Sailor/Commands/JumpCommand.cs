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
    class JumpCommand : IGameCommands
    {
        private Vector2 snelheid;
        private bool grounded = false;

        public JumpCommand()
        {
            snelheid = new Vector2(0, 0);
        }
        public void Execute(IGameObject transform, Vector2 richting, List<DrawBlok> Surroundings)
        {
            IJumper tempJumper = (IJumper)transform;

            if (tempJumper.Jumped && !tempJumper.Falling)
            {
                if (grounded)
                {
                    snelheid.Y = -15f;
                    grounded = false;
                }
                snelheid.Y /= 1.1f;
                if (snelheid.Y > -1 || CollisionDetection.TopCollide(transform, richting, Surroundings))
                {
                    snelheid.Y = 0;
                    tempJumper.Jumped = false;
                    tempJumper.Falling = true;
                }
            }
            else if (CollisionDetection.BottomCollide(transform, richting, Surroundings))
            {
                if (CollisionDetection.TopCollide(transform, richting, Surroundings))
                {
                    // Indien het spel in deze lus komt
                    // betekent het dat er Right of Left Collsion is
                    // en geen eigenlijke Bottom Collision
                    snelheid.Y = 0f;
                }
                else
                {
                    snelheid.Y = -0.25f;
                    grounded = true;
                }
                tempJumper.Falling = false;
            }
            else
            {
                snelheid.Y += 0.1f;
                grounded = false;
                tempJumper.Jumped = false;
            }
            richting *= snelheid;
            transform.Positie += richting;
        }
    }
}
