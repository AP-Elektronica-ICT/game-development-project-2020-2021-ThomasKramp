using Microsoft.Xna.Framework;
using Sailor.Detection;
using Sailor.Interfaces;
using Sailor.World.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Commands.Move
{
    public abstract class MoveCommand
    {
        protected Vector2 snelheid;
        protected Vector2 verplaatsing;

        public MoveCommand(Vector2 snelheid)
        {
            this.snelheid = snelheid;
        }

        public abstract Vector2 Execute(IGameObject mover, Vector2 richting, List<DrawBlok> Surroundings);
    }
}
