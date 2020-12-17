using Microsoft.Xna.Framework;
using Sailor.World.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Input
{
    public interface IInputReader
    {
        Vector2 ReadInput(CharacterBlok sailor);
    }
}
