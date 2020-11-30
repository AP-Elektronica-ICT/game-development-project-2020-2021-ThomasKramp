using Microsoft.Xna.Framework;
using Sailor.Interfaces;
using Sailor.World;
using Sailor.World.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Detection
{
    class CollisionDetection
    {
        // Nodig om te kunnen bewegen
        static int ExtraPixels = 10;
        public static bool LeftCollide(IGameObject player, Vector2 richting, List<DrawBlok> Surroundings)
        {
            foreach (var surrounding in Surroundings)
            {
                if (surrounding != null)
                {
                    if (surrounding is PlatformBlok) continue;
                    // Kijkt naar de X coordinaten
                    if (player.Frame.Left + player.Positie.X + richting.X < surrounding.Positie.X + surrounding.Frame.Right
                        && player.Frame.Right + player.Positie.X > surrounding.Positie.X + surrounding.Frame.Right
                        )
                    {
                        // Kijkt naar de Y coordinaten
                        if (player.Frame.Bottom + player.Positie.Y - ExtraPixels > surrounding.Positie.Y + surrounding.Frame.Top
                        && player.Frame.Top + player.Positie.Y + ExtraPixels < surrounding.Positie.Y + surrounding.Frame.Bottom)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public static bool RightCollide(IGameObject player, Vector2 richting, List<DrawBlok> Surroundings)
        {
            foreach (var surrounding in Surroundings)
            {
                // Ziet of blokken bestaan
                if (surrounding != null)
                {
                    if (surrounding is PlatformBlok) continue;
                    // Kijkt naar de X coordinaten
                    if (player.Frame.Left + player.Positie.X < surrounding.Positie.X + surrounding.Frame.Left
                        && player.Frame.Right + player.Positie.X + richting.X > surrounding.Positie.X + surrounding.Frame.Left
                        )
                    {
                        // Kijkt naar de Y coordinaten
                        if (player.Frame.Bottom + player.Positie.Y - ExtraPixels > surrounding.Positie.Y + surrounding.Frame.Top
                        && player.Frame.Top + player.Positie.Y + ExtraPixels < surrounding.Positie.Y + surrounding.Frame.Bottom)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public static bool TopCollide(IGameObject player, Vector2 richting, List<DrawBlok> Surroundings)
        {
            foreach (var surrounding in Surroundings)
            {
                if (surrounding != null)
                {
                    if (surrounding is PlatformBlok) continue;
                    // Kijkt naar de X coordinaten
                    if (player.Frame.Left + player.Positie.X + ExtraPixels < surrounding.Positie.X + surrounding.Frame.Right
                        && player.Frame.Right + player.Positie.X - ExtraPixels > surrounding.Positie.X + surrounding.Frame.Left
                        )
                    {
                        // Kijkt naar de Y coordinaten
                        if (player.Frame.Top + player.Positie.Y + richting.Y < surrounding.Positie.Y + surrounding.Frame.Bottom
                        && player.Frame.Bottom + player.Positie.Y > surrounding.Positie.Y + surrounding.Frame.Bottom)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public static bool BottomCollide(IGameObject player, Vector2 richting, List<DrawBlok> Surroundings)
        {
            foreach (var surrounding in Surroundings)
            {
                // Ziet of blokken bestaan
                if (surrounding != null)
                {
                    // Kijkt naar de X coordinaten
                    if (player.Frame.Left + player.Positie.X + ExtraPixels < surrounding.Positie.X + surrounding.Frame.Right
                        && player.Frame.Right + player.Positie.X - ExtraPixels > surrounding.Positie.X + surrounding.Frame.Left
                        )
                    {
                        if (surrounding is PlatformBlok
                            && player.Frame.Bottom + player.Positie.Y - richting.Y >= surrounding.Positie.Y + surrounding.Frame.Top)
                        {
                            continue;
                        }
                        // Kijkt naar de Y coordinaten
                        if (player.Frame.Top + player.Positie.Y < surrounding.Positie.Y + surrounding.Frame.Top
                        && player.Frame.Bottom + player.Positie.Y + richting.Y > surrounding.Positie.Y + surrounding.Frame.Top)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
