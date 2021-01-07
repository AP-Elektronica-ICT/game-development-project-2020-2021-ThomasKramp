using Microsoft.Xna.Framework;
using Sailor.Interfaces;
using Sailor.World;
using Sailor.World.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Detection
{
    class CollisionDetection
    {
        public static bool LeftCollide(IGameObject player, Vector2 richting, List<DrawBlok> Surroundings)
        {
            // Top = 0      Bottom = ∞
            // Links = 0    Rechts = ∞

            foreach (var Tile in Surroundings)
            {
                // Ziet of blokken bestaan
                if (Tile != null && Tile != player)
                {
                    // !(Tile ligt te hoog)
                    if (!(Tile.Positie.Y + Tile.Frame.Top < player.Positie.Y + player.Frame.Top
                        && Tile.Positie.Y + Tile.Frame.Bottom < player.Positie.Y + player.Frame.Top)) {
                        // !(Tile ligt te laag)
                        if (!(Tile.Positie.Y + Tile.Frame.Top > player.Positie.Y + player.Frame.Bottom
                            && Tile.Positie.Y + Tile.Frame.Bottom > player.Positie.Y + player.Frame.Bottom)) {
                            // !(Tile ligt te rechts)
                            if (!(Tile.Positie.X + Tile.Frame.Left > player.Positie.X + player.Frame.Right
                                && Tile.Positie.X + Tile.Frame.Right > player.Positie.X + player.Frame.Right)) {
                                // Tile is links
                                if (Tile.Positie.X + Tile.Frame.Right > player.Positie.X + player.Frame.Left + richting.X
                                    && Tile.Positie.X + Tile.Frame.Right <= player.Positie.X + player.Frame.Center.X) {
                                    if (Tile is IPassable) {
                                        IPassable temp = (IPassable)Tile;
                                        if (temp.PassLeft) continue;
                                    }
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
        public static bool RightCollide(IGameObject player, Vector2 richting, List<DrawBlok> Surroundings)
        {
            // Top = 0      Bottom = ∞
            // Links = 0    Rechts = ∞

            foreach (var Tile in Surroundings)
            {
                // Ziet of blokken bestaan
                if (Tile != null && Tile != player)
                {
                    // !(Tile ligt te hoog)
                    if (!(Tile.Positie.Y + Tile.Frame.Top < player.Positie.Y + player.Frame.Top
                        && Tile.Positie.Y + Tile.Frame.Bottom < player.Positie.Y + player.Frame.Top)) {
                        // !(Tile ligt te laag)
                        if (!(Tile.Positie.Y + Tile.Frame.Top > player.Positie.Y + player.Frame.Bottom
                            && Tile.Positie.Y + Tile.Frame.Bottom > player.Positie.Y + player.Frame.Bottom)) {
                            // !(Tile ligt te links)
                            if (!(Tile.Positie.X + Tile.Frame.Left < player.Positie.X + player.Frame.Left
                                && Tile.Positie.X + Tile.Frame.Right < player.Positie.X + player.Frame.Left)) {
                                // Tile is rechts
                                if (Tile.Positie.X + Tile.Frame.Left < player.Positie.X + player.Frame.Right + richting.X
                                    && Tile.Positie.X + Tile.Frame.Left >= player.Positie.X + player.Frame.Center.X) {
                                    if (Tile is IPassable) {
                                        IPassable temp = (IPassable)Tile;
                                        if (temp.PassRight) continue;
                                    }
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
        public static bool TopCollide(IGameObject player, Vector2 richting, List<DrawBlok> Surroundings)
        {
            // Links = 0    Rechts = ∞
            // Top = 0      Bottom = ∞

            foreach (var Tile in Surroundings)
            {
                // Ziet of blokken bestaan
                if (Tile != null && Tile != player)
                {
                    // !(Tile ligt te ver links)
                    if (!(Tile.Positie.X + Tile.Frame.Left < player.Positie.X + player.Frame.Left
                        && Tile.Positie.X + Tile.Frame.Right < player.Positie.X + player.Frame.Left)) {
                        // !(Tile ligt te ver rechts)
                        if (!(Tile.Positie.X + Tile.Frame.Left > player.Positie.X + player.Frame.Right
                            && Tile.Positie.X + Tile.Frame.Right > player.Positie.X + player.Frame.Right)) {
                            // !(Tile ligt laag)
                            if (!(Tile.Positie.Y + Tile.Frame.Top > player.Positie.Y + player.Frame.Bottom
                                && Tile.Positie.Y + Tile.Frame.Bottom > player.Positie.Y + player.Frame.Bottom)) {
                                // Tile is boven
                                if (Tile.Positie.Y + Tile.Frame.Bottom >= player.Positie.Y + player.Frame.Top + richting.Y
                                    && Tile.Positie.Y + Tile.Frame.Top <= player.Positie.Y + player.Frame.Top) {
                                    if (Tile is IPassable) {
                                        IPassable temp = (IPassable)Tile;
                                        if (temp.PassTop) continue;
                                    }
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
        public static bool BottomCollide(IGameObject player, Vector2 richting, List<DrawBlok> Surroundings)
        {
            // Links = 0    Rechts = ∞
            // Top = 0      Bottom = ∞

            foreach (var Tile in Surroundings)
            {
                // Ziet of blokken bestaan
                if (Tile != null && Tile != player)
                {
                    // !(Tile ligt te ver links)
                    if (!(Tile.Positie.X + Tile.Frame.Left < player.Positie.X + player.Frame.Left
                        && Tile.Positie.X + Tile.Frame.Right < player.Positie.X + player.Frame.Left)) {
                        // !(Tile ligt te ver rechts)
                        if (!(Tile.Positie.X + Tile.Frame.Left > player.Positie.X + player.Frame.Right
                            && Tile.Positie.X + Tile.Frame.Right > player.Positie.X + player.Frame.Right)) {
                            // !(Tile ligt hoog)
                            if (!(Tile.Positie.Y + Tile.Frame.Top < player.Positie.Y + player.Frame.Top
                                && Tile.Positie.Y + Tile.Frame.Bottom < player.Positie.Y + player.Frame.Top)) {
                                // Tile is beneden
                                if (Tile.Positie.Y + Tile.Frame.Top <= player.Positie.Y + player.Frame.Bottom + richting.Y
                                    && Tile.Positie.Y + Tile.Frame.Bottom >= player.Positie.Y + player.Frame.Bottom) {
                                    if (Tile is IPassable) {
                                        IPassable temp = (IPassable)Tile;
                                        if (temp.PassBottom) continue;
                                    }
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
    }
}
