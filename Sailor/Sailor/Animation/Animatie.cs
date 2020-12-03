using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sailor.World.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Animation
{
    class Animatie
    {
        private int counter = 0;
        private double frameMovement = 0;

        public Animatie() { }

        public void Update(DynamicBlok drawable, List<Texture2D> Textures, GameTime gameTime)
        {
            if (counter >= Textures.Count)
            {
                counter = 0;
                drawable.Attack = false;
            }

            drawable.CurrentTexture = Textures[counter];

            // Sprites besnijden indien er nog tijd over is
            drawable.Frame = new Rectangle(0, 0, drawable.CurrentTexture.Width, drawable.CurrentTexture.Height);

            // Gaat de frame snelheid vertragen, afhankelijk van de hoeveelheid frames
            frameMovement += Math.Sqrt(Textures.Count) * gameTime.ElapsedGameTime.TotalSeconds;

            // Er wordt 1 bij de frame counter toegevoegd
                // 1 werkt ook
            if (frameMovement >= 0.25)
            {
                counter++;
                frameMovement = 0;
            }

            
        }
    }
}
