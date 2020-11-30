using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sailor.Input;
using Sailor.LevelDesign;
using Sailor.LoadSprites;
using Sailor.World;
using System;
using System.Collections.Generic;

namespace Sailor
{
    public class Game1 : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;

        public static List<DynamicBlok> sailors;
        Level DemoLevel;
        Camera2d camera;

        Dictionary<CharacterState, List<Texture2D>> PlayerTextures;
        Dictionary<CharacterState, List<Texture2D>> CucumberTextures;
        Dictionary<SurroundingObjects, List<Texture2D>> ForegroundTextures;
        Dictionary<SurroundingObjects, List<Texture2D>> BackgroundTextures;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 1750;
            _graphics.PreferredBackBufferHeight = 750;
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
            CucumberTextures = LoadTextures.LoadCharacterSprites("Cucumber", Content);
            InitializeGameObject();

            ForegroundTextures = LoadTextures.LoadSurroundingsSprites("Foreground", Content);
            BackgroundTextures = LoadTextures.LoadSurroundingsSprites("Background", Content);
            InitializeSurroundings();

            // TODO: use this.Content to load your game content here
        }

        private void InitializeGameObject()
        {
            sailors = new List<DynamicBlok>()
            {
                new Player(PlayerTextures, new KeyBoardReader()),
                new Enemy(CucumberTextures)
            };
        }

        private void InitializeSurroundings()
        {
            DemoLevel = new Level(BackgroundTextures, ForegroundTextures);
            DemoLevel.CreateWorld();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            foreach (var sailor in sailors)
            {
                sailor.Update(gameTime, DemoLevel.Surroundings);
            }
            camPos = Vector2.Subtract(sailors[0].Positie, new Vector2(
                this.Window.ClientBounds.Width / 5,
                7 * this.Window.ClientBounds.Height / 10));
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
