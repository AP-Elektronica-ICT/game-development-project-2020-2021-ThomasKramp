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
            if (transform.frame.Left + transform.positie.X + richting.X < 100)
            {
                for (int x = 0; x < Game1.Foreground.blokArray.GetLength(0); x++)
                {
                    for (int y = 0; y < Game1.Foreground.blokArray.GetLength(1); y++)
                    {
                        // Ziet of blokken bestaan
                        if (Game1.Foreground.blokArray[x, y] != null)
                        {
                            Game1.Foreground.blokArray[x, y].Positie -= richting;
                        }
                    }
                }
            }
        }
        public static void RightCollide(ITransform transform, Vector2 richting) 
        {
            if (transform.frame.Left + transform.positie.X + richting.X > Game1.ConsoleWidth - 100)
            {
                for (int x = 0; x < Game1.Foreground.blokArray.GetLength(0); x++)
                {
                    for (int y = 0; y < Game1.Foreground.blokArray.GetLength(1); y++)
                    {
                        // Ziet of blokken bestaan
                        if (Game1.Foreground.blokArray[x, y] != null)
                        {
                            Game1.Foreground.blokArray[x, y].Positie += richting;
                        }
                    }
                }
            }
        }
        public static void TopCollide(ITransform transform, Vector2 richting) 
        { 
            
        }
        public static void BottomCollide(ITransform transform, Vector2 richting) 
        { 
             
        }
    }
}
