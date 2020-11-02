using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Sailor.Animation
{
    class Animatie
    {
        public Rectangle SourceRectangle { get; set; }
        public Texture2D CurrentFrame { get; set; }
        private List<Texture2D> frames;
        private int counter;
        private double frameMovement = 0;

        public Animatie()
        {
            frames = new List<Texture2D>();
        }

        public void AddFrames(List<Texture2D> frameLijst)
        {
            frames = frameLijst;
            CurrentFrame = frames[0];
        }

        public void Update(GameTime gameTime)
        {
            // De frame counter wordt gereset
            if (counter >= frames.Count) counter = 0;

            // Gaat een nieuw frame inladen indien nodig
            CurrentFrame = frames[counter];

            // Kijkt telkens naar de groote van de sprite en implementeert de dimensies
            SourceRectangle = new Rectangle(0, 0, CurrentFrame.Width, CurrentFrame.Height);

            // Gaat de frame snelheid vertragen, afhankelijk van de hoeveelheid frames
            frameMovement += frames.Count * gameTime.ElapsedGameTime.TotalSeconds;

            // Er wordt 1 bij de frame counter toegevoegd
                // frames.Count/16 werkt ook
            if (frameMovement >= 1)
            {
                counter++;
                frameMovement = 0;
            }
        }
    }
}
