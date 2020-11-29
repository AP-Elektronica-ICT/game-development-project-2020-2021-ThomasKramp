using Microsoft.Xna.Framework;
using Sailor.Detection;
using Sailor.Interfaces;
using Sailor.Interfaces.Commands;
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
            if (tempAttacker.Attack)
            {
                if (CollisionDetection.LeftCollide(transform, new Vector2(richting.X - 5, richting.Y)))
                {
                    
                }
                if (CollisionDetection.RightCollide(transform, new Vector2(richting.X + 5, richting.Y)))
                {

                }
            }
            
        }
    }
}
