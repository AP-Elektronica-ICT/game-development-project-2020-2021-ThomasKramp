using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
// Voor input keys library te implemteren
using Microsoft.Xna.Framework.Input;
using Sailor.Animation;
using Sailor.CollisionDetection;
using Sailor.Commands;
using Sailor.Input;
using Sailor.Interfaces;
using Sailor.LevelDesign;
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
        public SpriteEffects effect { get; set; }
        public CharacterState state { get; set; }

        private IInputReader inputReader;
        private IGameCommands moveCommands;
        private Vector2 richting;

        // Moet nog weggehaald worden
        private IGameCommands jumpCommand = new JumpCommand();
        private AnimatieEffect animatieEffect = new AnimatieEffect();
        private AnimatieState animatieState = new AnimatieState();

        public Hero(Dictionary<int, List<Texture2D>> texture, IInputReader reader, IGameCommands commands)
        {
            heroTextures = texture;
            animatie = new Animatie();
            inputReader = reader;
            moveCommands = commands;
            // Vinden waar de eerste staat
            positie = new Vector2(75, 350);
            state = CharacterState.Idle;
        }

        public void Update(GameTime gameTime)
        {
            animatie.AddFrames(heroTextures[(int)state]);
            richting = inputReader.ReadInput();
            frame = animatie.SourceRectangle;
            CheckEffects();
            ExecuteCommands(richting);
            animatie.Update(gameTime);
        }

        private void CheckEffects()
        {
            animatieEffect.Check(this, richting);
            animatieState.Check(this, richting);
        }

        private void ExecuteCommands(Vector2 richting)
        {
            jumpCommand.Execute(this, richting);
            moveCommands.Execute(this, richting);
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
                Color.White, BasicRotation, BasicOrigin, BasicScale, effect, BasicLayerDepth);
        }
    }
}
