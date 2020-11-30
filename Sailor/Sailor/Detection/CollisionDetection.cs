﻿using Microsoft.Xna.Framework;
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
            for (int x = 0; x < Game1.Surroundings.Surroundings.GetLength(0); x++)
            {
                for (int y = 0; y < Game1.Surroundings.Surroundings.GetLength(1); y++)
                {
                    // Ziet of blokken bestaan
                    if (Game1.Surroundings.Surroundings[x, y] != null)
                    {
                        if (Game1.Surroundings.Surroundings[x, y] is PlatformBlok) continue;
                        // Kijkt naar de X coordinaten
                        if (player.Frame.Left + player.Positie.X + richting.X < Game1.Surroundings.Surroundings[x, y].Positie.X + Game1.Surroundings.Surroundings[x, y].Frame.Right
                            && player.Frame.Right + player.Positie.X > Game1.Surroundings.Surroundings[x, y].Positie.X + Game1.Surroundings.Surroundings[x, y].Frame.Right
                            )
                        {
                            // Kijkt naar de Y coordinaten
                            if (player.Frame.Bottom + player.Positie.Y - 5 > Game1.Surroundings.Surroundings[x, y].Positie.Y + Game1.Surroundings.Surroundings[x, y].Frame.Top
                            && player.Frame.Top + player.Positie.Y + 5 < Game1.Surroundings.Surroundings[x, y].Positie.Y + Game1.Surroundings.Surroundings[x, y].Frame.Bottom)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        public static bool RightCollide(IGameObject player, Vector2 richting)
        {
            for (int x = 0; x < Game1.Surroundings.Surroundings.GetLength(0); x++)
            {
                for (int y = 0; y < Game1.Surroundings.Surroundings.GetLength(1); y++)
                {
                    // Ziet of blokken bestaan
                    if (Game1.Surroundings.Surroundings[x, y] != null)
                    {
                        if (Game1.Surroundings.Surroundings[x, y] is PlatformBlok) continue;
                        // Kijkt naar de X coordinaten
                        if (player.Frame.Right + player.Positie.X + richting.X > Game1.Surroundings.Surroundings[x, y].Positie.X + Game1.Surroundings.Surroundings[x, y].Frame.Left
                            && player.Frame.Left + player.Positie.X < Game1.Surroundings.Surroundings[x, y].Positie.X + Game1.Surroundings.Surroundings[x, y].Frame.Left
                            )
                        {
                            // Kijkt naar de Y coordinaten
                            if (player.Frame.Bottom + player.Positie.Y - 5 > Game1.Surroundings.Surroundings[x, y].Positie.Y + Game1.Surroundings.Surroundings[x, y].Frame.Top
                            && player.Frame.Top + player.Positie.Y + 5 < Game1.Surroundings.Surroundings[x, y].Positie.Y + Game1.Surroundings.Surroundings[x, y].Frame.Bottom)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        public static bool TopCollide(IGameObject player, Vector2 richting)
        {
            for (int x = 0; x < Game1.Surroundings.Surroundings.GetLength(0); x++)
            {
                for (int y = 0; y < Game1.Surroundings.Surroundings.GetLength(1); y++)
                {
                    // Ziet of blokken bestaan
                    if (Game1.Surroundings.Surroundings[x, y] != null)
                    {
                        if (Game1.Surroundings.Surroundings[x, y] is PlatformBlok) continue;
                        // Kijkt naar de X coordinaten
                        if (player.Frame.Right + player.Positie.X - 5 > Game1.Surroundings.Surroundings[x, y].Positie.X + Game1.Surroundings.Surroundings[x, y].Frame.Left
                            && player.Frame.Left + player.Positie.X + 5 < Game1.Surroundings.Surroundings[x, y].Positie.X + Game1.Surroundings.Surroundings[x, y].Frame.Right
                            )
                        {
                            // Kijkt naar de Y coordinaten
                            if (player.Frame.Top + player.Positie.Y + richting.Y < Game1.Surroundings.Surroundings[x, y].Positie.Y + Game1.Surroundings.Surroundings[x, y].Frame.Bottom
                            && player.Frame.Bottom + player.Positie.Y > Game1.Surroundings.Surroundings[x, y].Positie.Y + Game1.Surroundings.Surroundings[x, y].Frame.Bottom)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        public static bool BottomCollide(IGameObject player, Vector2 richting)
        {
            for (int x = 0; x < Game1.Surroundings.Surroundings.GetLength(0); x++)
            {
                for (int y = 0; y < Game1.Surroundings.Surroundings.GetLength(1); y++)
                {
                    // Ziet of blokken bestaan
                    if (Game1.Surroundings.Surroundings[x, y] != null)
                    {
                        // Kijkt naar de X coordinaten
                        if (player.Frame.Right + player.Positie.X - 5 > Game1.Surroundings.Surroundings[x, y].Positie.X + Game1.Surroundings.Surroundings[x, y].Frame.Left
                            && player.Frame.Left + player.Positie.X + 5 < Game1.Surroundings.Surroundings[x, y].Positie.X + Game1.Surroundings.Surroundings[x, y].Frame.Right
                            )
                        {
                            if (Game1.Surroundings.Surroundings[x, y] is PlatformBlok
                                && player.Frame.Bottom + player.Positie.Y - richting.Y >= Game1.Surroundings.Surroundings[x, y].Positie.Y + Game1.Surroundings.Surroundings[x, y].Frame.Top)
                            {
                                continue;
                            }
                            // Kijkt naar de Y coordinaten
                            if (player.Frame.Top + player.Positie.Y < Game1.Surroundings.Surroundings[x, y].Positie.Y + Game1.Surroundings.Surroundings[x, y].Frame.Top
                            && player.Frame.Bottom + player.Positie.Y + richting.Y > Game1.Surroundings.Surroundings[x, y].Positie.Y + Game1.Surroundings.Surroundings[x, y].Frame.Top)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
    }
}
