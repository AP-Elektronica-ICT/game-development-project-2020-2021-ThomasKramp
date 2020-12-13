using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sailor.Commands.Attack;
using Sailor.Commands.Move;
using Sailor.Input;
using Sailor.Interfaces.Commands;
using Sailor.LoadSprites;
using Sailor.World.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.World
{
    public class Player : DynamicBlok
    {
        private IInputReader inputReader;
        ThrowCommand throwCommand;

        public Player(Dictionary<CharacterState, List<Texture2D>> textures, IInputReader reader) : base(textures)
        {
            inputReader = reader;
            moveCommands = new PlayerMoveCommand();
            throwCommand = new ThrowCommand();
            Levens = 3;
        }

        public override void Update(GameTime gameTime, List<DrawBlok> Surroundings, List<DynamicBlok> Targets, List<SpecialDrawBlok> Thowables)
        {
            richting = inputReader.ReadInput(this);
            if (!Hit && !Dead) throwCommand.Execute(this, Surroundings, Thowables);
            base.Update(gameTime, Surroundings, Targets, Thowables);
        }
    }
}
