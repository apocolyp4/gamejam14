using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;


namespace AssWhipSoftware
{
    class Level
    {
        Tile[,] levelTiles = new Tile[60, 20];
        Texture2D[] tiles = new Texture2D[100];
        Texture2D[] badBackground = new Texture2D[4];
        Texture2D[] goodBackground = new Texture2D[4];

        public static bool isEvil;
        bool levelComplete;


        public bool IsEvil
        {
            get { return isEvil; }
            set { isEvil = value; }
        }

        public void initLevel()
        {
            Settings.goodDoor = new Tile();
            Settings.badDoor = new Tile();
            Settings.goodDoor.Texture = Settings.Content.Load<Texture2D>("Door-30");
            Settings.badDoor.Texture = Settings.Content.Load<Texture2D>("Door-31");
            for (int i = 1; i < 5; i++)
            {
                badBackground[i - 1] = Settings.Content.Load<Texture2D>("BackgroundBad" + i.ToString());
                goodBackground[i - 1] = Settings.Content.Load<Texture2D>("BackgroundGood" + i.ToString());
            }
            for (int i = 1; i < 37; i++)
            {
                try
                {
                    tiles[i] = Settings.Content.Load<Texture2D>("Tiles/" + i.ToString());
                }
                catch { }
            }

            for (int y = 0; y < 20; y++)
            {
                for (int x = 0; x < 60; x++)
                {
                    levelTiles[x, y] = new Tile();
                }
            }
        }

        public void resetLevel()
        {
            levelComplete = false;
            Settings.xLevelOffSet = 0;
            Settings.yLevelOffSet = 0;

            for (int y = 0; y < 20; y++)
            {
                for (int x = 0; x < 60; x++)
                {
                    levelTiles[x, y].Type = "NULL";
                }
            }
        }

        public void load(string fileName)
        {
            resetLevel();
            Settings.levelEnemies.Clear();
            int y = 0;
            // load level text file
            List<string> tileTextList = new List<string>();
            System.IO.Stream stream = TitleContainer.OpenStream("Content\\" + fileName);
            StreamReader reader = new StreamReader(stream);
            string line = reader.ReadLine();
            Settings.levelWidth = 0;
            Settings.levelHeight = 0;
            while (line != null && y < 20)
            {
                line = reader.ReadLine();
                if (line != null)
                {
                    string[] levelAttributes = line.Split(',');
                    for (int i = 0; i < levelAttributes.Count() - 1; i++)
                    {
                        if (levelAttributes[i] != "0" && levelAttributes[i] != "-1")
                        {
                            int tileNum = Convert.ToInt32(levelAttributes[i]);
                            if (tileNum < 31)
                            {
                                if (i > Settings.levelWidth)
                                {
                                    Settings.levelWidth = i;
                                }

                                if (y > Settings.levelHeight)
                                {
                                    Settings.levelHeight = y;
                                }

                                levelTiles[i, y].Type = "Tile";
                                levelTiles[i, y].EvilTexture = Settings.Content.Load<Texture2D>("Tiles/" + levelAttributes[i] + "e");

                                levelTiles[i, y].Texture = tiles[tileNum];
                                levelTiles[i, y].X = (i * 32);
                                levelTiles[i, y].Y = (y * 32) ;
                            }
                            else if (tileNum == 90)
                            {
                                Settings.goodDoor.X = (i * 32) + 32;
                                Settings.goodDoor.Y = (y * 32) + 32;
                                Settings.badDoor.X = (i * 32) + 32;
                                Settings.badDoor.Y = (y * 32) + 32;
                            }



                            Console.WriteLine(levelAttributes[i]);
                        }
                    }
                }
                y += 1;
            }
            Settings.levelWidth = Settings.levelWidth * 32;
            Settings.levelHeight = Settings.levelHeight * 32;
            reader.Close();
            stream.Close();
        }

       // public Vector2 WhereCanIGetTo(Vector2 originalPosition, Vector2 destination, Rectangle boundingRectangle)
      //  {
            
      //  }

        public bool hasRoomForRectangle(Rectangle rectangleToCheck)
        {
            foreach (var tile in levelTiles)
            {
                if (tile.Type == "Tile" && tile.Texture != null)
                {
                    if (tile.Bounds.Intersects(rectangleToCheck))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void draw() 
        {
            float xPos = 0;
            float yPos = 0;
            if(isEvil)
            {
                for (int i = 3; i > -1; i--)
                {
                    xPos = 0 - (Settings.xLevelOffSet / i + 1);
                    yPos = (Settings.levelHeight - badBackground[i].Height) - (Settings.yLevelOffSet / i + 1);
                    Settings.SpriteBatch.Draw(badBackground[i], new Vector2(xPos, yPos), null, Color.White, 0, new Vector2(0, 0), 1, SpriteEffects.None, 0f);
                }

                xPos = Settings.badDoor.X - Settings.xLevelOffSet;
                yPos = Settings.badDoor.Y - Settings.yLevelOffSet;
                Settings.SpriteBatch.Draw(Settings.badDoor.Texture, new Vector2(xPos, yPos), null, Color.White, 0, new Vector2(0, 0), 1, SpriteEffects.None, 0f);
                
            }
            else
            {
                for (int i = 3; i > -1; i--)
                {
                    xPos = 0 - (Settings.xLevelOffSet / i + 1);
                    yPos = (Settings.levelHeight - badBackground[i].Height) - (Settings.yLevelOffSet / i + 1);
                    Settings.SpriteBatch.Draw(goodBackground[i], new Vector2(xPos, yPos), null, Color.White, 0, new Vector2(0, 0), 1, SpriteEffects.None, 0f);
                }

                xPos = Settings.goodDoor.X - Settings.xLevelOffSet;
                yPos = Settings.goodDoor.Y - Settings.yLevelOffSet;
                Settings.SpriteBatch.Draw(Settings.goodDoor.Texture, new Vector2(xPos, yPos), null, Color.White, 0, new Vector2(0, 0), 1, SpriteEffects.None, 0f);
            }


            for (int y = 0; y < 20; y++)
            {
                for (int x = 0; x < 60; x++)
                {
                    if (levelTiles[x, y].Type != "NULL" && levelTiles[x, y].Texture != null)
                    {
                        xPos = levelTiles[x, y].X - Settings.xLevelOffSet;
                        yPos = levelTiles[x, y].Y - Settings.yLevelOffSet;
                        
                        if (isEvil)
                        {
                            Settings.SpriteBatch.Draw(levelTiles[x, y].EvilTexture, new Vector2(xPos, yPos), null, Color.White, 0, new Vector2(0, 0), 1, SpriteEffects.None, 0f);
                        }
                        else
                        {
                            Settings.SpriteBatch.Draw(levelTiles[x, y].Texture, new Vector2(xPos, yPos), null, Color.White, 0, new Vector2(0, 0), 1, SpriteEffects.None, 0f);
                        }
                    }
                }
            }
        }

    }
}
