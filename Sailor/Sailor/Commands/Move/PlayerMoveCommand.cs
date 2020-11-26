using Microsoft.Xna.Framework;
using Sailor.Detection;
using Sailor.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Commands.Move
{
    class PlayerMoveCommand : MoveCommand
    {
        public override void Execute(IGameObject transform, Vector2 richting)
        {
            if (CollisionDetection.LeftCollide(transform, richting) || CollisionDetection.RightCollide(transform, richting)) richting.X = 0;
            ScrollDetection.LeftCollide(transform, richting);
            ScrollDetection.RightCollide(transform, richting);
            base.Execute(transform, richting);
        }
    }
}
