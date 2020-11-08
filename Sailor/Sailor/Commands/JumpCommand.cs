using Microsoft.Xna.Framework;
using Sailor.CollisionDetection;
using Sailor.Input;
using Sailor.Interfaces;
using Sailor.LoadSprites;
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
                if (snelheid.Y > -1 || ColDetec.TopColliding(transform, richting))
                {
                    Jumped = false;
                    snelheid.Y = 0;
                }
            }
            else if (ColDetec.BottomColliding(transform, richting))
            {
                if (snelheid.Y > 0.01)
                {
                    // Nodig om door de hele Ground animatie te gaan 
                    snelheid.Y /= 2;
                    HitGround = true;
                }
                else
                {
                    snelheid.Y = 0;
                    HitGround = false;
                }
            }
            else
            {
                snelheid.Y += 0.1f;
            }
            richting *= snelheid;
            transform.positie += richting;
        }
    }
}
