using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sailor.Interfaces;
using Sailor.LoadSprites;
using Sailor.World.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.World
{
    class DoorBlok : DrawBlok, IPassable
    {
        public bool PassLeft { get; set; }
        public bool PassRight { get; set; }
        public bool PassTop { get; set; }
        public bool PassBottom { get; set; }

        public DoorBlok(Dictionary<DoorState, List<Texture2D>> textures)
        {
            PassLeft = true;
            PassRight = true;
            PassTop = true;
            PassBottom = true;
        }

        public void Update(GameTime gameTime, IGameObject player)
        {
        }
    }
}
