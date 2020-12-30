using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sailor.Animation.MoveAble;
using Sailor.Commands;
using Sailor.Commands.Attack;
using Sailor.Detection;
using Sailor.Interfaces;
using Sailor.Interfaces.Animation;
using Sailor.Interfaces.Commands;
using Sailor.LoadSprites;
using System.Collections.Generic;

namespace Sailor.World.Abstract
{
    public abstract class CharacterBlok : DynamicBlok, IChangeAble, IDrawState, IJumper, IPuncher, IThrower, IKillAble, IDeathFall
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
        MoveAbleAnimatie animatie;
        MoveAbleEffectAnimatie animatieEffect;
        MoveAbleStateAnimatie animatieState;
        JumpCommand jumpCommands;
        PunchCommand punchCommands;

        public CharacterBlok(Dictionary<CharacterState, List<Texture2D>> textures)
        {
            Textures = textures;
            #region Animatie
            animatie = new MoveAbleAnimatie();
            animatieEffect = new MoveAbleEffectAnimatie();
            animatieState = new MoveAbleStateAnimatie();
            #endregion
            #region Commands
            jumpCommands = new JumpCommand();
            punchCommands = new PunchCommand();
            #endregion
            state = CharacterState.Idle;
        }

        public override void Update(GameTime gameTime, List<DrawBlok> Surroundings, List<CharacterBlok> Targets, List<DynamicBlok> Thowables, IGameObject LowestTile)
        {
            #region Commands
            if (!Hit && !Dead)
            {
                punchCommands.Execute(this, Targets);
                base.Update(gameTime, Surroundings, Targets, Thowables, LowestTile);
                jumpCommands.Execute(this, richting, Surroundings);
                EndlessFallDetection.FallingToDeath(LowestTile, this);
            }
            #endregion

            #region Animatie
            animatieEffect.Update(this, richting);
            animatieState.Update(this, richting);
            animatie.Update(this, Textures[state], gameTime);
            #endregion
        }
    }
}
