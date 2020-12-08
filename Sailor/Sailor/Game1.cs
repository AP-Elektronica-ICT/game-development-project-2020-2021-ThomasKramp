using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Sailor.Input;
using Sailor.LevelDesign;
using Sailor.LoadSprites;
using Sailor.World;
using Sailor.World.Abstract;
using System.Collections.Generic;

namespace Sailor
{
    public class Game1 : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;

        DynamicBlok Player;
        Level DemoLevel;
        Camera2d camera;

        Dictionary<CharacterState, List<Texture2D>> PlayerTextures;
        List<Dictionary<CharacterState, List<Texture2D>>> EnemyTextures;
        List<Dictionary<SurroundingObjects, List<Texture2D>>> LevelTextures;

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

            PlayerTextures = LoadTextures.LoadCharacterSprites("Sailor", Content);
            InitializeGameObject();

            EnemyTextures.Add(LoadTextures.LoadCharacterSprites("Cucumber", Content));
            LevelTextures.Add(LoadTextures.LoadSurroundingsSprites("Background", Content));
            LevelTextures.Add(LoadTextures.LoadSurroundingsSprites("Surroundings", Content));
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
            DemoLevel = new Level(LevelTextures, EnemyTextures);
            DemoLevel.AddEnemies();
            DemoLevel.CreateWorld(Player);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            Player.Update(gameTime, DemoLevel.Surroundings, DemoLevel.Enemies);

            camPos = Vector2.Subtract(Player.Positie, new Vector2(
                this.Window.ClientBounds.Width / 5,
                7 * this.Window.ClientBounds.Height / 10));

            foreach (var enemy in DemoLevel.Enemies)
            {
                enemy.Update(gameTime, DemoLevel.Surroundings, new List<DynamicBlok>() { Player });
            }
            DemoLevel.RemoveDead(Player);
            base.Update(gameTime);
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

            DemoLevel.DrawWorld(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
