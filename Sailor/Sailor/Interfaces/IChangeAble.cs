using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sailor.LoadSprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Interfaces
{
    interface IChangeAble
    {
        public Dictionary<CharacterState, List<Texture2D>> Textures { get; set; }
        public virtual void Update(GameTime gameTime) { }
    }
}
