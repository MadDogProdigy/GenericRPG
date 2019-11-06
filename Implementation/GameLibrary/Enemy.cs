using System;
using System.Collections.Generic;
using System.Drawing;

namespace GameLibrary {
  public class Enemy : Mortal {
    private const float MAX_XP_DROP = 35;
    private const float MIN_XP_DROP = 15;
    private const float WEAKEN_MIN = 1.25f;
    private const float WEAKEN_MAX = 1.85f;
    private const int MIN_COIN_DROP = 0;
    private const int MAX_COIN_DROP = 10;

    public Bitmap Img { get; private set; }
    public float XpDropped { get; private set; }

    public int CoinDropped { get; private set; }

    private static readonly Random rand = new Random();
    private static readonly List<string> names = new List<string>() {
      "Wily", "Bob", "Dr. Light", "WallCrusher"
    };

    public Enemy(int level, Bitmap img) : base(RandName(), level) {
      Img = img;

      // weaken so player has a chance
      Health /= (float)rand.NextDouble() * (WEAKEN_MAX - WEAKEN_MIN) + WEAKEN_MIN;
      Mana /= (float)rand.NextDouble() * (WEAKEN_MAX - WEAKEN_MIN) + WEAKEN_MIN;
      Str /= (float)rand.NextDouble() * (WEAKEN_MAX - WEAKEN_MIN) + WEAKEN_MIN;
      Def /= (float)rand.NextDouble() * (WEAKEN_MAX - WEAKEN_MIN) + WEAKEN_MIN;

      XpDropped = (float)rand.NextDouble() * (MAX_XP_DROP - MIN_XP_DROP) + MIN_XP_DROP;
      CoinDropped = rand.Next()*(MAX_COIN_DROP - MIN_COIN_DROP) + MIN_COIN_DROP;
    }

    public static string RandName() {
      return names[rand.Next(names.Count)];
    }
  }
}
