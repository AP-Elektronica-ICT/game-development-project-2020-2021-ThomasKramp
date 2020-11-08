using Microsoft.Xna.Framework;
using Sailor.Commands;
using Sailor.Interfaces;
using Sailor.LoadSprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Animation
{
    class AnimatieState : IDrawCheck
    {
        public void Check(IDrawEffect transform, Vector2 richting)
        {
            if (richting.X == 1 || richting.X == -1) transform.state = CharacterState.Run;
            else transform.state = CharacterState.Idle;

            if (JumpCommand.Jumped) transform.state = CharacterState.Jump;
            if (JumpCommand.HitGround) transform.state = CharacterState.Ground;

        }
    }
}
