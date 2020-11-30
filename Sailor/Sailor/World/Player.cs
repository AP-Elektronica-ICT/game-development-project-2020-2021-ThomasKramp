﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sailor.Commands.Move;
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
            moveCommands = new PlayerMoveCommand();
            Levens = 3;
        }

        public override void Update(GameTime gameTime, List<DrawBlok> Surroundings)
        {
            richting = inputReader.ReadInput(this);
            base.Update(gameTime, Surroundings);
        }
    }
}
