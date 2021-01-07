using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sailor.Animation.MoveAble;
using Sailor.Commands;
using Sailor.Commands.Attack;
using Sailor.Commands.Move;
using Sailor.Input;
using Sailor.Interfaces;
using Sailor.LoadSprites;
using Sailor.World.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.World
{
    public class Player : CharacterBlok
    {
        private IInputReader inputReader;
        ThrowCommand throwCommand;

        public Player(Dictionary<CharacterState, List<Texture2D>> textures, IInputReader reader, int Levens, int Strength, int PunchRange,
            MoveAbleAnimatie animatie, MoveAbleEffectAnimatie animatieEffect, MoveAbleStateAnimatie animatieState,
            JumpCommand jumpCommands, PunchCommand punchCommands, MoveCommand moveCommand, ThrowCommand throwCommand)
            : base(textures, Levens, Strength, PunchRange, animatie, animatieEffect, animatieState, jumpCommands, punchCommands, moveCommand)
        {
            inputReader = reader;
            this.throwCommand = throwCommand;
        }

        public override void Update(GameTime gameTime, List<DrawBlok> Surroundings, List<CharacterBlok> Targets, List<DynamicBlok> Thowables, IGameObject LowestTile)
        {
            richting = inputReader.ReadInput(this);
            if (!Hit && !Dead) throwCommand.Execute(this, Surroundings, Thowables);
            base.Update(gameTime, Surroundings, Targets, Thowables, LowestTile);
        }
    }
}
