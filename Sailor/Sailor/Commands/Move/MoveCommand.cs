using Microsoft.Xna.Framework;
using Sailor.Interfaces;
using Sailor.World.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Commands.Move
{
    abstract class MoveCommand : IGameCommands
    {
        public Vector2 snelheid;
        public MoveCommand()
        {
            snelheid = new Vector2(3, 0);
        }
        public virtual void Execute(IGameObject transform, Vector2 richting, List<DrawBlok> Surroundings)
        {
            richting *= snelheid;
            transform.Positie += richting;
        }
    }
}
