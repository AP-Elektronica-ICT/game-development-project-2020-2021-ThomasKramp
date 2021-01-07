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
        MoveCommand givenMoveComand;
        bool punched = false;

        public Enemy(Dictionary<CharacterState, List<Texture2D>> textures, int Levens, int Strength, int PunchRange,
            MoveAbleAnimatie animatie, MoveAbleEffectAnimatie animatieEffect, MoveAbleStateAnimatie animatieState,
            JumpCommand jumpCommands, PunchCommand punchCommands, MoveCommand moveCommand)
            : base(textures, Levens, Strength, PunchRange, animatie, animatieEffect, animatieState, jumpCommands, punchCommands, moveCommand)
        {
            // Moet weg, wanneer loop patroon geimplementeerd is
            richting = new Vector2(1, 1);
            givenMoveComand = moveCommand;
        }

        public override void Update(GameTime gameTime, List<DrawBlok> Surroundings, List<CharacterBlok> Targets, List<DynamicBlok> Thowables, IGameObject LowestTile)
        {
            float playerDistance = PlayerDetection.SearchSides(this, Targets[0]);
            if (punched) {
                if (!Punch) moveCommand = new MoveToPlayerCommand(new Vector2(3, 0), playerDistance * -2);
                if (playerDistance < -150 || 150 < playerDistance) punched = false;
            } else if (-100 < playerDistance && playerDistance < 100) {
                moveCommand = new MoveToPlayerCommand(new Vector2(3, 0), playerDistance);
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
                moveCommand = givenMoveComand;
            }
            base.Update(gameTime, Surroundings, Targets, Thowables, LowestTile);
        }
    }
}
