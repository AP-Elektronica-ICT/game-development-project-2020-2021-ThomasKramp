using Microsoft.Xna.Framework;
using Sailor.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Commands
{
    class AttackCommand : IGameCommands
    {
        public static bool Attack = false;
        public void Execute(ITransform transform, Vector2 richting)
        {
            
        }
    }
}
