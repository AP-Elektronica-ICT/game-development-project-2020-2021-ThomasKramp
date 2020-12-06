using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sailor.World.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.World.Attack
{
    class ThrowBlok : DrawBlok
    {
        public ThrowBlok(Texture2D blokTexture, Vector2 positie)
        {
            CurrentTexture = blokTexture;
            this.Positie = positie;
            Frame = new Rectangle(0, 0, CurrentTexture.Width, CurrentTexture.Height);
        }

        #region DrawVariables
        // Extra variabelen voor de draw methode
        //  A rotation of this sprite.
        float BasicRotation = 0f;
        // Center of the rotation. 0,0 by default.
        Vector2 BasicOrigin = new Vector2(0, 0);
        // A scaling of this sprite.
        float BasicScale = 1f;
        // An effect of this sprite
        SpriteEffects BasicEffect = SpriteEffects.None;
        // A depth of the layer of this sprite.
        float BasicLayerDepth = 0f;
        #endregion

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(CurrentTexture, Positie, Frame, Color.White, BasicRotation, BasicOrigin, BasicScale, BasicEffect, BasicLayerDepth);
        }
    }
}
