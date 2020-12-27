using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Sailor.Detection;
using Sailor.Input;
using Sailor.Interfaces;
using Sailor.LevelDesign;
using Sailor.LevelDesign.Schematics;
using Sailor.LoadSprites;
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
        Level CurrentLevel;
        Level FirstLevel;
        Level SecondLevel;
        Camera2d camera;

        #region Textures
        Dictionary<CharacterState, List<Texture2D>> PlayerTextures;
        List<Dictionary<CharacterState, List<Texture2D>>> EnemyTextures;
        List<Dictionary<SurroundingObjects, List<Texture2D>>> LevelTextures;
        Dictionary<DoorState, List<Texture2D>> DoorTextures;
        public static List<Texture2D> BottleTextures;
        #endregion

        public static bool ChangeMaps = false;

        Song song;

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

            BottleTextures = LoadTextures.LoadAttakObjectsSprites("Bottle", Content);

            PlayerTextures = LoadTextures.LoadCharacterSprites("Sailor", Content);
            InitializeGameObject();

            EnemyTextures.Add(LoadTextures.LoadCharacterSprites("Cucumber", Content));
            LevelTextures.Add(LoadTextures.LoadSurroundingsSprites("Background", Content));
            LevelTextures.Add(LoadTextures.LoadSurroundingsSprites("Surroundings", Content));
            DoorTextures = LoadTextures.LoadDoorSprites("Door", Content);
            InitializeSurroundings();

            // this.song = Content.Load<Song>("The Rocky Road To Dublin");
            // MediaPlayer.Play(song);
            //  Uncomment the following line will also loop the song
            //  MediaPlayer.IsRepeating = true;

            // TODO: use this.Content to load your game content here
        }

        private void InitializeGameObject()
        {
            Player = new Player(PlayerTextures, new KeyBoardReader());
        }

        private void InitializeSurroundings()
        {
            FirstLevel = new Level(LevelTextures, EnemyTextures, DoorTextures);
            FirstLevel.CreateWorld(Player, new FirstSchematic());
            SecondLevel = new Level(LevelTextures, EnemyTextures, DoorTextures);
            SecondLevel.CreateWorld(Player, new SecondSchematic());
            CurrentLevel = FirstLevel;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            Player.Update(gameTime, CurrentLevel.Surroundings, CurrentLevel.Enemies, CurrentLevel.ThrowAbles);

            camPos = Vector2.Subtract(Player.Positie, new Vector2(
                this.Window.ClientBounds.Width / 5,
                7 * this.Window.ClientBounds.Height / 10));

            foreach (var door in CurrentLevel.Doors)
            {
                door.Update(gameTime, Player);
            }
            foreach (var bottle in CurrentLevel.ThrowAbles)
            {
                bottle.Update(gameTime, CurrentLevel.Surroundings, CurrentLevel.Enemies, CurrentLevel.ThrowAbles);
            }
            foreach (var enemy in CurrentLevel.Enemies)
            {
                enemy.Update(gameTime, CurrentLevel.Surroundings, new List<CharacterBlok>() { Player }, CurrentLevel.ThrowAbles);
            }

            CurrentLevel.RemoveDead(Player);
            CurrentLevel.RemoveSpecialBloks();

            ChangeLevel(CurrentLevel.Doors, Player);
            base.Update(gameTime);
        }

        private void ChangeLevel(List<DoorBlok> doors, IGameObject player)
        {
            if (ChangeMaps)
            {
                ChangeMaps = false;
                System.Threading.Thread.Sleep(100);
                foreach (var door in doors)
                {
                    if (PlayerDetection.StandsWithin(door, player))
                    {
                        if (door == doors[0])
                        {
                            player.Positie = SecondLevel.Doors[1].Positie;
                            CurrentLevel.Surroundings.Remove(Player);
                            CurrentLevel = SecondLevel;
                            CurrentLevel.Surroundings.Add(Player);
                            break;
                        }
                        else if (door == doors[1])
                        {
                            player.Positie = SecondLevel.Doors[0].Positie;
                            CurrentLevel.Surroundings.Remove(Player);
                            CurrentLevel = SecondLevel;
                            CurrentLevel.Surroundings.Add(Player);
                            break;
                        }
                    }
                }
            }
        }

        float rotation = 0;
        float zoom = 1;
        public Vector2 camPos = new Vector2();

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            var viewMatrix = camera.GetViewMatrix();
            camera.Position = camPos;
            camera.Rotation = rotation;
            camera.Zoom = zoom;

            // TODO: Add your drawing code here

            _spriteBatch.Begin(transformMatrix: viewMatrix);

            CurrentLevel.DrawWorld(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
