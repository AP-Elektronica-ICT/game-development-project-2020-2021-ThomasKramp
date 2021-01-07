using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sailor.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.World
{
    class PassableBlok : StaticBlok, IPassable
    {
        public bool PassLeft { get; set; }
        public bool PassRight { get; set; }
        public bool PassTop { get; set; }
        public bool PassBottom { get; set; }

        public PassableBlok(Texture2D blokTexture, Vector2 positie) : base(blokTexture, positie)
        {
            PassLeft = true;
            PassRight = true;
            PassTop = true;
        }
    }
}
