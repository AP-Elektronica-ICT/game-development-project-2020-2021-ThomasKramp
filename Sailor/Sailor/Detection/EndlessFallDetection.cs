using Sailor.Interfaces;
using Sailor.World;
using Sailor.World.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Detection
{
    public class EndlessFallDetection
    {
        public static void FallingToDeath(IGameObject lowestTile, IDeathFall player)
        {
            if (player.Positie.Y + player.Frame.Top > lowestTile.Positie.Y + lowestTile.Frame.Bottom + 25)
            {
                player.Levens = 0;
                player.Dead = true;
            }            
        }

        public static IGameObject GetLowestTile (List<DrawBlok> Surroundings)
        {
            IGameObject lowestTile = Surroundings[0];
            foreach (var Tile in Surroundings)
            {
                if (Tile.Positie.Y + Tile.Frame.Top > lowestTile.Positie.Y + lowestTile.Frame.Bottom)
                {
                    lowestTile = Tile;
                }
            }
            return lowestTile;
        }
    }
}
