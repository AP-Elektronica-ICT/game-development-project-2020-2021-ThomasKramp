using Microsoft.Xna.Framework;
using Sailor.Interfaces;
using Sailor.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Detection
{
    class AttackDetection
    {
        public static bool LeftCollide(IGameObject player, Vector2 richting, List<DrawBlok> Surroundings)
        {
            return false;
        }
        public static bool RightCollide(IGameObject player, Vector2 richting, List<DrawBlok> Surroundings)
        {
            return false;
        }
    }
}
