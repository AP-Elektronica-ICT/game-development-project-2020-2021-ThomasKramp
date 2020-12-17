using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sailor.Commands.Move;
using Sailor.Detection;
using Sailor.LoadSprites;
using Sailor.World.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.World
{
    class Enemy : CharacterBlok
    {
        public Enemy(Dictionary<CharacterState, List<Texture2D>> textures) : base(textures)
        {
            // Moet weg, wanneer loop patroon geimplementeerd is
            richting = new Vector2(1, 1);
            moveCommand = new EnemyMoveCommand(new Vector2(3, 0));
            Levens = 2;
        }

        public override void Update(GameTime gameTime, List<DrawBlok> Surroundings, List<CharacterBlok> Targets, List<DynamicBlok> Thowables)
        {
            base.Update(gameTime, Surroundings, Targets, Thowables);
        }
    }
}
