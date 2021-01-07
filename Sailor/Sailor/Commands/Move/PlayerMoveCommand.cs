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

        public override Vector2 Execute(IGameObject mover, Vector2 richting, List<DrawBlok> Surroundings)
        {
            verplaatsing = richting * snelheid;
            if (CollisionDetection.LeftCollide(mover, verplaatsing, Surroundings)
                || CollisionDetection.RightCollide(mover, verplaatsing, Surroundings))
                verplaatsing.X = 0.0f;
            mover.Positie += verplaatsing;
            return richting;
        }
    }
}

/*
   if (CollisionDetection.LeftCollide(mover, verplaatsing, Surroundings))
            {
                if (verplaatsing.X < 0) verplaatsing.X = 0.0f;
                else verplaatsing.X = 0.37f;
            }
            else if (CollisionDetection.RightCollide(mover, verplaatsing, Surroundings))
            {
                if (verplaatsing.X > 0) verplaatsing.X = 0.0f;
                else verplaatsing.X = -0.37f;
 */
