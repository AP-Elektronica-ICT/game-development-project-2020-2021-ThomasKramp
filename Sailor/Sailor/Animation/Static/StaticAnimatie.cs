using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sailor.LoadSprites;
using Sailor.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Animation.Static
{
    class StaticAnimatie
    {
        private int counter = 0;
        private double frameMovement = 0;

        public void Update(DoorBlok door, List<Texture2D> Textures, GameTime gameTime)
        {
            if (counter >= Textures.Count)
            {
                counter = 0;
                if (door.State == DoorState.Opening)
                    door.State = DoorState.Open;
                if (door.State == DoorState.Closing)
                    door.State = DoorState.Closed;
            }

            door.CurrentTexture = Textures[counter];

            // Sprites besnijden indien er nog tijd over is
            door.Frame = new Rectangle(0, 0, door.CurrentTexture.Width, door.CurrentTexture.Height);

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
