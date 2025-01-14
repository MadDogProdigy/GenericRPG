﻿using System;
using System.Drawing;


namespace GameLibrary
{
    public class Boss : Mortal
    {
        private const float MAX_XP_DROP = 120;
        private const float MIN_XP_DROP = 80;
        private const int MIN_COIN_DROP = 25;
        private const int MAX_COIN_DROP = 50;

        public Bitmap Img { get; private set; }
        public float XpDropped { get; private set; }
        public int CoinDropped { get; private set; }

        private static readonly Random rand = new Random();
        private static string name;

        public Boss(int level, Bitmap img) : base(name, level)
        {
            if (level == 8)
            {
                Img = img;
                name = "Wind Elemental";
                Health = 500;
                Str = 50;
                Def = 50;
            }
            else if (level == 15)
            {
                Img = img;
                name = "Water Elemental";
                Health = 800;
                Str = 80;
                Def = 50;
            }
            else if (level == 22)
            {
                Img = img;
                name = "Fire Elemental";
                Health = 1000;
                Str = 90;
                Def = 50;
            }
            else if (level == 29)
            {
                Img = img;
                name = "Earth Elemental";
                Health = 1200;
                Str = 80;
                Def = 100;
            }
            else if (level == 36)
            {
                Img = img;
                name = "Cherrybot";
                Health = 65000;
                Str = 100;
                Def = 100;
            }

            XpDropped = (float)rand.NextDouble() * (MAX_XP_DROP - MIN_XP_DROP) + MIN_XP_DROP;
            CoinDropped = (int) Math.Round(rand.NextDouble() * (MAX_COIN_DROP - MIN_COIN_DROP) + MIN_COIN_DROP);
        }

    }
}