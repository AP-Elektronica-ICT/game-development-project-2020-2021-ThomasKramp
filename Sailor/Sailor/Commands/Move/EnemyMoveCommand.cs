using Microsoft.Xna.Framework;
using Sailor.Detection;
using Sailor.Interfaces;
using Sailor.World.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Commands.Move
{
    class EnemyMoveCommand : MoveCommand
    {
        public EnemyMoveCommand(Vector2 snelheid) : base(snelheid)
        {
        }

        public override Vector2 Execute(IGameObject transform, Vector2 richting, List<DrawBlok> Surroundings)
        {
            verplaatsing = richting * snelheid;
            if (CollisionDetection.LeftCollide(transform, verplaatsing, Surroundings))
                richting.X = 1;
            else if (CollisionDetection.RightCollide(transform, verplaatsing, Surroundings))
                richting.X = -1;
            //richting *= snelheid;
            transform.Positie += verplaatsing;
            return richting;
        }
    }
}
