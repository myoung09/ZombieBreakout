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
    class EnemyCamera : IGameObject
    {
        /*
         add a method that checks collision with play
         add a method to lock on to the players position
        add a  bool hasSeen use collision to set and create a getter

             */

        Texture2D texture;
        string textureName;
        Vector2 location;

        // .9948055556 rotation per degree
        float rotationMax, rotationMin, rotation, rotationSpeed;
        Vector2 rotationCenter,scale;
        Rectangle textureLocation;
        private int lastTime;
        private int timer;
        private int speed;
        float degrees;

        public EnemyCamera(Vector2 location, float rotation)
        {

            Init();
            this.location = location;
            this.rotation = rotation * degrees;
            rotationMax = this.rotation + 1f;
            rotationMin = this.rotation - 1f;
            rotationSpeed = .005f;
        }
        public EnemyCamera(Vector2 location, float rotation, float rotationMin, float rotationMax)
        {
            Init();
            this.location = location;
            this.rotation = rotation * degrees;
            this.rotationMax = rotationMax;
            this.rotationMin = rotationMin;
            this.rotationSpeed = .005f;
        }
        public EnemyCamera(Vector2 location, float rotation, float rotationMin, float rotationMax,float rotationSpeed)
        {
            Init();
            this.location = location;
            this.rotation = rotation * degrees;
            this.rotationMax = rotationMax;
            this.rotationMin = rotationMin;
            this.rotationSpeed = rotationSpeed;
        }
        private void Init()
        {
            degrees = .9948055556f;
            textureName = "visionZombieTrans";           
            speed = 10;          
            textureLocation = new Rectangle(0, 0, 40, 120);
            rotationCenter = new Vector2(20, 0);
            scale = new Vector2(1, 1);
            
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture,location,textureLocation,Color.White, rotation, rotationCenter,scale,SpriteEffects.None,1f);
        }

        public void LoadContent(ContentManager Content)
        {
            texture = Content.Load<Texture2D>(textureName);
        }

        public void Update(GameTime gameTime)
        {
            RotationTick();   
        }

        private void RotationTick()
        {
            timer += System.Environment.TickCount - lastTime;
            lastTime = System.Environment.TickCount;

          
            if (timer > speed)
            {
                if (rotation > rotationMin && rotation < rotationMax)
                {
                    rotation += rotationSpeed;
                }
                else
                {
                    rotation -= rotationSpeed;
                    rotationSpeed *= -1;
                }
                timer = 0;
            
             
            }
        }

        public void CheckCollision(Rectangle collisionBound)
        {
            //Do line by line checking of the triangle and and rectangle
        }
    }
}