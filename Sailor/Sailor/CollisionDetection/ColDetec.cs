using Microsoft.Xna.Framework;
using Sailor.Interfaces;
using Sailor.LevelDesign;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.CollisionDetection
{
    class ColDetec
    {
        public static bool LeftColliding(Hero sailor, Foreground foreground)
        {
            for (int x = 0; x < foreground.blokArray.GetLength(0); x++)
            {
                for (int y = 0; y < foreground.blokArray.GetLength(1); y++)
                {
                    // Ziet of blokken bestaan
                    if (foreground.blokArray[x, y] != null)
                    {
                        // Kijkt naar de X coordinaten
                        if (sailor.frame.Left + sailor.positie.X + sailor.richting.X < foreground.blokArray[x, y].Positie.X + foreground.blokArray[x, y].rectangle.Right
                            && sailor.frame.Right + sailor.positie.X > foreground.blokArray[x, y].Positie.X + foreground.blokArray[x, y].rectangle.Right
                            )
                        {
                            // Kijkt naar de Y coordinaten
                            if (sailor.frame.Bottom + sailor.positie.Y > foreground.blokArray[x, y].Positie.Y + foreground.blokArray[x, y].rectangle.Top
                            && sailor.frame.Top + sailor.positie.Y < foreground.blokArray[x, y].Positie.Y + foreground.blokArray[x, y].rectangle.Bottom)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        public static bool RightColliding(Hero sailor, Foreground foreground) 
        {
            for (int x = 0; x < foreground.blokArray.GetLength(0); x++)
            {
                for (int y = 0; y < foreground.blokArray.GetLength(1); y++)
                {
                    // Ziet of blokken bestaan
                    if (foreground.blokArray[x, y] != null)
                    {
                        // Kijkt naar de X coordinaten
                        if (sailor.frame.Right + sailor.positie.X + sailor.richting.X > foreground.blokArray[x, y].Positie.X + foreground.blokArray[x, y].rectangle.Left
                            && sailor.frame.Left + sailor.positie.X  < foreground.blokArray[x, y].Positie.X + foreground.blokArray[x, y].rectangle.Left
                            )
                        {
                            // Kijkt naar de Y coordinaten
                            if (sailor.frame.Bottom + sailor.positie.Y > foreground.blokArray[x, y].Positie.Y + foreground.blokArray[x, y].rectangle.Top
                            && sailor.frame.Top + sailor.positie.Y < foreground.blokArray[x, y].Positie.Y + foreground.blokArray[x, y].rectangle.Bottom)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        public static bool TopColliding(Hero sailor, Foreground foreground)
        {
            for (int x = 0; x < foreground.blokArray.GetLength(0); x++)
            {
                for (int y = 0; y < foreground.blokArray.GetLength(1); y++)
                {
                    // Ziet of blokken bestaan
                    if (foreground.blokArray[x, y] != null)
                    {
                        // Kijkt naar de X coordinaten
                        if (sailor.frame.Right + sailor.positie.X > foreground.blokArray[x, y].Positie.X + foreground.blokArray[x, y].rectangle.Left
                            && sailor.frame.Left + sailor.positie.X < foreground.blokArray[x, y].Positie.X + foreground.blokArray[x, y].rectangle.Right
                            )
                        {
                            // Kijkt naar de Y coordinaten
                            if (sailor.frame.Top + sailor.positie.Y + sailor.richting.Y - 5 < foreground.blokArray[x, y].Positie.Y + foreground.blokArray[x, y].rectangle.Bottom
                            && sailor.frame.Bottom + sailor.positie.Y > foreground.blokArray[x, y].Positie.Y + foreground.blokArray[x, y].rectangle.Bottom)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        public static bool BottomColliding(Hero sailor, Foreground foreground)
        {
            for (int x = 0; x < foreground.blokArray.GetLength(0); x++)
            {
                for (int y = 0; y < foreground.blokArray.GetLength(1); y++)
                {
                    // Ziet of blokken bestaan
                    if (foreground.blokArray[x, y] != null)
                    {
                        // Kijkt naar de X coordinaten
                        if (sailor.frame.Right + sailor.positie.X > foreground.blokArray[x, y].Positie.X + foreground.blokArray[x, y].rectangle.Left
                            && sailor.frame.Left + sailor.positie.X < foreground.blokArray[x, y].Positie.X + foreground.blokArray[x, y].rectangle.Right
                            )
                        {
                            // Kijkt naar de Y coordinaten
                            if (sailor.frame.Top + sailor.positie.Y < foreground.blokArray[x, y].Positie.Y + foreground.blokArray[x, y].rectangle.Top
                            && sailor.frame.Bottom + sailor.positie.Y + sailor.richting.Y + 5 > foreground.blokArray[x, y].Positie.Y + foreground.blokArray[x, y].rectangle.Top)
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
