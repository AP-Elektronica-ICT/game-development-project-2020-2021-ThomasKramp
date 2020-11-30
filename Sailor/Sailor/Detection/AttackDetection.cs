using Microsoft.Xna.Framework;
using Sailor.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Detection
{
    class AttackDetection
    {
        public static bool LeftCollide(IGameObject player, Vector2 richting)
        {
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
    }
}
