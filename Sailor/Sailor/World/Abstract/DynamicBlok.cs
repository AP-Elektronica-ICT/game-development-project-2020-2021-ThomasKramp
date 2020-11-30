using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sailor.Animation;
using Sailor.Commands;
using Sailor.Interfaces;
using Sailor.Interfaces.Animation;
using Sailor.Interfaces.Commands;
using Sailor.LoadSprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.World.Abstract
{
    public abstract class DynamicBlok : DrawBlok, IChangeAble, IDrawEffect, IDrawState, IJumper, IAttacker
    {
        public Dictionary<CharacterState, List<Texture2D>> Textures { get; set; }

        public SpriteEffects effect { get; set; }
        public CharacterState state { get; set; }

        public bool Jumped { get; set; }
        public bool Falling { get; set; }
        public bool Ground { get; set; }
        public bool Attack { get; set; }
        public int Levens { get; set; }

        protected Vector2 richting;

        // Moet nog weggehaald worden
        Animatie animatie;
        AnimatieEffect animatieEffect;
        AnimatieState animatieState;
        protected IGameCommands moveCommands;
        IGameCommands jumpCommands;
        IGameCommands attackCommands;

        public DynamicBlok(Dictionary<CharacterState, List<Texture2D>> textures)
        {
            Textures = textures;
            #region Animatie
            animatie = new Animatie();
            animatieEffect = new AnimatieEffect();
            animatieState = new AnimatieState();
            #endregion
            #region Commands
            jumpCommands = new JumpCommand();
            attackCommands = new AttackCommand();
            #endregion
            state = CharacterState.Idle;
        }

        public virtual void Update(GameTime gameTime, List<DrawBlok> Surroundings)
        {
            attackCommands.Execute(this, richting, Surroundings);
            jumpCommands.Execute(this, richting, Surroundings);
            moveCommands.Execute(this, richting, Surroundings);

            animatieEffect.Update(this, richting);
            animatieState.Update(this, richting);
            animatie.Update(this, Textures[state], gameTime);
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
