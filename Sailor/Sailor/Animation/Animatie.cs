using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Sailor.Animation
{
    class Animatie
    {
        public Texture2D CurrentFrame { get; set; }
        private List<Texture2D> frames;
        private int counter;
        private double frameMovement = 0;

        public Animatie()
        {
            frames = new List<Texture2D>();
        }

        public void AddFrames(List<Texture2D> Frames)
        {
            frames = Frames;
            CurrentFrame = frames[0];
        }

        public void Update(GameTime gameTime)
        {
            if (counter >= frames.Count)
            {
                counter = 0;
            }
            CurrentFrame = frames[counter];
            frameMovement += frames.Count * gameTime.ElapsedGameTime.TotalSeconds;
            // frames.Count/16 werkt ook
            if (frameMovement >= 1)
            {
                counter++;
                frameMovement = 0;
            }
        }
    }
}
