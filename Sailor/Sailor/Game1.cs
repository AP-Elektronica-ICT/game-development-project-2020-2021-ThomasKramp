using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        private List<Texture2D> BGTexture;
        Hero hero;
        Level level;
        

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            DSTextures = new LoadDrunkenSailor();
            BGTexture = new List<Texture2D>();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);


            InitializeBackgound();

            DSTextures.LoadSprites(Content);
            InitializeGameObject();

            // TODO: use this.Content to load your game content here
        }

        private void InitializeBackgound()
        {
            level = new Level(BGTexture);
            level.CreateWorld();
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
            hero.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            level.DrawWorld(_spriteBatch);

            hero.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
