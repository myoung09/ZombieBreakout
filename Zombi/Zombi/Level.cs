using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Text.RegularExpressions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using Android.Content.Res;
using Android.Graphics;

namespace Zombi
{
    class Level : IGameObject
    {
        private int[,] gameMap;
        private int height, worldHeight;
        private Tile[,] mapTiles;
        private int spawnX;
        private int spawnY;
        private int width,worldWidth;
        string path;
        int id;
        Texture2D texture;
        string textureName;

    

        public Level(int width, int height)
        {

            textureName = "ZombiSheet";
            this.worldWidth = width;
            this.worldHeight = height;
        }

        public void LevelSelector(int levelId)
        {
            string levelPath = "level1.txt";

            switch (levelId)
            {
                case 1:
                    levelPath = "level1.txt";
                    break;

            }

            path = levelPath;
        }

        public void loadWorld()
        {

            string file = LoadFileAsString(path);
            string[] tokens = Regex.Split(file, "\\s+");
            width = ParseInt(tokens[0]);
            height = ParseInt(tokens[1]);
            spawnX = ParseInt(tokens[2]);
            spawnY = ParseInt(tokens[3]);
            gameMap = new int[width, height];
            mapTiles = new Tile[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    gameMap[x, y] = ParseInt(tokens[(x + y * width) + 4]);
                    mapTiles[x, y] = Tile.GetTile(gameMap[x, y]);
                    mapTiles[x, y].bounds = new Rectangle(Tile.TILEWIDTH * x, Tile.TILEHEIGHT * y, Tile.TILEWIDTH, Tile.TILEHEIGHT);
                }
            }
        }


        public void LoadContent(ContentManager Content)
        {
            texture = Content.Load<Texture2D>(textureName);
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            int xEnd = (int)Math.Ceiling(worldWidth / Tile.TILEWIDTH * 1.0);
            int yEnd = (int)Math.Ceiling(worldHeight / Tile.TILEHEIGHT * 1.0 + 1);
            //int xEnd = 60;
            //int yEnd = 34;

           
            for (int y = 0; y < yEnd; y++)
            {
                for (int x = 0; x < xEnd; x++)
                {

                    mapTiles[x, y].Draw(spriteBatch,texture, new Vector2(x * Tile.TILEWIDTH, y * Tile.TILEHEIGHT));

                }
            }
        }

        private string LoadFileAsString(string path)
        {
            StringBuilder builder = new StringBuilder();



            try
            {

                string line;
               
                using (var input = Application.Context.Assets.Open(path))
                using (var streamReader = new StreamReader(input))
                {
                    // Read the stream to a string, and write the string to the console.

                    while ((line = streamReader.ReadLine()) != null)
                        builder.Append(line + " ");
                }



            }
            catch (IOException e)
            {

            }

            return builder.ToString();
        }

        private int ParseInt(string number)
        {
            try
            {
                return int.Parse(number);
            }
            catch (FormatException e)
            {
                return 255;
            }
            catch (ArgumentNullException e)
            {
                return 255;
            }
            catch (OverflowException e)
            {

                return 255;
            }
        }
        public int GetSpawnX()
        {
            return spawnX;
        }
        public int GetSpawnY()
        {
            return spawnY;
        }

        public Tile[,] GetMap
        {
            get
            {
                return mapTiles;
            }
        }
    }
}