using Microsoft.Xna.Framework;
using Sailor.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Detection
{
    class CollisionDetection
    {
        public static bool LeftCollide(ITransform transform, Vector2 richting)
        {
            for (int x = 0; x < Game1.Foreground.blokArray.GetLength(0); x++)
            {
                for (int y = 0; y < Game1.Foreground.blokArray.GetLength(1); y++)
                {
                    // Ziet of blokken bestaan
                    if (Game1.Foreground.blokArray[x, y] != null)
                    {
                        // Kijkt naar de X coordinaten
                        if (transform.frame.Left + transform.positie.X + richting.X < Game1.Foreground.blokArray[x, y].Positie.X + Game1.Foreground.blokArray[x, y].rectangle.Right
                            && transform.frame.Right + transform.positie.X > Game1.Foreground.blokArray[x, y].Positie.X + Game1.Foreground.blokArray[x, y].rectangle.Right
                            )
                        {
                            // Kijkt naar de Y coordinaten
                            if (transform.frame.Bottom + transform.positie.Y - 5 > Game1.Foreground.blokArray[x, y].Positie.Y + Game1.Foreground.blokArray[x, y].rectangle.Top
                            && transform.frame.Top + transform.positie.Y + 5 < Game1.Foreground.blokArray[x, y].Positie.Y + Game1.Foreground.blokArray[x, y].rectangle.Bottom)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        public static bool RightCollide(ITransform transform, Vector2 richting)
        {
            for (int x = 0; x < Game1.Foreground.blokArray.GetLength(0); x++)
            {
                for (int y = 0; y < Game1.Foreground.blokArray.GetLength(1); y++)
                {
                    // Ziet of blokken bestaan
                    if (Game1.Foreground.blokArray[x, y] != null)
                    {
                        // Kijkt naar de X coordinaten
                        if (transform.frame.Right + transform.positie.X + richting.X > Game1.Foreground.blokArray[x, y].Positie.X + Game1.Foreground.blokArray[x, y].rectangle.Left
                            && transform.frame.Left + transform.positie.X < Game1.Foreground.blokArray[x, y].Positie.X + Game1.Foreground.blokArray[x, y].rectangle.Left
                            )
                        {
                            // Kijkt naar de Y coordinaten
                            if (transform.frame.Bottom + transform.positie.Y - 5 > Game1.Foreground.blokArray[x, y].Positie.Y + Game1.Foreground.blokArray[x, y].rectangle.Top
                            && transform.frame.Top + transform.positie.Y + 5 < Game1.Foreground.blokArray[x, y].Positie.Y + Game1.Foreground.blokArray[x, y].rectangle.Bottom)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        public static bool TopCollide(ITransform transform, Vector2 richting)
        {
            for (int x = 0; x < Game1.Foreground.blokArray.GetLength(0); x++)
            {
                for (int y = 0; y < Game1.Foreground.blokArray.GetLength(1); y++)
                {
                    // Ziet of blokken bestaan
                    if (Game1.Foreground.blokArray[x, y] != null)
                    {
                        // Kijkt naar de X coordinaten
                        if (transform.frame.Right + transform.positie.X - 5 > Game1.Foreground.blokArray[x, y].Positie.X + Game1.Foreground.blokArray[x, y].rectangle.Left
                            && transform.frame.Left + transform.positie.X + 5 < Game1.Foreground.blokArray[x, y].Positie.X + Game1.Foreground.blokArray[x, y].rectangle.Right
                            )
                        {
                            // Kijkt naar de Y coordinaten
                            if (transform.frame.Top + transform.positie.Y + richting.Y < Game1.Foreground.blokArray[x, y].Positie.Y + Game1.Foreground.blokArray[x, y].rectangle.Bottom
                            && transform.frame.Bottom + transform.positie.Y > Game1.Foreground.blokArray[x, y].Positie.Y + Game1.Foreground.blokArray[x, y].rectangle.Bottom)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        public static bool BottomCollide(ITransform transform, Vector2 richting)
        {
            for (int x = 0; x < Game1.Foreground.blokArray.GetLength(0); x++)
            {
                for (int y = 0; y < Game1.Foreground.blokArray.GetLength(1); y++)
                {
                    // Ziet of blokken bestaan
                    if (Game1.Foreground.blokArray[x, y] != null)
                    {
                        // Kijkt naar de X coordinaten
                        if (transform.frame.Right + transform.positie.X - 5 > Game1.Foreground.blokArray[x, y].Positie.X + Game1.Foreground.blokArray[x, y].rectangle.Left
                            && transform.frame.Left + transform.positie.X + 5 < Game1.Foreground.blokArray[x, y].Positie.X + Game1.Foreground.blokArray[x, y].rectangle.Right
                            )
                        {
                            // Kijkt naar de Y coordinaten
                            if (transform.frame.Top + transform.positie.Y < Game1.Foreground.blokArray[x, y].Positie.Y + Game1.Foreground.blokArray[x, y].rectangle.Top
                            && transform.frame.Bottom + transform.positie.Y + richting.Y > Game1.Foreground.blokArray[x, y].Positie.Y + Game1.Foreground.blokArray[x, y].rectangle.Top)
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
