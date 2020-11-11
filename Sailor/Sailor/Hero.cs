using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sailor.Animation;
using Sailor.Commands;
using Sailor.Input;
using Sailor.Interfaces;
using Sailor.LoadSprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor
{
    class Hero : ITransform, IDrawEffect, IDrawState
    {
        Dictionary<CharacterState, List<Texture2D>> heroTextures;
        Animatie animatie;
        public Vector2 positie { get; set; }
        public Rectangle frame { get; set; }
        public SpriteEffects effect { get; set; }
        public CharacterState state { get; set; }

        private IInputReader inputReader;
        private Vector2 richting;

        // Moet nog weggehaald worden
        private IGameCommands moveCommands = new MoveCommand();
        private IGameCommands jumpCommands = new JumpCommand();
        private AnimatieEffect animatieEffect = new AnimatieEffect();
        private AnimatieState animatieState = new AnimatieState();

        public Hero(Dictionary<CharacterState, List<Texture2D>> texture, IInputReader reader)
        {
            heroTextures = texture;
            animatie = new Animatie();
            inputReader = reader;
            // Vinden waar de eerste staat
            positie = new Vector2(75, 350);
            state = CharacterState.Idle;
        }

        public void Update(GameTime gameTime)
        {
            richting = inputReader.ReadInput();
            CheckEffects();
            ExecuteCommands(richting);
            animatie.AddFrames(heroTextures[state]);
            // hier iets voor vinden
            frame = animatie.SourceRectangle;
            animatie.Update(gameTime);
        }

        private void CheckEffects()
        {
            animatieEffect.Check(this, richting);
            animatieState.Check(this, richting);
        }

        private void ExecuteCommands(Vector2 richting)
        {
            jumpCommands.Execute(this, richting);
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
