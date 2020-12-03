using Microsoft.Xna.Framework;
using Sailor.Detection;
using Sailor.Interfaces;
using Sailor.World.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Commands.Move
{
    class EnemyMoveCommand : MoveCommand
    {
        public override void Execute(IGameObject transform, Vector2 richting, List<DrawBlok> Surroundings)
        {
            base.Execute(transform, richting, Surroundings);
        }
    }
}
