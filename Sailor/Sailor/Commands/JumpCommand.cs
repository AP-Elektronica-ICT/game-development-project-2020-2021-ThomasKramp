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

        public JumpCommand()
        {
            snelheid = new Vector2(0, 0);
        }
        public void Execute(IGameObject transform, Vector2 richting, List<DrawBlok> Surroundings)
        {
            IJumper tempJumper = (IJumper)transform;

            if (tempJumper.Jumped && !tempJumper.Falling)
            {
                if (CollisionDetection.BottomCollide(transform, richting, Surroundings) && tempJumper.Ground)
                {
                    snelheid.Y = -15f;
                    tempJumper.Ground = false;
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
                //if (tempJumper.Falling) 
                tempJumper.Ground = true;
                tempJumper.Falling = false;
                snelheid.Y = 0;
            }
            else snelheid.Y += 0.1f;

            richting *= snelheid;
            transform.Positie += richting;
        }
    }
}
