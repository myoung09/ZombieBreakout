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

namespace Zombi
{
    class FloorTile : Tile
    {
        public FloorTile(int id) : base(id)
        {
            base.textureLocation = new Rectangle(0, TILEHEIGHT, TILEWIDTH, TILEHEIGHT);
        }
    }
}