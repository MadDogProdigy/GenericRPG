using System;

namespace GameLibrary {
  public class Mortal {
    #region Constants
    private const float INIT_HEALTH = 100;
    private const float INIT_STR = 10;
    private const float INIT_DEF = 5;
    private const float INIT_LUCK = 2;
    private const float INIT_SPEED = 2;
    private const float INIT_MANA = 40;

    private const float LVLINC_HEALTH = 20;
    private const float LVLINC_STR = 3;
    private const float LVLINC_DEF = 2;
    private const float LVLINC_LUCK = 1;
    private const float LVLINC_SPEED = 2;
    private const float LVLINC_MANA = 10;

    private const float SIMPLEATTACK_RANDOM_AMT = 0.25f;
    #endregion

    public string Name { get; protected set; }
    public int Level { get; protected set; }
    public float MaxHealth { get; protected set; }
    public float Health { get; set; }
    public float MaxMana { get; protected set; }
    public float Mana { get; set; }
    public float Str { get; protected set; }
    public float Def { get; protected set; }
    public float Luck { get; protected set; }
    public float Speed { get; protected set; }

    private Random rand;

    public Mortal(string name, int level) {
      Name = name;
      ResetStats();
      SetLevel(level);
      rand = new Random();
    }
    public virtual void ResetStats() {
      Level = 1;
      MaxHealth = INIT_HEALTH;
      Health = MaxHealth;
      MaxMana = INIT_MANA;
      Mana = MaxMana;
      Str = INIT_STR;
      Def = INIT_DEF;
      Luck = INIT_LUCK;
      Speed = INIT_SPEED;
    }
    public void SetLevel(int level) {
      for (int i = 1; i < level; i++) {
        LevelUp();
      }
    }
    public virtual void LevelUp() {
      // level increases
      Level++;

      // health and mana
      MaxHealth += LVLINC_HEALTH;
      MaxMana += LVLINC_MANA;
      Health = MaxHealth;
      Mana = MaxMana;

      // other stats
      Str += LVLINC_STR;
      Def += LVLINC_DEF;
      Luck += LVLINC_LUCK;
      Speed += LVLINC_SPEED;
    }
    public void RefillHealthAndMana() {
      Health = MaxHealth;
      Mana = MaxMana;
    }
    public void SimpleAttack(Mortal receiver) {
      float baseDamage = Math.Abs(Str * 1.2f - receiver.Def);
      float randMax = 1 + SIMPLEATTACK_RANDOM_AMT;
      float randMin = 1 - SIMPLEATTACK_RANDOM_AMT;
      float randMult = (float)(rand.NextDouble() * (randMax - randMin)) + randMin;
      receiver.Health -= (baseDamage * randMult);
    }
  }
}
