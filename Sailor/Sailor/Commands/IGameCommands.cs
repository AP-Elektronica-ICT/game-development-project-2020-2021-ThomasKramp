using Microsoft.Xna.Framework;
using Sailor.Interfaces;
using Sailor.World.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Commands.Jump
{
    public interface IGameCommands
    {
        public void Execute(IGameObject transform, Vector2 richting, List<DrawBlok> Surroundings);
    }
}
