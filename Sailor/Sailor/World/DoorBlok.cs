using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sailor.Animation.Static;
using Sailor.Interfaces;
using Sailor.Interfaces.Animation.Door;
using Sailor.LoadSprites;
using Sailor.World.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.World
{
    public enum DoorType { Next, Previous, End}
    class DoorBlok : DrawBlok, IDrawDoorState
    {
        public DoorState State { get; set; }
        public DoorType Type { get; set; }

        Dictionary<DoorState, List<Texture2D>> textures;

        StaticAnimatie animatie;
        StaticStateAnimatie animatieState;

        public DoorBlok(Dictionary<DoorState, List<Texture2D>> textures, Vector2 positie, DoorType doorType)
        {
            Positie = positie;
            this.textures = textures;
            CurrentTexture = this.textures[State][0];
            Frame = new Rectangle(0, 0, CurrentTexture.Width, CurrentTexture.Height);

            animatie = new StaticAnimatie();
            animatieState = new StaticStateAnimatie();

            State = DoorState.Closed;
            Type = doorType;
        }

        public void Update(GameTime gameTime, IGameObject player)
        {
            animatieState.Update(this, player);
            animatie.Update(this, textures[State], gameTime);
        }
    }
}
