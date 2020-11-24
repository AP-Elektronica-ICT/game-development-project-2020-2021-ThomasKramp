using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sailor.Detection;
using Sailor.Input;
using Sailor.LoadSprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.World
{
    class Player : DynamicBlok
    {
        private IInputReader inputReader;

        public Player(Dictionary<CharacterState, List<Texture2D>> textures, IInputReader reader) : base(textures)
        {
            inputReader = reader;
            Levens = 3;
        }

        public override void Update(GameTime gameTime)
        {
            richting = inputReader.ReadInput(this);
            base.Update(gameTime);
        }
    }
}
