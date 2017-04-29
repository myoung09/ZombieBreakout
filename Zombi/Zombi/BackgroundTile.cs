using Microsoft.Xna.Framework;

namespace Zombi
{
    internal class BackgroundTile : Tile
    {
        public BackgroundTile(int id) : base(id)
        {
            base.textureLocation = new Rectangle(0, 0, TILEWIDTH, TILEHEIGHT);
        }
        public override bool isSolid()
        {
            return true;
        }
    }
}