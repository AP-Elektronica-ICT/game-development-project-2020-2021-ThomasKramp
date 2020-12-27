using Microsoft.Xna.Framework.Graphics;
using Sailor.Interfaces;
using Sailor.Interfaces.Commands;
using Sailor.LevelDesign.Schematics;
using Sailor.World;
using Sailor.World.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.LevelDesign
{
    interface ILevel
    {
        public List<DrawBlok> Surroundings { get; set; }
        public List<CharacterBlok> Enemies { get; set; }
        public List<DynamicBlok> ThrowAbles { get; set; }
        public List<DoorBlok> Doors { get; set; }
        public IGameObject LowestTile { get; set; }
        public void CreateWorld(DrawBlok player, Schematic schematic);
        public void RemoveDead(IKillAble Player);
        public void RemoveSpecialBloks();
        public void DrawWorld(SpriteBatch spritebatch);
    }
}
