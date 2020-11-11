using Microsoft.Xna.Framework;
using Sailor.Detection;
using Sailor.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Commands
{
    public class MoveCommand : IGameCommands
    {
        public Vector2 snelheid;
        public MoveCommand()
        {
            snelheid = new Vector2(3, 0);
        }
        public void Execute(ITransform transform, Vector2 richting)
        {
            if (CollisionDetection.LeftCollide(transform, richting) || CollisionDetection.RightCollide(transform, richting)) snelheid.X = 0;
            else snelheid.X = 3;
            richting *= snelheid;
            transform.positie += richting;
            //ScrollDetection.LeftCollide(transform, richting);
        }
    }
}
