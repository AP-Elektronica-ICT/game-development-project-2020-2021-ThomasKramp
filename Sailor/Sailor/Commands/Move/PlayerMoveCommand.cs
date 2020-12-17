using Microsoft.Xna.Framework;
using Sailor.Detection;
using Sailor.Interfaces;
using Sailor.World.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Commands.Move
{
    class PlayerMoveCommand : MoveCommand
    {
        public PlayerMoveCommand(Vector2 snelheid) : base(snelheid)
        {
        }

        public override Vector2 Execute(IGameObject transform, Vector2 richting, List<DrawBlok> Surroundings)
        {
            verplaatsing = richting * snelheid;
            if (CollisionDetection.LeftCollide(transform, verplaatsing, Surroundings))
                verplaatsing.X = 0.0f;
            else if (CollisionDetection.RightCollide(transform, verplaatsing, Surroundings))
                verplaatsing.X = 0.0f;
            //richting *= snelheid;
            transform.Positie += verplaatsing;
            return richting;
        }
    }
}
