using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sailor.CollisionDetection;
using Sailor.Commands;
using Sailor.Input;
using Sailor.LevelDesign;
using Sailor.LoadSprites;
using System;
using System.Collections.Generic;

namespace Sailor
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private LoadDrunkenSailor DSTextures;
        private LoadBackground BGTexture;
        private LoadForeground FGTexture;
        Hero hero;
        Foreground foreground;
        Background background;
        

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            BGTexture = new LoadBackground();
            FGTexture = new LoadForeground();
            DSTextures = new LoadDrunkenSailor();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            FGTexture.LoadSprites(Content);
            InitializeForegound();

            BGTexture.LoadSprites(Content);
            InitializeBackgound();

            DSTextures.LoadSprites(Content);
            InitializeGameObject();

            // TODO: use this.Content to load your game content here
        }

        private void InitializeForegound()
        {
            foreground = new Foreground(FGTexture.textureList);
            foreground.CreateWorld();
        }

        private void InitializeBackgound()
        {
            background = new Background(BGTexture.textureList);
            background.CreateWorld();
        }

        private void InitializeGameObject()
        {
            hero = new Hero(DSTextures.textureDic, new KeyBoardReader(), new MoveCommand());
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            hero.Update(gameTime, foreground);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            background.DrawWorld(_spriteBatch);

            foreground.DrawWorld(_spriteBatch);

            hero.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
