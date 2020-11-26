using Microsoft.Xna.Framework;
using Sailor.Detection;
using Sailor.Interfaces;
using Sailor.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Commands.Move
{
    public class MoveCommand : IGameCommands
    {
        public Vector2 snelheid;
        public MoveCommand()
        {
            snelheid = new Vector2(3, 0);
        }
        public void Execute(IGameObject transform, Vector2 richting)
        {
            if (transform is Enemy)
            {
                if (CollisionDetection.LeftCollide(transform, richting) || CollisionDetection.RightCollide(transform, richting))
                {
                    snelheid *= -1;
                }
            }
            richting *= snelheid;

            transform.Positie += richting;
            if (transform is Player)
            {
                if (CollisionDetection.LeftCollide(transform, richting) || CollisionDetection.RightCollide(transform, richting)) richting.X = 0;
                ScrollDetection.LeftCollide(transform, richting);
                ScrollDetection.RightCollide(transform, richting);
            }
        }
    }
}
