using Microsoft.Xna.Framework;
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
            richting *= snelheid;
            transform.positie += richting;
        }
    }
}
