using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sailor.Commands.Move;
using Sailor.Detection;
using Sailor.LoadSprites;
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
            richting = new Vector2(0.5f, 1);
            moveCommands = new EnemyMoveCommand();
            Levens = 2;
        }

        public override void Update(GameTime gameTime)
        {
            if (CollisionDetection.LeftCollide(this, richting) || CollisionDetection.RightCollide(this, richting)) richting.X *= -1;
            moveCommands.Execute(this, richting);
            base.Update(gameTime);
        }
    }
}
