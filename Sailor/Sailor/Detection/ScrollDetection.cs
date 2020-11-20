using Microsoft.Xna.Framework;
using Sailor.Interfaces;
using Sailor.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Detection
{
    class ScrollDetection
    {
        public static void LeftCollide(IGameObject transform, Vector2 richting) 
        {
            if (transform.Frame.Left + transform.Positie.X + richting.X < 150
                && Game1.Foreground.blokArray[0, 0].Positie.X +
                Game1.Foreground.blokArray[0, 0].Frame.Left < 0)
            {
                transform.Positie -= richting;
                for (int y = 0; y < Game1.Foreground.blokArray.GetLength(0); y++)
                {
                    for (int x = 0; x < Game1.Foreground.blokArray.GetLength(1); x++)
                    {
                        // Ziet of blokken bestaan
                        if (Game1.Foreground.blokArray[y, x] != null && !(Game1.Foreground.blokArray[y, x] is Player))
                        {
                            Game1.Foreground.blokArray[y, x].Positie -= richting;
                        }
                    }
                }
            }
        }
        public static void RightCollide(IGameObject transform, Vector2 richting)
        {
            int lengthY = Game1.Foreground.blokArray.GetLength(0) - 1;
            int lengthX = Game1.Foreground.blokArray.GetLength(1) - 1;
            if (transform.Frame.Right + transform.Positie.X + richting.X > Game1.ConsoleWidth - 200
                && Game1.Foreground.blokArray[lengthY, lengthX].Positie.X +
                Game1.Foreground.blokArray[lengthY, lengthX].Frame.Right > Game1.ConsoleWidth)
            {
                transform.Positie -= richting;
                for (int y = 0; y <= lengthY; y++)
                {
                    for (int x = 0; x <= lengthX; x++)
                    {
                        // Ziet of blokken bestaan
                        if (Game1.Foreground.blokArray[y, x] != null && !(Game1.Foreground.blokArray[y, x] is Player))
                        {
                            Game1.Foreground.blokArray[y, x].Positie -= richting;
                        }
                    }
                }
            }
        }
        public static void TopCollide(IGameObject transform, Vector2 richting) 
        {
            if (transform.Frame.Top + transform.Positie.Y + richting.Y < 40
                && Game1.Foreground.blokArray[0, 0].Positie.Y +
                Game1.Foreground.blokArray[0, 0].Frame.Top < 0)
            {
                transform.Positie -= richting;
                for (int y = 0; y < Game1.Foreground.blokArray.GetLength(0); y++)
                {
                    for (int x = 0; x < Game1.Foreground.blokArray.GetLength(1); x++)
                    {
                        // Ziet of blokken bestaan
                        if (Game1.Foreground.blokArray[y, x] != null && !(Game1.Foreground.blokArray[y, x] is Player))
                        {
                            Game1.Foreground.blokArray[y, x].Positie -= richting;
                        }
                    }
                }
            }
        }
        public static void BottomCollide(IGameObject transform, Vector2 richting)
        {
            int lengthY = Game1.Foreground.blokArray.GetLength(0) - 1;
            int lengthX = Game1.Foreground.blokArray.GetLength(1) - 1;
            if (transform.Frame.Bottom + transform.Positie.Y + richting.Y > Game1.ConsoleHeigth - 40
                && Game1.Foreground.blokArray[lengthY, lengthX].Positie.Y +
                Game1.Foreground.blokArray[lengthY, lengthX].Frame.Bottom > Game1.ConsoleHeigth)
            {
                transform.Positie -= richting;
                for (int y = 0; y <= lengthY; y++)
                {
                    for (int x = 0; x <= lengthX; x++)
                    {
                        // Ziet of blokken bestaan
                        if (Game1.Foreground.blokArray[y, x] != null && !(Game1.Foreground.blokArray[y, x] is Player))
                        {
                            Game1.Foreground.blokArray[y, x].Positie -= richting;
                        }
                    }
                }
            }
        }
    }
}
