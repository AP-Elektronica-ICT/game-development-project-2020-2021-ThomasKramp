using Sailor.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Detection
{
    class PlayerDetection
    {
        public static float Search(IGameObject searcher, IGameObject player)
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
                    return (player.Positie.X + player.Frame.Center.X) - (searcher.Positie.X + searcher.Frame.Center.X);
                }
            }
            return 0;
        }
    }
}
