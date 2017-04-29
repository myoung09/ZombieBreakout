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
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace Zombi
{
    class Player : IGameObject
    {
        private Rectangle collisiontBounds, textureLocation;
        public Vector2 location;
        private int TILEHEIGHT;
        private int TILEWIDTH;

       
        private float _speed;
        private Texture2D texture;
        private string textureName;
        private Tile[,] map;

        public Player(Vector2 startLocation, Tile[,] map)
        {
            location = startLocation;
            textureName = "mageZombi";
            TILEWIDTH = 36;
            TILEHEIGHT = 57;
            _speed = 2;
            textureLocation = new Rectangle(0, 0, TILEWIDTH, TILEHEIGHT);
           
           
            collisiontBounds = new Rectangle((int)location.Y+10, (int)location.Y +30, TILEWIDTH-20, TILEHEIGHT-30);
           
            this.map = map;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, location, textureLocation, Color.White);
        }

        public void LoadContent(ContentManager Content)
        {
            texture = Content.Load<Texture2D>(textureName);
        }


        /// <summary>
        /// Get input and changes the location of the player to make the texture move
        /// used in the joysticks update() method
        /// </summary>
        /// works well
        public void Move(Direction direct)
        {

            switch (direct)
            {
                case Direction.UpLeft:
                    location = CheckCollisions(location.X - _speed / 2, location.Y - _speed / 2);
                    break;
                case Direction.Up:
                    location = CheckCollisions(location.X, location.Y - _speed);
                    break;
                case Direction.UpRight:
                
                    location = CheckCollisions(location.X + _speed / 2, location.Y - _speed / 2);

                    break;
                case Direction.Left:
                    
                    location = CheckCollisions(location.X - _speed ,location.Y);
                    break;
                case Direction.DownLeft:
                  

                    location = CheckCollisions(location.X - _speed / 2, location.Y + _speed / 2);

                    break;
                case Direction.Down:
               
                    location = CheckCollisions(location.X, location.Y + _speed);
                    break;
                case Direction.DownRight:
                  
                    location = CheckCollisions(location.X + _speed / 2, location.Y + _speed / 2);
                    break;
                case Direction.Right:
                 
                    location = CheckCollisions(location.X + _speed, location.Y);
                    break;
                default:
                    location = CheckCollisions(location.X, location.Y - _speed);
                    break;

            }

        }



        public void Update(GameTime gameTime)
        {

           

        }

        /// <summary>
        /// checks if there is a collision with any tile in a defined area ---
        /// the area is define in the GetTilesToCheck() method ***SIZE*** 
        /// </summary>
        /// <param name="locX"></param>
        /// <param name="locY"></param>
        /// <returns>the location to move to note: this doesnt move the player it just tells the player where to move
        /// </returns>
        public Vector2 CheckCollisions(float locX, float locY)
        {
            Tile[,] tiles = GetTilesToCheck();
            Vector2 testPoint = new Vector2(locX, locY);
           
            Rectangle testBound = new Rectangle((int)testPoint.X+10,(int)testPoint.Y+30,collisiontBounds.Width,collisiontBounds.Height);
            for (int y = 0; y < tiles.GetLength(0); y++)
            {
                for (int x = 0; x < tiles.GetLength(1); x++)
                {

                    if (testBound.Intersects(tiles[x, y].bounds) && tiles[x, y].isSolid())
                    {

                        return location;

                    }
                    

                }

            }
            collisiontBounds = testBound;
            return testPoint;



        }

       /// <summary>
       /// Gets a multi dim array of Tiles to match the format of the levelMap
       /// --- the SIZE local variable determines how wide the range to check is
       /// </summary>
       /// <returns></returns>
        private Tile[,] GetTilesToCheck()
        {
            Point tilePoint = GetPlayersSittingTile().bounds.Location / new Point(Tile.TILEWIDTH, Tile.TILEHEIGHT);

            //must be odd
            int SIZE = 5;

            int inc = (SIZE - 1) / 2;
            Tile[,] tiles = new Tile[SIZE, SIZE];
           
            for(int y = 0; y< SIZE; y++)
            {
                for (int x = 0; x < SIZE; x++)
                {
                    tiles[x, y] = map[tilePoint.X -inc + x , tilePoint.Y + 1- inc + y];
                }
            }
            return tiles;
        }

        /// <summary>
        /// Determines which tile the player is standing on
        /// </summary>
        /// <returns></returns>
        private Tile GetPlayersSittingTile()
        {
            int x = (int)Math.Floor(location.X / 32);
            int y = (int)Math.Floor(location.Y / 32);

            return map[x, y];
        }

    }
}