using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sailor.LoadSprites;
using Sailor.World.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Input
{
    class KeyBoardReader : IInputReader
    {
        public static CharacterState cState = CharacterState.Idle;
        Vector2 richting = new Vector2(0, 1);

        public Vector2 ReadInput(DynamicBlok sailor)
        {
            KeyboardState state = Keyboard.GetState();
            if (!sailor.Punch)
            {
                if (state.IsKeyDown(Keys.Left)) richting.X = -1;
                else if (state.IsKeyDown(Keys.Right))
                    richting.X = 1;
                else richting.X = 0;
            } else richting.X = 0;

            if (state.IsKeyDown(Keys.Space)) sailor.Jumped = true;
            if (state.IsKeyDown(Keys.A)) sailor.Punch = true;
            return richting;
        }
    }
}
