using Microsoft.Xna.Framework;
using Sailor.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Detection
{
    class ScrollDetection
    {
        public static void LeftCollide(ITransform transform, Vector2 richting) 
        {
            if (transform.frame.Left + transform.positie.X + richting.X < 150
                && Game1.Foreground.blokArray[0, 0].Positie.X +
                Game1.Foreground.blokArray[0, 0].rectangle.Left < 0)
            {
                transform.positie -= richting;
                for (int y = 0; y < Game1.Foreground.blokArray.GetLength(0); y++)
                {
                    for (int x = 0; x < Game1.Foreground.blokArray.GetLength(1); x++)
                    {
                        // Ziet of blokken bestaan
                        if (Game1.Foreground.blokArray[y, x] != null)
                        {
                            Game1.Foreground.blokArray[y, x].Positie -= richting;
                        }
                    }
                }
            }
        }
        public static void RightCollide(ITransform transform, Vector2 richting)
        {
            int lengthY = Game1.Foreground.blokArray.GetLength(0) - 1;
            int lengthX = Game1.Foreground.blokArray.GetLength(1) - 1;
            if (transform.frame.Right + transform.positie.X + richting.X > Game1.ConsoleWidth - 200
                && Game1.Foreground.blokArray[lengthY, lengthX].Positie.X +
                Game1.Foreground.blokArray[lengthY, lengthX].rectangle.Right > Game1.ConsoleWidth)
            {
                transform.positie -= richting;
                for (int y = 0; y <= lengthY; y++)
                {
                    for (int x = 0; x <= lengthX; x++)
                    {
                        // Ziet of blokken bestaan
                        if (Game1.Foreground.blokArray[y, x] != null)
                        {
                            Game1.Foreground.blokArray[y, x].Positie -= richting;
                        }
                    }
                }
            }
        }
        public static void TopCollide(ITransform transform, Vector2 richting) 
        {
            if (transform.frame.Top + transform.positie.Y + richting.Y < 40
                && Game1.Foreground.blokArray[0, 0].Positie.Y +
                Game1.Foreground.blokArray[0, 0].rectangle.Top < 0)
            {
                transform.positie -= richting;
                for (int y = 0; y < Game1.Foreground.blokArray.GetLength(0); y++)
                {
                    for (int x = 0; x < Game1.Foreground.blokArray.GetLength(1); x++)
                    {
                        // Ziet of blokken bestaan
                        if (Game1.Foreground.blokArray[y, x] != null)
                        {
                            Game1.Foreground.blokArray[y, x].Positie -= richting;
                        }
                    }
                }
            }
        }
        public static void BottomCollide(ITransform transform, Vector2 richting)
        {
            int lengthY = Game1.Foreground.blokArray.GetLength(0) - 1;
            int lengthX = Game1.Foreground.blokArray.GetLength(1) - 1;
            if (transform.frame.Bottom + transform.positie.Y + richting.Y > Game1.ConsoleHeigth - 40
                && Game1.Foreground.blokArray[lengthY, lengthX].Positie.Y +
                Game1.Foreground.blokArray[lengthY, lengthX].rectangle.Bottom > Game1.ConsoleHeigth)
            {
                transform.positie -= richting;
                for (int y = 0; y <= lengthY; y++)
                {
                    for (int x = 0; x <= lengthX; x++)
                    {
                        // Ziet of blokken bestaan
                        if (Game1.Foreground.blokArray[y, x] != null)
                        {
                            Game1.Foreground.blokArray[y, x].Positie -= richting;
                        }
                    }
                }
            }
        }
    }
}
