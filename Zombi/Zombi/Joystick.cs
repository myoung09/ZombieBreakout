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
using Microsoft.Xna.Framework.Input.Touch;

namespace Zombi
{
    class Joystick : IGameObject
    {
        Player player;

        public Vector2 location { get; set; }
       private Vector2 scale;

        private Texture2D texture;
        private string textureName;
        private Rectangle textureLocation, subArea;

        public Joystick(Player player)
        {
            this.player = player;
            textureName = "joystick";
            textureLocation = new Rectangle(0,0,450,450);        
            location = new Vector2(0, 630);
            scale = new Vector2(1, 1);
            subArea = new Rectangle(location.ToPoint(), new Point(450, 450));
            
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, location, textureLocation, Color.White);
        }

        public void LoadContent(ContentManager Content)
        {
            texture = Content.Load<Texture2D>(textureName);
        }

        public void Update(GameTime gameTime)
        {
            MovePlayer();
        }

        private void MovePlayer()
        {
            TouchCollection touches = TouchPanel.GetState();



            if (touches.Count > 0)
            {
                if (subArea.Intersects(new Rectangle(touches[0].Position.ToPoint(), scale.ToPoint())))
                {

                    if (touches[0].State == TouchLocationState.Moved)
                    {
                    

                        Vector2 pos = (touches[0].Position) ;
                         
                       
                         
                                player.Move(GetWedge(pos));
                              

                     
                        
                    }
                }
            }
        }

        private Direction GetWedge(Vector2 point)
        {
            Vector2 centerPoint = new Vector2(subArea.Width/2,subArea.Height/2);
           point = point - location - centerPoint;

            float theta = 22.5f;
           
            double x = point.X ;
            double y = -point.Y ;


            double tan = Math.Atan2(y,x);
            float claculatedAngle =(float)(tan*180/3.1415);

            if (claculatedAngle < 0)
            {
                claculatedAngle += 360;
            }
            //else if(claculatedAngle > 360)
            //{
            //    claculatedAngle -= 360;
            //}



            if (theta * 3 > claculatedAngle && claculatedAngle > theta)
            {
                return Direction.UpRight;
            }
            if (theta * 5 > claculatedAngle && claculatedAngle > theta * 3)
            {
                return Direction.Up;
            }
            if (theta * 7 > claculatedAngle && claculatedAngle > theta * 5)
            {
                return Direction.UpLeft;
            }
            if (theta * 9 > claculatedAngle && claculatedAngle > theta * 7)
            {
                return Direction.Left;
            }
            if (theta * 11 > claculatedAngle && claculatedAngle > theta * 9)
            {
                return Direction.DownLeft;
            }
            if (theta * 13 > claculatedAngle && claculatedAngle > theta * 11)
            {
                return Direction.Down;
            }
            if (theta * 15 > claculatedAngle && claculatedAngle > theta * 13)
            {
                return Direction.DownRight;
            }
            if (theta > claculatedAngle && 0 < claculatedAngle || 360 > claculatedAngle && claculatedAngle > theta * 15)
            {
                return Direction.Right;
            }

            return Direction.Down;
        }
    }
}