using Microsoft.Xna.Framework;
using Sailor.LoadSprites;
using Sailor.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Animation
{
    class AnimatieState
    {
        public void Update(DynamicBlok transform, Vector2 richting)
        {
            if (richting.X != 0) transform.state = CharacterState.Run;
            else transform.state = CharacterState.Idle;

            if (transform.Jumped) transform.state = CharacterState.Jump;
            if (transform.Falling) transform.state = CharacterState.Fall;
            if (transform.Attack) transform.state = CharacterState.Attack;
        }
    }
}
