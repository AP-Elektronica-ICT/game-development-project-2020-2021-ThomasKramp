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
        private int prevTecturesCount = 0;

        public Animatie() { }

        public void Update(DynamicBlok drawable, List<Texture2D> Textures, GameTime gameTime)
        {
            if (Textures.Count != prevTecturesCount)
            {
                // Zonder dit:
                // Reset de animatie terwijl hij nog moet afspelen
                // Dit komt doordat de vorige state meer textures had (BV: Idle = 38)
                // Counter staat op 27 en AttackTextures.Count = 9
                // Dus er gebeurt een reset van animatie
                counter = 0;
                prevTecturesCount = Textures.Count;
            }
            if (counter >= Textures.Count)
            {
                counter = 0;
                drawable.Punch = false;
                drawable.Hit = false;
                drawable.Throw = false;
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
