using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sailor.Animation;
using Sailor.Commands;
using Sailor.Input;
using Sailor.Interfaces;
using Sailor.LoadSprites;
using Sailor.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor
{
    class Player : Blok, IMoveAble, IDrawEffect, IDrawState
    {
        public Dictionary<CharacterState, List<Texture2D>> Textures { get; set; }
        public SpriteEffects effect { get; set; }
        public CharacterState state { get; set; }

        private IInputReader inputReader;
        private Vector2 richting;

        // Moet nog weggehaald worden
        Animatie animatie;
        AnimatieEffect animatieEffect;
        AnimatieState animatieState;
        IGameCommands moveCommands;
        IGameCommands jumpCommands;
        IGameCommands attackCommands;
        

        public Player(Dictionary<CharacterState, List<Texture2D>> textures, IInputReader reader)
        {
            Textures = textures;
            #region Animatie
            animatie = new Animatie();
            animatieEffect = new AnimatieEffect();
            animatieState = new AnimatieState();
            #endregion
            #region Commands
            moveCommands = new MoveCommand();
            jumpCommands = new JumpCommand();
            attackCommands = new AttackCommand();
            #endregion
            inputReader = reader;
            // Vinden waar de eerste staat
            Positie = new Vector2(75, 350);
            state = CharacterState.Idle;
        }

        public void Update(GameTime gameTime)
        {
            richting = inputReader.ReadInput();
            ExecuteCommands(richting);

            animatieEffect.Update(this, richting);
            animatieState.Update(this, richting);
            animatie.Update(this, Textures[state], gameTime);
        }

        private void ExecuteCommands(Vector2 richting)
        {
            attackCommands.Execute(this, richting);
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

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(CurrentTexture, Positie, Frame, Color.White, BasicRotation, BasicOrigin, BasicScale, effect, BasicLayerDepth);
        }
    }
}
