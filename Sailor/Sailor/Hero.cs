using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
// Voor input keys library te implemteren
using Microsoft.Xna.Framework.Input;
using Sailor.Animation;
using Sailor.Commands;
using Sailor.Input;
using Sailor.Interfaces;
using Sailor.LoadSprites;
using SharpDX.DXGI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor
{
    class Hero : ITransform
    {
        Dictionary<int, List<Texture2D>> heroTextures;
        private Rectangle SourceRectangle;
        Animatie animatie;
        private int counter = 0;
        public Vector2 positie { get; set; }
        private IInputReader inputReader;
        private IGameCommands moveCommands;
        public int state = (int) CharacterState.Idle;

        public Hero(Dictionary<int, List<Texture2D>> texture, IInputReader reader, IGameCommands commands)
        {
            heroTextures = texture;
            animatie = new Animatie();
            inputReader = reader;
            moveCommands = commands;
        }

        public void Update(GameTime gameTime)
        {
            animatie.AddFrames(heroTextures[state]);
            if (counter >= heroTextures[state].Count) counter = 0;
            SourceRectangle = new Rectangle(0, 0, heroTextures[state][counter].Width, heroTextures[state][counter].Height);

            Vector2 richting = inputReader.ReadInput();
            state = (int) KeyBoardReader.cState;
            MoveHorizontal(richting);
            animatie.Update(gameTime);
        }

        private void MoveHorizontal(Vector2 richting)
        {
            moveCommands.Execute(this, richting);
        }

        private Vector2 Limit(Vector2 v, int max)
        {
            if (v.Length() > max)
            {
                float ratio = max / v.Length();
                v.X *= ratio;
                v.Y *= ratio;
            }
            return v;
        }

        // Extra variabelen voor de draw methode
            //  A rotation of this sprite.
            float BasicRotation = 0f;
            // Center of the rotation. 0,0 by default.
            Vector2 BasicOrigin = new Vector2(0, 0);
            // A scaling of this sprite.
            float BasicScale = 1f;
            // A depth of the layer of this sprite.
            float BasicLayerDepth = 0f;

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(animatie.CurrentFrame, positie, SourceRectangle, 
                Color.White, BasicRotation, BasicOrigin, BasicScale, KeyBoardReader.effect, BasicLayerDepth);
            counter++;
        }
    }
}
