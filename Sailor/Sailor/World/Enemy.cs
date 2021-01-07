using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sailor.Animation.MoveAble;
using Sailor.Commands;
using Sailor.Commands.Attack;
using Sailor.Commands.Move;
using Sailor.Detection;
using Sailor.Interfaces;
using Sailor.LoadSprites;
using Sailor.World.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.World
{
    class Enemy : CharacterBlok
    {
        MoveCommand normalMoveCommand;
        MoveToPlayerCommand moveToPlayerCommand;
        bool punched = false;

        public Enemy(Dictionary<CharacterState, List<Texture2D>> textures, int Levens, int Strength, int PunchRange,
            MoveAbleAnimatie animatie, MoveAbleEffectAnimatie animatieEffect, MoveAbleStateAnimatie animatieState,
            JumpCommand jumpCommands, PunchCommand punchCommands, MoveCommand moveCommand, MoveToPlayerCommand moveToPlayerCommand)
            : base(textures, Levens, Strength, PunchRange, animatie, animatieEffect, animatieState, jumpCommands, punchCommands, moveCommand)
        {
            // Moet weg, wanneer loop patroon geimplementeerd is
            richting = new Vector2(1, 1);
            normalMoveCommand = moveCommand;
            this.moveToPlayerCommand = moveToPlayerCommand;
        }

        public override void Update(GameTime gameTime, List<DrawBlok> Surroundings, List<CharacterBlok> Targets, List<DynamicBlok> Thowables, IGameObject LowestTile)
        {
            float playerDistance = PlayerDetection.SearchSides(this, Targets[0]);
            if (punched) {
                if (!Punch) {
                    moveToPlayerCommand.SetPLayerDistance(playerDistance * -2);
                    moveCommand = moveToPlayerCommand;
                }
                if (playerDistance < -150 || 150 < playerDistance) punched = false;
            } else if (-100 < playerDistance && playerDistance < 100) {
                moveToPlayerCommand.SetPLayerDistance(playerDistance);
                moveCommand = moveToPlayerCommand;
                if (-15 <= playerDistance && playerDistance <= 15)
                {
                    Punch = true;
                    punched = true;
                }
            } else {
                if (richting.X == 0)
                {
                    if (effect == SpriteEffects.None) richting.X = 1;
                    else richting.X = -1;
                }
                moveCommand = normalMoveCommand;
            }
            base.Update(gameTime, Surroundings, Targets, Thowables, LowestTile);
        }
    }
}
