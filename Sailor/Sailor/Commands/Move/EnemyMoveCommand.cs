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

        public override Vector2 Execute(IGameObject mover, Vector2 richting, List<DrawBlok> Surroundings)
        {
            verplaatsing = richting * snelheid;
            if (CollisionDetection.LeftCollide(mover, verplaatsing, Surroundings)
                || CollisionDetection.RightCollide(mover, verplaatsing, Surroundings))
                richting.X *= -1;
            mover.Positie += verplaatsing;
            return richting;
        }
    }
}
