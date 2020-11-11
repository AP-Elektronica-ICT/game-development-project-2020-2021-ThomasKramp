﻿using Microsoft.Xna.Framework;
using Sailor.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Detection
{
    class CollisionDetection
    {
        public static bool LeftColliding(ITransform sailor, Vector2 richting)
        {
            for (int x = 0; x < Game1.Foreground.blokArray.GetLength(0); x++)
            {
                for (int y = 0; y < Game1.Foreground.blokArray.GetLength(1); y++)
                {
                    // Ziet of blokken bestaan
                    if (Game1.Foreground.blokArray[x, y] != null)
                    {
                        // Kijkt naar de X coordinaten
                        if (sailor.frame.Left + sailor.positie.X + richting.X < Game1.Foreground.blokArray[x, y].Positie.X + Game1.Foreground.blokArray[x, y].rectangle.Right
                            && sailor.frame.Right + sailor.positie.X > Game1.Foreground.blokArray[x, y].Positie.X + Game1.Foreground.blokArray[x, y].rectangle.Right
                            )
                        {
                            // Kijkt naar de Y coordinaten
                            if (sailor.frame.Bottom + sailor.positie.Y - 5 > Game1.Foreground.blokArray[x, y].Positie.Y + Game1.Foreground.blokArray[x, y].rectangle.Top
                            && sailor.frame.Top + sailor.positie.Y + 5 < Game1.Foreground.blokArray[x, y].Positie.Y + Game1.Foreground.blokArray[x, y].rectangle.Bottom)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        public static bool RightColliding(ITransform sailor, Vector2 richting)
        {
            for (int x = 0; x < Game1.Foreground.blokArray.GetLength(0); x++)
            {
                for (int y = 0; y < Game1.Foreground.blokArray.GetLength(1); y++)
                {
                    // Ziet of blokken bestaan
                    if (Game1.Foreground.blokArray[x, y] != null)
                    {
                        // Kijkt naar de X coordinaten
                        if (sailor.frame.Right + sailor.positie.X + richting.X > Game1.Foreground.blokArray[x, y].Positie.X + Game1.Foreground.blokArray[x, y].rectangle.Left
                            && sailor.frame.Left + sailor.positie.X < Game1.Foreground.blokArray[x, y].Positie.X + Game1.Foreground.blokArray[x, y].rectangle.Left
                            )
                        {
                            // Kijkt naar de Y coordinaten
                            if (sailor.frame.Bottom + sailor.positie.Y - 5 > Game1.Foreground.blokArray[x, y].Positie.Y + Game1.Foreground.blokArray[x, y].rectangle.Top
                            && sailor.frame.Top + sailor.positie.Y + 5 < Game1.Foreground.blokArray[x, y].Positie.Y + Game1.Foreground.blokArray[x, y].rectangle.Bottom)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        public static bool TopColliding(ITransform sailor, Vector2 richting)
        {
            for (int x = 0; x < Game1.Foreground.blokArray.GetLength(0); x++)
            {
                for (int y = 0; y < Game1.Foreground.blokArray.GetLength(1); y++)
                {
                    // Ziet of blokken bestaan
                    if (Game1.Foreground.blokArray[x, y] != null)
                    {
                        // Kijkt naar de X coordinaten
                        if (sailor.frame.Right + sailor.positie.X - 5 > Game1.Foreground.blokArray[x, y].Positie.X + Game1.Foreground.blokArray[x, y].rectangle.Left
                            && sailor.frame.Left + sailor.positie.X + 5 < Game1.Foreground.blokArray[x, y].Positie.X + Game1.Foreground.blokArray[x, y].rectangle.Right
                            )
                        {
                            // Kijkt naar de Y coordinaten
                            if (sailor.frame.Top + sailor.positie.Y + richting.Y < Game1.Foreground.blokArray[x, y].Positie.Y + Game1.Foreground.blokArray[x, y].rectangle.Bottom
                            && sailor.frame.Bottom + sailor.positie.Y > Game1.Foreground.blokArray[x, y].Positie.Y + Game1.Foreground.blokArray[x, y].rectangle.Bottom)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        public static bool BottomColliding(ITransform sailor, Vector2 richting)
        {
            for (int x = 0; x < Game1.Foreground.blokArray.GetLength(0); x++)
            {
                for (int y = 0; y < Game1.Foreground.blokArray.GetLength(1); y++)
                {
                    // Ziet of blokken bestaan
                    if (Game1.Foreground.blokArray[x, y] != null)
                    {
                        // Kijkt naar de X coordinaten
                        if (sailor.frame.Right + sailor.positie.X - 5 > Game1.Foreground.blokArray[x, y].Positie.X + Game1.Foreground.blokArray[x, y].rectangle.Left
                            && sailor.frame.Left + sailor.positie.X + 5 < Game1.Foreground.blokArray[x, y].Positie.X + Game1.Foreground.blokArray[x, y].rectangle.Right
                            )
                        {
                            // Kijkt naar de Y coordinaten
                            if (sailor.frame.Top + sailor.positie.Y < Game1.Foreground.blokArray[x, y].Positie.Y + Game1.Foreground.blokArray[x, y].rectangle.Top
                            && sailor.frame.Bottom + sailor.positie.Y + richting.Y > Game1.Foreground.blokArray[x, y].Positie.Y + Game1.Foreground.blokArray[x, y].rectangle.Top)
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
