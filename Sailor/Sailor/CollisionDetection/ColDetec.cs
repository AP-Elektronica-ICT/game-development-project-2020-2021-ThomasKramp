using Microsoft.Xna.Framework;
using Sailor.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.CollisionDetection
{
    class ColDetec
    {
        public static bool LeftColliding(Hero sailor)
        {
            if (sailor.frame.Left + sailor.positie.X + sailor.richting.X < 0)
            {
                return false;
            }
            return true;
        }
        public static bool RightColliding(Hero sailor) 
        {
            // Console. Width kan gevonden worden met Game.GraphicsDevice.Viewport.Width
            if (sailor.frame.Right + sailor.positie.X + sailor.richting.X > 800)
            {
                return false;
            }
            return true;
        }
        public static bool TopColliding(Hero sailor)
        {
            if (sailor.frame.Top + sailor.positie.Y + sailor.richting.Y < 0)
            {
                return false;
            }
            return true;
        }
        public static bool BottomColliding(Hero sailor)
        {
            // Console. Width kan gevonden worden met Game.GraphicsDevice.Viewport.Heigt
            if (sailor.frame.Bottom + sailor.positie.Y + sailor.richting.Y > 400)
            {
                return false;
            }
            return true;
        }
    }
}
