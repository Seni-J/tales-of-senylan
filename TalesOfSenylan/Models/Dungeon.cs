using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Collisions;
using System;
using System.Diagnostics;
using TalesOfSenylan.Models.Characters;

namespace TalesOfSenylan
{
    public class Dungeon
    {
        public Player Player { get; set; }
        public Enemy Enemy { get; set; }
        private Vector2 StartPosition;

        private int DungeonNumber;

        public ContentManager Content { get; }

        public Dungeon(IServiceProvider serviceProvider, int dungeonNumber)
        {
            Content = new ContentManager(serviceProvider, "Content");
            DungeonNumber = dungeonNumber;
            StartPosition = new Vector2(250, 250);
            InitializeLevel();
        }
        
        private void InitializeLevel()
        {
            Player = new Player(this, StartPosition);
            Enemy = new Enemy(this, new Vector2(400, 400));
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Player.Draw(gameTime, spriteBatch);
            Enemy.Draw(gameTime, spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            Player.Update(gameTime);
            if (Player.IsCollided(Enemy.getHitbox()))
            {
                
            }
        }
    }
}
