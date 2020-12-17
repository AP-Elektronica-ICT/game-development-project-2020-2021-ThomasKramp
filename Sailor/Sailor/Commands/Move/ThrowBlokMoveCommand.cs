﻿using Microsoft.Xna.Framework;
using Sailor.Interfaces;
using Sailor.World.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Commands.Move
{
    class ThrowBlokMoveCommand : MoveCommand
    {
        public ThrowBlokMoveCommand(Vector2 snelheid) : base(snelheid)
        {
        }

        public override Vector2 Execute(IGameObject transform, Vector2 richting, List<DrawBlok> Surroundings)
        {
            verplaatsing = richting * snelheid;
            transform.Positie += verplaatsing;
            return richting;
        }
    }
}
