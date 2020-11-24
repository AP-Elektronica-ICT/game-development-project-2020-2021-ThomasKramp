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
        private LoadDrunkenSailor DSTextures;
        private LoadCucumber CuTextures;
        private LoadBackground BGTexture;
        private LoadForeground FGTexture;
        public static int ConsoleWidth;
        public static int ConsoleHeigth;
        public static List<DynamicBlok> sailors;
        public static Foreground Foreground;
        Background background;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            BGTexture = new LoadBackground();
            CuTextures = new LoadCucumber();
            FGTexture = new LoadForeground();
            DSTextures = new LoadDrunkenSailor();
            _graphics.PreferredBackBufferWidth = 1750;
            _graphics.PreferredBackBufferHeight = 750;
            ConsoleWidth = 1750;
            ConsoleHeigth = 750;
            //ConsoleWidth = this.Window.ClientBounds.Width;
            //ConsoleHeigth = this.Window.ClientBounds.Height;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            DSTextures.LoadSprites(Content);
            CuTextures.LoadSprites(Content);
            InitializeGameObject();

            FGTexture.LoadSprites(Content);
            InitializeForegound();

            BGTexture.LoadSprites(Content);
            InitializeBackgound();

            // TODO: use this.Content to load your game content here
        }

        private void InitializeGameObject()
        {
            sailors = new List<DynamicBlok>()
            {
                new Player(DSTextures.textureDic, new KeyBoardReader()),
                new Enemy(CuTextures.textureDic)
            };
        }

        private void InitializeForegound()
        {
            Game1.Foreground = new Foreground(FGTexture.textureDic);
            Game1.Foreground.CreateWorld();
        }

        private void InitializeBackgound()
        {
            background = new Background(BGTexture.textureList);
            background.CreateWorld();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            foreach (var sailor in sailors)
            {
                sailor.Update(gameTime);
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            background.DrawWorld(_spriteBatch);

            Game1.Foreground.DrawWorld(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
