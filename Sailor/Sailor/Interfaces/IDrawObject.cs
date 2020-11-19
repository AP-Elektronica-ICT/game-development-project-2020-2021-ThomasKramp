﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Interfaces
{
    interface IDrawObject
    {
        public Texture2D CurrentTexture { get; set; }
        public Rectangle Frame { get; set; }
    }
}
