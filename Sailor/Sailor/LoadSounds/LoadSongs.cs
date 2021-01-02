using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.LoadSounds
{
    class LoadSongs
    {
        public static List<Song> LoadSong(String Directory, ContentManager Content)
        {
            System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo($"Content\\SoundTrack\\{Directory}");
            List<Song> tempList = new List<Song>();
            for (int j = 0; j < directory.GetFiles().Length; j++)
            {
                try
                {
                    tempList.Add(Content.Load<Song>($"SoundTrack\\{Directory}\\{Directory + (j + 1).ToString()}"));
                }
                catch (Exception)
                {
                    break;
                    throw;
                }
            }
            return tempList;
        }
        public static List<SoundEffect> LoadEffect(String Directory, ContentManager Content)
        {
            System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo($"Content\\SoundTrack\\{Directory}");
            List<SoundEffect> tempList = new List<SoundEffect>();
            for (int j = 0; j < directory.GetFiles().Length; j++)
            {
                try
                {
                    tempList.Add(Content.Load<SoundEffect>($"SoundTrack\\{Directory}\\{Directory + (j + 1).ToString()}"));
                }
                catch (Exception)
                {
                    break;
                    throw;
                }
            }
            return tempList;
        }
    }
}
