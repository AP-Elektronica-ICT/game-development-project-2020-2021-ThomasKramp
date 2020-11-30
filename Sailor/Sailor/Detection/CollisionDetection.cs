using Microsoft.Xna.Framework;
using Sailor.Interfaces;
using Sailor.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Detection
{
    class CollisionDetection
    {
        public static bool LeftCollide(IGameObject player, Vector2 richting)
        {
            foreach (var surrounding in Game1.DemoLevel.Surroundings)
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
                        if (player.Frame.Bottom + player.Positie.Y - 5 > surrounding.Positie.Y + surrounding.Frame.Top
                        && player.Frame.Top + player.Positie.Y + 5 < surrounding.Positie.Y + surrounding.Frame.Bottom)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public static bool RightCollide(IGameObject player, Vector2 richting)
        {
            foreach (var surrounding in Game1.DemoLevel.Surroundings)
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
                        if (player.Frame.Bottom + player.Positie.Y - 5 > surrounding.Positie.Y + surrounding.Frame.Top
                        && player.Frame.Top + player.Positie.Y + 5 < surrounding.Positie.Y + surrounding.Frame.Bottom)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public static bool TopCollide(IGameObject player, Vector2 richting)
        {
            foreach (var surrounding in Game1.DemoLevel.Surroundings)
            {
                if (surrounding != null)
                {
                    if (surrounding is PlatformBlok) continue;
                    // Kijkt naar de X coordinaten
                    if (player.Frame.Left + player.Positie.X + 5 < surrounding.Positie.X + surrounding.Frame.Right
                        && player.Frame.Right + player.Positie.X - 5 > surrounding.Positie.X + surrounding.Frame.Left
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
        public static bool BottomCollide(IGameObject player, Vector2 richting)
        {
            foreach (var surrounding in Game1.DemoLevel.Surroundings)
            {
                // Ziet of blokken bestaan
                if (surrounding != null)
                {
                    // Kijkt naar de X coordinaten
                    if (player.Frame.Left + player.Positie.X + 5 < surrounding.Positie.X + surrounding.Frame.Right
                        && player.Frame.Right + player.Positie.X - 5 > surrounding.Positie.X + surrounding.Frame.Left
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
