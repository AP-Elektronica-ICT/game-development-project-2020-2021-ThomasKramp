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
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Dictionary<CharacterState, List<Texture2D>> PlayerTextures;
        Dictionary<CharacterState, List<Texture2D>> CucumberTextures;
        Dictionary<SurroundingObjects, List<Texture2D>> ForegroundTextures;
        Dictionary<SurroundingObjects, List<Texture2D>> BackgroundTextures;
        public static List<DynamicBlok> sailors;
        public static Foreground Foreground;
        Background background;
        Camera2d camera;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 1750/2;
            _graphics.PreferredBackBufferHeight = 750;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            //camera = new Camera2d(GraphicsDevice.Viewport);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            PlayerTextures = LoadTextures.LoadCharacterSprites("Sailor", Content);
            CucumberTextures = LoadTextures.LoadCharacterSprites("Cucumber", Content);
            ForegroundTextures = LoadTextures.LoadSurroundingsSprites("Foreground", Content);
            BackgroundTextures = LoadTextures.LoadSurroundingsSprites("Background", Content);
            //DSTextures.LoadSprites(Content);
            //CuTextures.LoadSprites(Content);
            //InitializeGameObject();

            //FGTexture.LoadSprites(Content);
            //InitializeForegound();

            //BGTexture.LoadSprites(Content);
            //InitializeBackgound();

            // TODO: use this.Content to load your game content here
        }

        //private void InitializeGameObject()
        //{
        //    sailors = new List<DynamicBlok>()
        //    {
        //        new Player(DSTextures.textureDic, new KeyBoardReader()),
        //        new Enemy(CuTextures.textureDic)
        //    };
        //}

        //private void InitializeForegound()
        //{
        //    Game1.Foreground = new Foreground(FGTexture.textureDic);
        //    Game1.Foreground.CreateWorld();
        //}

        //private void InitializeBackgound()
        //{
        //    background = new Background(BGTexture.textureList);
        //    background.CreateWorld();
        //}

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            //foreach (var sailor in sailors)
            //{
            //    sailor.Update(gameTime);
            //}
            //camPos = Vector2.Subtract(sailors[0].Positie, new Vector2(
            //    this.Window.ClientBounds.Width/2 - 250,
            //    this.Window.ClientBounds.Height/2 + 100));
            base.Update(gameTime);
        }

        float rotation = 0;
        float zoom = 1;
        public Vector2 camPos = new Vector2();

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            //var viewMatrix = camera.GetViewMatrix();
            //camera.Position = camPos;
            //camera.Rotation = rotation;
            //camera.Zoom = zoom;

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            //transformMatrix: viewMatrix
            //background.DrawWorld(_spriteBatch);

            //Game1.Foreground.DrawWorld(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
