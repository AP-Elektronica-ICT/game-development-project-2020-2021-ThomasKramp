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
            /*/ Het heeft geen effect om meer Frames toe te voegen
            for (int i = 0; i < heroTextures[state].Count; i++) {
                animatie.AddFrame(new AnimationFrame(new Rectangle(0, 0, 77, 74)));
            }/*/
            animatie.AddFrame(new AnimationFrame(new Rectangle(0, 0, 77, 74)));
            inputReader = reader;
            moveCommands = commands;
        }

        public void Update(GameTime gameTime)
        {
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
            if (counter >= heroTextures[state].Count)
            {
                counter = 0;
            }
            spriteBatch.Draw(heroTextures[state][counter], positie, animatie.CurrentFrame.SourceRectangle, 
                Color.White, BasicRotation, BasicOrigin, BasicScale, KeyBoardReader.effect, BasicLayerDepth);
            counter++;
        }
    }
}
