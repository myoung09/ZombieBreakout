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
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Zombi
{
    interface IGameObject
    {
        void LoadContent(ContentManager Content);
        void  Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
        
    }
}