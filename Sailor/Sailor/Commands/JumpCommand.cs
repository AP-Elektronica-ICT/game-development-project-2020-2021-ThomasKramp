using Microsoft.Xna.Framework;
using Sailor.Detection;
using Sailor.Interfaces;
using Sailor.Interfaces.Commands;
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
        public void Execute(IGameObject transform, Vector2 richting)
        {
            IJumper tempJumper = (IJumper)transform;

            if (tempJumper.Jumped)
            {
                if (CollisionDetection.BottomCollide(transform, richting))
                {
                    snelheid.Y = -10f;
                    tempJumper.Ground = false;
                }
                snelheid.Y /= 1.1f;
                if (snelheid.Y > -1 || CollisionDetection.TopCollide(transform, richting))
                {
                    if (!tempJumper.Falling) snelheid.Y = 0;
                    else snelheid.Y += 0.1f;
                    snelheid.Y *= 1.1f;
                    tempJumper.Jumped = false;
                    tempJumper.Falling = true;
                }
            }
            else if (CollisionDetection.BottomCollide(transform, richting))
            {
                if (tempJumper.Falling) tempJumper.Ground = true;
                tempJumper.Falling = false;
                snelheid.Y = 0;
            }
            else
            {
                tempJumper.Ground = false;
                tempJumper.Falling = true;
                snelheid.Y += 0.1f;
            }
            if (tempJumper.TextureReset) tempJumper.Ground = false;
            
            richting *= snelheid;
            transform.Positie += richting;
            ScrollDetection.TopCollide(transform, richting);
            ScrollDetection.BottomCollide(transform, richting);
        }
    }
}
