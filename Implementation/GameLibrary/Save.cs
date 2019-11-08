using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GameLibrary
{
  public class Save
  {
    public static void SaveGame()
    {
      var character = Game.GetGame().Character;

      string save = "";
      save += character.map.LevelName + "\n";
      save += character.Level + "\n";
      save += character.XP + "\n";
      save += character.Health + "\n";
      save += character.MaxMana + "\n";
      save += character.Wallet + "\n";
      save += character.HasWeapon + "\n";
            //save charcter position as well

            File.WriteAllText("save.txt", save);
    }
  }

  public class Load
  {
    public static string[] LoadGame()
    {
      var game = Game.GetGame();
      var save = File.ReadAllText("save.txt");

      var lines = save.Split('\n');
      return lines;
    }
  }
}
