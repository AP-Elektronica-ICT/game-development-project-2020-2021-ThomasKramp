﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
// Voor input keys library te implemteren
using Microsoft.Xna.Framework.Input;
using Sailor.Animation;
using Sailor.CollisionDetection;
using Sailor.Commands;
using Sailor.Input;
using Sailor.Interfaces;
using Sailor.LoadSprites;
using SharpDX.Direct3D9;
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
        public Vector2 positie { get; set; }
        public Rectangle frame { get; set; }
        public Vector2 richting { get; set; }

        private IInputReader inputReader;
        private IGameCommands moveCommands;
        public int state = (int) CharacterState.Idle;
        private float valSnelheid = 0;

        public Hero(Dictionary<int, List<Texture2D>> texture, IInputReader reader, IGameCommands commands)
        {
            heroTextures = texture;
            animatie = new Animatie();
            inputReader = reader;
            moveCommands = commands;
            // Vinden waar de eerste staat
            positie = new Vector2(0, 000);
        }

        public void Update(GameTime gameTime)
        {
            animatie.AddFrames(heroTextures[state]);
            richting = inputReader.ReadInput();
            frame = animatie.SourceRectangle;
            state = (int) KeyBoardReader.cState;
            richting = MoveVertical(richting);
            MoveHorizontal(richting);
            animatie.Update(gameTime);
        }

        private Vector2 MoveVertical(Vector2 richting)
        {
            if (ColDetec.TopColliding(this))
            {
                KeyBoardReader.Jumped = false;
                valSnelheid = 0;
            }
            if (KeyBoardReader.Jumped)
            {
                if (valSnelheid == 0)
                {
                    valSnelheid = -100f;
                }
                else
                {
                    valSnelheid /= 1.25f;
                }
                if (valSnelheid > -1)
                {
                    KeyBoardReader.Jumped = false;
                }
            } else if (ColDetec.BottomColliding(this))
            {
                valSnelheid = 0;
            } else {
                valSnelheid += 1f;
            }
            richting.Y = valSnelheid;
            return richting;
        }

        private void MoveHorizontal(Vector2 richting)
        {
            if (!ColDetec.LeftColliding(this) && !ColDetec.RightColliding(this))
            {
                moveCommands.Execute(this, richting);
            }
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
            spriteBatch.Draw(animatie.CurrentFrame, positie, animatie.SourceRectangle, 
                Color.White, BasicRotation, BasicOrigin, BasicScale, KeyBoardReader.effect, BasicLayerDepth);
        }
    }
}
