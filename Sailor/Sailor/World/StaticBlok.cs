﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sailor.World.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.World
{
    class StaticBlok : DrawBlok
    {
        public StaticBlok(Texture2D blokTexture, Vector2 positie)
        {
            CurrentTexture = blokTexture;
            this.Positie = positie;
            Frame = new Rectangle(0,0, CurrentTexture.Width, CurrentTexture.Height);
        }
    }
}
