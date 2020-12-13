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
    class Enemy : DynamicBlok
    {
        public Enemy(Dictionary<CharacterState, List<Texture2D>> textures) : base(textures)
        {
            // Moet weg, wanneer loop patroon geimplementeerd is
            richting = new Vector2(1, 1);
            moveCommands = new EnemyMoveCommand();
            Levens = 2;
        }

        public override void Update(GameTime gameTime, List<DrawBlok> Surroundings, List<DynamicBlok> Targets, List<SpecialDrawBlok> Thowables)
        {
            if (CollisionDetection.LeftCollide(this, richting, Surroundings))
                richting.X = 1;
            else if (CollisionDetection.RightCollide(this, richting, Surroundings))
                richting.X = -1;
            base.Update(gameTime, Surroundings, Targets, Thowables);
        }
    }
}
