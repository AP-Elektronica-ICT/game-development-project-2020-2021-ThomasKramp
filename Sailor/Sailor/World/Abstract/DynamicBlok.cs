using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sailor.Animation;
using Sailor.Commands;
using Sailor.Commands.Attack;
using Sailor.Interfaces;
using Sailor.Interfaces.Animation;
using Sailor.Interfaces.Commands;
using Sailor.LoadSprites;
using System.Collections.Generic;

namespace Sailor.World.Abstract
{
    public abstract class DynamicBlok : SpecialDrawBlok, IChangeAble, IDrawState, IJumper, IPuncher, IThrower, IKillAble
    {
        public Dictionary<CharacterState, List<Texture2D>> Textures { get; set; }

        #region AnimationVariables
        public CharacterState state { get; set; }
        #endregion

        #region StateVariables
        public bool Jumped { get; set; }
        public bool Falling { get; set; }
        public bool Punch { get; set; }
        public bool Throw { get; set; }
        public bool Dead { get; set; }
        #endregion
        public int Levens { get; set; }

        // Moet nog weggehaald worden
        Animatie animatie;
        AnimatieEffect animatieEffect;
        AnimatieState animatieState;
        protected IGameCommands moveCommands;
        IGameCommands jumpCommands;
        PunchCommand punchCommands;

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
            punchCommands = new PunchCommand();
            #endregion
            state = CharacterState.Idle;
        }

        public override void Update(GameTime gameTime, List<DrawBlok> Surroundings, List<DynamicBlok> Targets, List<SpecialDrawBlok> Thowables)
        {
            #region Commands
            if (!Hit && !Dead)
            {
                punchCommands.Execute(this, Targets);
                jumpCommands.Execute(this, richting, Surroundings);
                moveCommands.Execute(this, richting, Surroundings);
            }
            #endregion

            #region Animatie
            animatieEffect.Update(this, richting);
            animatieState.Update(this, richting);
            animatie.Update(this, Textures[state], gameTime);
            #endregion

            base.Update(gameTime, Surroundings, Targets, Thowables);
        }
    }
}
