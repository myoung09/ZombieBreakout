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

namespace Zombi
{
    class Tile
    {


        public const int TILEWIDTH = 32, TILEHEIGHT = 32;
        public Rectangle bounds;
        protected Rectangle textureLocation;
        protected string _textureName;
        public Texture2D _texture;
        protected int _id;
        private int LocX, LocY;
        public Tile(int id)
        {
            _id = id;
         

        }

        public void Draw(SpriteBatch spriteBatch, Texture2D texture, Vector2 location)
        {
            spriteBatch.Draw(texture, location, textureLocation, Color.White);
        }

        public virtual bool isSolid()
        {
            return false;
        }

        public int getId()
        {
            return _id;
        }




        public static Tile GetTile(int id)
        {
            switch (id)
            {
                case 0:
                    return new BackgroundTile(id);
                case 1:
                    return new FloorTile(id);
                default:
                    return new BackgroundTile(1);

            }

        }
        
    }
}