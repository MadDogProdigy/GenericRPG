using System;
using System.Drawing;


namespace GameLibrary
{
    public class Boss : Mortal
    {
        private const float MAX_XP_DROP = 120;
        private const float MIN_XP_DROP = 80;

        public Bitmap Img { get; private set; }
        public float XpDropped { get; private set; }

        private static readonly Random rand = new Random();
        private static string name;

        public Boss(int level, Bitmap img) : base(name, level)
        {
            if (level == 8)
            {
                Img = img;
                name = "Wind Elemental";
                Health = 200;
                Str = 25;
                Def = 25;
            }
            else if (level == 15)
            {
                Img = img;
                name = "Water Elemental";
                Health = 300;
                Str = 30;
                Def = 25;
            }
            else if (level == 22)
            {
                Img = img;
                name = "Fire Elemental";
                Health = 400;
                Str = 40;
                Def = 25;
            }
            else if (level == 29)
            {
                Img = img;
                name = "Earth Elemental";
                Health = 500;
                Str = 30;
                Def = 50;
            }
            else if (level == 36)
            {
                Img = img;
                name = "Cherrybot";
                Health = 65000;
                Str = 50;
                Def = 50;
            }

            XpDropped = (float)rand.NextDouble() * (MAX_XP_DROP - MIN_XP_DROP) + MIN_XP_DROP;
        }

    }
}