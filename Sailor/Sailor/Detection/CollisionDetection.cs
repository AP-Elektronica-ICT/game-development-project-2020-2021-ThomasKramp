using Microsoft.Xna.Framework;
using Sailor.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Detection
{
    class CollisionDetection
    {
        public static bool LeftCollide(IGameObject transform, Vector2 richting)
        {
            for (int x = 0; x < Game1.Foreground.blokArray.GetLength(0); x++)
            {
                for (int y = 0; y < Game1.Foreground.blokArray.GetLength(1); y++)
                {
                    // Ziet of blokken bestaan
                    if (Game1.Foreground.blokArray[x, y] != null)
                    {
                        // Kijkt naar de X coordinaten
                        if (transform.Frame.Left + transform.Positie.X + richting.X < Game1.Foreground.blokArray[x, y].Positie.X + Game1.Foreground.blokArray[x, y].Frame.Right
                            && transform.Frame.Right + transform.Positie.X > Game1.Foreground.blokArray[x, y].Positie.X + Game1.Foreground.blokArray[x, y].Frame.Right
                            )
                        {
                            // Kijkt naar de Y coordinaten
                            if (transform.Frame.Bottom + transform.Positie.Y - 5 > Game1.Foreground.blokArray[x, y].Positie.Y + Game1.Foreground.blokArray[x, y].Frame.Top
                            && transform.Frame.Top + transform.Positie.Y + 5 < Game1.Foreground.blokArray[x, y].Positie.Y + Game1.Foreground.blokArray[x, y].Frame.Bottom)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        public static bool RightCollide(IGameObject transform, Vector2 richting)
        {
            for (int x = 0; x < Game1.Foreground.blokArray.GetLength(0); x++)
            {
                for (int y = 0; y < Game1.Foreground.blokArray.GetLength(1); y++)
                {
                    // Ziet of blokken bestaan
                    if (Game1.Foreground.blokArray[x, y] != null)
                    {
                        // Kijkt naar de X coordinaten
                        if (transform.Frame.Right + transform.Positie.X + richting.X > Game1.Foreground.blokArray[x, y].Positie.X + Game1.Foreground.blokArray[x, y].Frame.Left
                            && transform.Frame.Left + transform.Positie.X < Game1.Foreground.blokArray[x, y].Positie.X + Game1.Foreground.blokArray[x, y].Frame.Left
                            )
                        {
                            // Kijkt naar de Y coordinaten
                            if (transform.Frame.Bottom + transform.Positie.Y - 5 > Game1.Foreground.blokArray[x, y].Positie.Y + Game1.Foreground.blokArray[x, y].Frame.Top
                            && transform.Frame.Top + transform.Positie.Y + 5 < Game1.Foreground.blokArray[x, y].Positie.Y + Game1.Foreground.blokArray[x, y].Frame.Bottom)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        public static bool TopCollide(IGameObject transform, Vector2 richting)
        {
            for (int x = 0; x < Game1.Foreground.blokArray.GetLength(0); x++)
            {
                for (int y = 0; y < Game1.Foreground.blokArray.GetLength(1); y++)
                {
                    // Ziet of blokken bestaan
                    if (Game1.Foreground.blokArray[x, y] != null)
                    {
                        // Kijkt naar de X coordinaten
                        if (transform.Frame.Right + transform.Positie.X - 5 > Game1.Foreground.blokArray[x, y].Positie.X + Game1.Foreground.blokArray[x, y].Frame.Left
                            && transform.Frame.Left + transform.Positie.X + 5 < Game1.Foreground.blokArray[x, y].Positie.X + Game1.Foreground.blokArray[x, y].Frame.Right
                            )
                        {
                            // Kijkt naar de Y coordinaten
                            if (transform.Frame.Top + transform.Positie.Y + richting.Y < Game1.Foreground.blokArray[x, y].Positie.Y + Game1.Foreground.blokArray[x, y].Frame.Bottom
                            && transform.Frame.Bottom + transform.Positie.Y > Game1.Foreground.blokArray[x, y].Positie.Y + Game1.Foreground.blokArray[x, y].Frame.Bottom)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        public static bool BottomCollide(IGameObject transform, Vector2 richting)
        {
            for (int x = 0; x < Game1.Foreground.blokArray.GetLength(0); x++)
            {
                for (int y = 0; y < Game1.Foreground.blokArray.GetLength(1); y++)
                {
                    // Ziet of blokken bestaan
                    if (Game1.Foreground.blokArray[x, y] != null)
                    {
                        // Kijkt naar de X coordinaten
                        if (transform.Frame.Right + transform.Positie.X - 5 > Game1.Foreground.blokArray[x, y].Positie.X + Game1.Foreground.blokArray[x, y].Frame.Left
                            && transform.Frame.Left + transform.Positie.X + 5 < Game1.Foreground.blokArray[x, y].Positie.X + Game1.Foreground.blokArray[x, y].Frame.Right
                            )
                        {
                            // Kijkt naar de Y coordinaten
                            if (transform.Frame.Top + transform.Positie.Y < Game1.Foreground.blokArray[x, y].Positie.Y + Game1.Foreground.blokArray[x, y].Frame.Top
                            && transform.Frame.Bottom + transform.Positie.Y + richting.Y > Game1.Foreground.blokArray[x, y].Positie.Y + Game1.Foreground.blokArray[x, y].Frame.Top)
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
