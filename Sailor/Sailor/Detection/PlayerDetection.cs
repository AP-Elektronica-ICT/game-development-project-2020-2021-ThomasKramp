using Sailor.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Detection
{
    class PlayerDetection
    {
        public static float SearchCenter(IGameObject searcher, IGameObject player)
        {
            // Top = 0      Bottom = ∞
            // Links = 0    Rechts = ∞
            // Ziet of blokken bestaan
            
            // !(Tile ligt te hoog)
            if (!(player.Positie.Y + player.Frame.Top < searcher.Positie.Y + searcher.Frame.Top
                && player.Positie.Y + player.Frame.Bottom < searcher.Positie.Y + searcher.Frame.Top))
            {
                // !(Tile ligt te laag)
                if (!(player.Positie.Y + player.Frame.Top > searcher.Positie.Y + searcher.Frame.Bottom
                    && player.Positie.Y + player.Frame.Bottom > searcher.Positie.Y + searcher.Frame.Bottom))
                {
                    return player.Positie.X + player.Frame.Center.X - (searcher.Positie.X + searcher.Frame.Center.X);
                }
            }
            return 1024;
        }

        public static float SearchSides(IGameObject searcher, IGameObject player)
        {
            // Top = 0      Bottom = ∞
            // Links = 0    Rechts = ∞
            // Ziet of blokken bestaan

            // !(Tile ligt te hoog)
            if (!(player.Positie.Y + player.Frame.Top < searcher.Positie.Y + searcher.Frame.Top
                && player.Positie.Y + player.Frame.Bottom < searcher.Positie.Y + searcher.Frame.Top))
            {
                // !(Tile ligt te laag)
                if (!(player.Positie.Y + player.Frame.Top > searcher.Positie.Y + searcher.Frame.Bottom
                    && player.Positie.Y + player.Frame.Bottom > searcher.Positie.Y + searcher.Frame.Bottom))
                {
                    float left = player.Positie.X + player.Frame.Right - (searcher.Positie.X + searcher.Frame.Left);
                    float right = player.Positie.X + player.Frame.Left - (searcher.Positie.X + searcher.Frame.Right);
                    if (Math.Abs(left) < Math.Abs(right)) return left;
                    else return right;
                }
            }
            return 1024;
        }

        public static bool StandsWithin(IGameObject searcher, IGameObject player)
        {
            // Links = 0    Rechts = ∞
            // Top = 0      Bottom = ∞

            // !(Tile ligt te ver links)
            if (!(player.Positie.X + player.Frame.Left < searcher.Positie.X + searcher.Frame.Left
                && player.Positie.X + player.Frame.Right < searcher.Positie.X + searcher.Frame.Left))
            {
                // !(Tile ligt te ver rechts)
                if (!(player.Positie.X + player.Frame.Left > searcher.Positie.X + searcher.Frame.Right
                    && player.Positie.X + player.Frame.Right > searcher.Positie.X + searcher.Frame.Right))
                {
                    // !(Tile ligt te hoog)
                    if (!(player.Positie.Y + player.Frame.Top < searcher.Positie.Y + searcher.Frame.Top
                        && player.Positie.Y + player.Frame.Bottom < searcher.Positie.Y + searcher.Frame.Top))
                    {
                        // !(Tile ligt te laag)
                        if (!(player.Positie.Y + player.Frame.Top > searcher.Positie.Y + searcher.Frame.Bottom
                            && player.Positie.Y + player.Frame.Bottom > searcher.Positie.Y + searcher.Frame.Bottom))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
