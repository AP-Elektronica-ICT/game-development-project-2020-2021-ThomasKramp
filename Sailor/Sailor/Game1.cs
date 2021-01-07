using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Sailor.Animation.MoveAble;
using Sailor.Commands;
using Sailor.Commands.Attack;
using Sailor.Commands.Move;
using Sailor.Detection;
using Sailor.Input;
using Sailor.Interfaces;
using Sailor.LevelDesign;
using Sailor.LevelDesign.Schematics;
using Sailor.LoadSounds;
using Sailor.LoadSprites;
using Sailor.Sound;
using Sailor.World;
using Sailor.World.Abstract;
using System;
using System.Collections.Generic;

namespace Sailor
{
    public class Game1 : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;

        CharacterBlok Player;
        DrawBlok GameOverScreen;

        #region Levels
        ILevel CurrentLevel;
        List<ILevel> Levels;
        #endregion
        #region Textures
        Dictionary<CharacterState, List<Texture2D>> PlayerTextures;
        List<Dictionary<CharacterState, List<Texture2D>>> EnemyTextures;
        List<Dictionary<SurroundingObjects, List<Texture2D>>> LevelTextures;
        Dictionary<DoorState, List<Texture2D>> DoorTextures;
        public static List<Texture2D> BottleTextures;
        List<Texture2D> SignTextures;
        #endregion
        #region Camera
        Camera2d camera;
        float rotation = 0;
        float zoom = 1;
        public Vector2 camPos = new Vector2();
        #endregion
        #region Sound
        public static List<Song> BackGroundSound;
        public static List<SoundEffect> CharacterSound;
        #endregion

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 1750;
            _graphics.PreferredBackBufferHeight = 750;

            EnemyTextures = new List<Dictionary<CharacterState, List<Texture2D>>>();
            LevelTextures = new List<Dictionary<SurroundingObjects, List<Texture2D>>>();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            camera = new Camera2d(GraphicsDevice.Viewport);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            BackGroundSound = LoadSongs.LoadSong("Background", Content);
            CharacterSound = LoadSongs.LoadEffect("Character", Content);
            PlayBackgroundSound.PlayBackground();

            BottleTextures = LoadTextures.LoadSingleObjectsSprites("Bottle", Content);

            PlayerTextures = LoadTextures.LoadCharacterSprites("Sailor", Content);
            InitializeGameObject();

            EnemyTextures.Add(LoadTextures.LoadCharacterSprites("Cucumber", Content));
            LevelTextures.Add(LoadTextures.LoadSurroundingsSprites("Background", Content));
            LevelTextures.Add(LoadTextures.LoadSurroundingsSprites("Surroundings", Content));
            LevelTextures.Add(LoadTextures.LoadSurroundingsSprites("Foreground", Content));
            DoorTextures = LoadTextures.LoadDoorSprites("Door", Content);
            InitializeLevels();

            GameOverScreen = new StaticBlok(LoadTextures.LoadSingleObjectsSprites("GameOver", Content)[0],
                new Vector2((_graphics.PreferredBackBufferWidth - 512) / 2, (_graphics.PreferredBackBufferHeight - 224) / 2));

            // TODO: use this.Content to load your game content here
        }

        #region LoadContentMethods
        private void InitializeGameObject()
        {
            Player = new Player(PlayerTextures, new KeyBoardReader(), 10, 5, 35, new MoveAbleAnimatie(), new MoveAbleEffectAnimatie(), new MoveAbleStateAnimatie(),
                new JumpCommand(), new PunchCommand(), new PlayerMoveCommand(new Vector2(3, 0)), new ThrowCommand());
        }

        private void InitializeLevels()
        {
            List<Schematic> Schematics = new List<Schematic>()
            {
                new StartSchematic(),
                new TutorialSchematic(),
                new FirstSchematic(),
                new SecondSchematic(),
                new EndSchematic()
            };
            Levels = new List<ILevel>();
            for (int i = 0; i < Schematics.Count; i++)
            {
                Levels.Add(new Level(LevelTextures, EnemyTextures, DoorTextures));
            }
            foreach (var level in Levels)
            {
                level.CreateWorld(Player, Schematics[Levels.IndexOf(level)]);
            }
            CurrentLevel = Levels[2];
        }
        #endregion

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            Player.Update(gameTime, CurrentLevel.Surroundings, CurrentLevel.Enemies, CurrentLevel.ThrowAbles, CurrentLevel.LowestTile);

            if (Player.Levens > 0)
            {
                camPos = Vector2.Subtract(Player.Positie, new Vector2(
                this.Window.ClientBounds.Width / 5,
                7 * this.Window.ClientBounds.Height / 10));

                foreach (var door in CurrentLevel.Doors)
                {
                    door.Update(gameTime, Player);
                }
                foreach (var bottle in CurrentLevel.ThrowAbles)
                {
                    bottle.Update(gameTime, CurrentLevel.Surroundings, CurrentLevel.Enemies, CurrentLevel.ThrowAbles, CurrentLevel.LowestTile);
                }
                foreach (var enemy in CurrentLevel.Enemies)
                {
                    enemy.Update(gameTime, CurrentLevel.Surroundings, new List<CharacterBlok>() { Player }, CurrentLevel.ThrowAbles, CurrentLevel.LowestTile);
                }

                CurrentLevel.RemoveDead(Player);
                CurrentLevel.RemoveSpecialBloks();

                ChangeLevel(CurrentLevel.Doors, Player);
            } else {
                if (camPos != Vector2.Zero) PlayBackgroundSound.PlayGameOver();
                camPos = Vector2.Zero;
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    System.Threading.Thread.Sleep(100);
                    LoadContent();
                }
            }

            base.Update(gameTime);
        }

        #region UpdateMethods
        private void ChangeLevel(List<DoorBlok> doors, IGameObject player)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                System.Threading.Thread.Sleep(100);
                foreach (var door in doors)
                {
                    if (PlayerDetection.StandsWithin(door, player))
                    {
                        foreach (var level in Levels)
                        {
                            if (level.Doors.Contains(door))
                            {
                                int levelIndex = Levels.IndexOf(level);
                                CurrentLevel.Surroundings.Remove(Player);
                                ILevel warpLevel;
                                switch (door.Type)
                                {
                                    case DoorType.Next:
                                        // Gaat een level verder
                                        warpLevel = Levels[levelIndex + 1];
                                        foreach (var warpDoor in warpLevel.Doors)
                                        {
                                            if (warpDoor.Type == DoorType.Previous) player.Positie = warpDoor.Positie;
                                        }
                                        CurrentLevel = warpLevel;
                                        break;
                                    case DoorType.Previous:
                                        // Gaat een level terug
                                        warpLevel = Levels[levelIndex - 1];
                                        foreach (var warpDoor in warpLevel.Doors)
                                        {
                                            if (warpDoor.Type == DoorType.Next) player.Positie = warpDoor.Positie;
                                        }
                                        CurrentLevel = warpLevel;
                                        break;
                                    case DoorType.End:
                                        // Eindigt het spel
                                        Exit();
                                        break;
                                    default:
                                        break;
                                }
                                CurrentLevel.Surroundings.Add(Player);
                            }
                        }
                    }
                }
            }
        }
        #endregion

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            var viewMatrix = camera.GetViewMatrix();
            camera.Position = camPos;
            camera.Rotation = rotation;
            camera.Zoom = zoom;

            // TODO: Add your drawing code here

            _spriteBatch.Begin(transformMatrix: viewMatrix);

            if (Player.Levens > 0) CurrentLevel.DrawWorld(_spriteBatch);
            else GameOverScreen.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
