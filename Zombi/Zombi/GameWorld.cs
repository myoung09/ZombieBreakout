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
    class GameWorld
    {
        /*
         add a losing condition
         add a winning condition
         add menus
             */
        Level level;
        int levelId, previousLevelId;
        Player player;
        List<Enemy> enemies;
        Joystick joystick;
        private int width;
        private int height;
        EnemyCamera camera;


        public GameWorld()
        {


            previousLevelId = 0;
            levelId = 1;

        }

        public void LoadContent(ContentManager Content)
        {


            level = new Level(width, height);

           
            //add enemies later


            level.LoadContent(Content);
            LoadLevel();

            player = new Player(new Vector2(level.GetSpawnX(),level.GetSpawnY()),level.GetMap);
            player.LoadContent(Content);
            joystick = new Joystick(player);
            joystick.LoadContent(Content);
            camera = new EnemyCamera(new Vector2(974,632),225f);
            camera.LoadContent(Content);
        }


        public void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            joystick.Update(gameTime);
            camera.Update(gameTime);
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            level.Draw(spriteBatch);
            player.Draw(spriteBatch);
            joystick.Draw(spriteBatch);
            camera.Draw(spriteBatch);
        }

        public void NextLevel()
        {
            previousLevelId = levelId;
            levelId++;
        }

        public void LoadLevel()
        {
            level.LevelSelector(levelId);
            level.loadWorld();
        }

        internal void SetWidth(int width)
        {
            this.width = width;
        }

        internal void SetHeight(int height)
        {
            this.height = height;
        }
    }
}