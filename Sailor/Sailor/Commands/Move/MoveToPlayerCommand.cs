using Microsoft.Xna.Framework;
using Sailor.Detection;
using Sailor.Interfaces;
using Sailor.World.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Commands.Move
{
    class MoveToPlayerCommand : MoveCommand
    {
        float playerDistance;
        public MoveToPlayerCommand(Vector2 snelheid, float playerDistance) : base(snelheid)
        {
            this.playerDistance = playerDistance;
        }

        public override Vector2 Execute(IGameObject mover, Vector2 richting, List<DrawBlok> Surroundings)
        {
            verplaatsing = richting * snelheid;
            
            if (CollisionDetection.LeftCollide(mover, verplaatsing, Surroundings)
                || CollisionDetection.RightCollide(mover, verplaatsing, Surroundings))
            {
                richting.X = 0;
                mover.Positie += new Vector2(0, 0.25f);
            }
            else
            {
                if (-15 <= playerDistance && playerDistance <= 15) richting = new Vector2(0, 1);
                else if (15 < playerDistance) richting = new Vector2(1, 1);
                else richting = new Vector2(-1, 1);
            }

            mover.Positie += verplaatsing;
            return richting;
        }
    }
}
