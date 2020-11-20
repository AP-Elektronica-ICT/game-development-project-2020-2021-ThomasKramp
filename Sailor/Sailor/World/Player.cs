using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sailor.Animation;
using Sailor.Commands;
using Sailor.Input;
using Sailor.Interfaces;
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
        }

        public override void Update(GameTime gameTime)
        {
            richting = inputReader.ReadInput(this);
            base.Update(gameTime);
        }
    }
}
