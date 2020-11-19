using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sailor.Commands;
using Sailor.Interfaces;
using System.Collections.Generic;

namespace Sailor.Animation
{
    class Animatie
    {
        private int counter = 0;
        private double frameMovement = 0;

        public Animatie() { }

        public void Update(IDrawObject drawable, List<Texture2D> Textures, GameTime gameTime)
        {
            // De texture counter wordt gereset
            if (counter >= Textures.Count)
            {
                counter = 0;
                JumpCommand.Ground = false;
                AttackCommand.Attack = false;
            }

            // Gaat een nieuw texture inladen indien nodig
            drawable.CurrentTexture = Textures[counter];

            // Sprites besnijden indien er nog tijd over is
            // Kijkt telkens naar de groote van de sprite en implementeert de dimensies
            drawable.Frame = new Rectangle(0, 0, drawable.CurrentTexture.Width, drawable.CurrentTexture.Height);

            // Gaat de frame snelheid vertragen, afhankelijk van de hoeveelheid frames
            frameMovement += Textures.Count * gameTime.ElapsedGameTime.TotalSeconds;

            // Er wordt 1 bij de frame counter toegevoegd
                // 1 werkt ook
            if (frameMovement >= 0.5)
            {
                counter++;
                frameMovement = 0;
            }
        }
    }
}
