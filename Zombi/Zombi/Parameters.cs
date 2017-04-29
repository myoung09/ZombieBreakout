using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Util;


namespace Zombi

  {
    enum Direction
    {
        Up,Down,Left,Right,UpLeft,UpRight,DownRight,DownLeft
    }
    public static class Parameters
    {
       
        

        public static float ZOOM = 1;

        public static float MAIN_CHAR_START_LOCATION_X = 1600;
        public static float MAIN_CHAR_START_LOCATION_Y = 1000;

        public static float GAME_SPEED = 1f;

        public static int ANIMATION_SPEED = 300;
        public static int STATIC_ANIMATION_SPEED = 3000;
        public static int AI_ANIMATION_SPEED = 1000;

        public static int Metrics(string type)
        {
            DisplayMetrics metrics = new DisplayMetrics();
            switch(type)
            {
                case "width":
                    return metrics.WidthPixels;
                case "height":
                    return metrics.HeightPixels;
                default:
                    return 0;
            }
 
        }
    }
}