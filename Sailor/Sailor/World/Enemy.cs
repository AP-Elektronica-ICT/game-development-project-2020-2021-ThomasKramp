using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        public Enemy(Dictionary<CharacterState, List<Texture2D>> textures) : base(textures)
        {
            // Moet weg, wanneer loop patroon geimplementeerd is
            richting = new Vector2(1, 1);
            givenMoveComand = new EnemyMoveCommand(new Vector2(3, 0));
            Levens = 2;
        }

        public override void Update(GameTime gameTime, List<DrawBlok> Surroundings, List<CharacterBlok> Targets, List<DynamicBlok> Thowables, IGameObject LowestTile)
        {
            float playerDistance = PlayerDetection.SearchSides(this, Targets[0]);
            if (punched) {
                if (Punch) moveCommand = new MoveToPlayerCommand(new Vector2(3, 0), playerDistance * -2);
                if (playerDistance < -150 || 150 < playerDistance) punched = false;
            } else if (-100 < playerDistance && playerDistance < 100) {
                moveCommand = new MoveToPlayerCommand(new Vector2(3, 0), playerDistance);
                if (-25 <= playerDistance && playerDistance <= 25)
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
