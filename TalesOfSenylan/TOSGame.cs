﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TalesOfSenylan.Models.Dungeon;
using TalesOfSenylan.Models.Utilities;

namespace TalesOfSenylan
{
    public class TOSGame : Game
    {
        private Dungeon Dungeon;

        private int DungeonNumber;
        private readonly GraphicsDeviceManager Graphics;
        private SpriteBatch SpriteBatch;

        public TOSGame()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Graphics.PreferredBackBufferWidth =
                Constants.GameWidth; // set this value to the desired width of your window
            Graphics.PreferredBackBufferHeight =
                Constants.GameHeight; // set this value to the desired height of your window
            Graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            LoadNextLevel();
        }

        private void LoadNextLevel()
        {
            DungeonNumber++;
            Dungeon = new Dungeon(Services, DungeonNumber, 3, 3); // TODO: for now it's 3-3 arbitrarily
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            Dungeon.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Transparent);

            // TODO: Add your drawing code here
            SpriteBatch.Begin(SpriteSortMode.BackToFront);
            Dungeon.Draw(gameTime, SpriteBatch);
            SpriteBatch.End();

            base.Draw(gameTime);
        }

        public GameServiceContainer GetServiceProvider()
        {
            return Services;
        }
    }
}