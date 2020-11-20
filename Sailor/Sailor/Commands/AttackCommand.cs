using Microsoft.Xna.Framework;
using Sailor.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Commands
{
    class AttackCommand : IGameCommands
    {
        public void Execute(IGameObject transform, Vector2 richting)
        {
            IAttacker tempAttacker = (IAttacker)transform;
        }
    }
}
