using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Sound
{
    class PlayBackgroundSound 
    { 
        public static void PlayBackground()
        {
            MediaPlayer.Play(Game1.BackGroundSound[0]);
            // Uncomment the following line will also loop the song
            MediaPlayer.IsRepeating = true;
        }
        public static void PlayGameOver()
        {
            MediaPlayer.Play(Game1.BackGroundSound[1]);
            MediaPlayer.IsRepeating = true;
        }
    }
}
