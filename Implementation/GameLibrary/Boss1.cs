using System;
using System.Collections.Generic;
using System.Drawing;

namespace GameLibrary
{
    public class Boss1 : Mortal
    {
        private const float MAX_XP_DROP = 100;
        private const float MIN_XP_DROP = 75;
  

        public Bitmap Img { get; private set; }
        public float XpDropped { get; private set; }

        private static readonly string name = "Earth Elemental";
      
    

        public Boss1(int level, Bitmap img) : base(name, level)
        {
            Img = img;

            // Its a boss so it has to be strong
            Health = 200;
            Str = 30;
            Def = 50;

            XpDropped = (float)rand.NextDouble() * (MAX_XP_DROP - MIN_XP_DROP) + MIN_XP_DROP;
        }

    }
}
