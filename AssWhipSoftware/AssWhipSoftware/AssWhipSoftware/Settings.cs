using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace AssWhipSoftware
{



    public static class Settings
    {
        public static ContentManager Content;
        public static SpriteBatch SpriteBatch;
        public static GraphicsDevice GraphicsDevice;
        public static SpriteFont defaultFont;
        public static float xLevelOffSet;
        public static float yLevelOffSet;
        public static float levelWidth;
        public static float levelHeight;
        public static int levelNumber;
        public static List<Enemies> levelEnemies = new List<Enemies>();
        public static Tile goodDoor;
        public static Tile badDoor;
        public static Game1 gameReference;
	public static GameTime GameTime;
    }
}
