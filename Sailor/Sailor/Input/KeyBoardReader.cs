using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sailor.LoadSprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Input
{
    class KeyBoardReader : IInputReader
    {
        public static SpriteEffects effect = SpriteEffects.None;
        public static CharacterState cState = CharacterState.Idle;
        public Vector2 ReadInput()
        {
            Vector2 richting = Vector2.Zero;
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Left))
            {
                richting = new Vector2(-1, 0);
                cState = CharacterState.Run;
                effect = SpriteEffects.FlipHorizontally;
            } else if (state.IsKeyDown(Keys.Right))
            {
                richting = new Vector2(1, 0);
                cState = CharacterState.Run;
                effect = SpriteEffects.None;
            } else {
                cState = CharacterState.Idle;
            }
            return richting;
        }
    }
}
