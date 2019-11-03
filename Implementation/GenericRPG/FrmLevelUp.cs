using GameLibrary;
using System;
using System.Media;
using System.Windows.Forms;

namespace GenericRPG {
  public partial class FrmLevelUp : Form {
    private SoundPlayer sp;

    public FrmLevelUp() {
      InitializeComponent();

      // disables the [X] button
      this.ControlBox = false;
    }

    private void FrmLevelUp_Load(object sender, EventArgs e) {
      sp = new SoundPlayer(@"Resources\levelup.wav");
      sp.Play();

      Character character = Game.GetGame().Character;
      character.RefillHealthAndMana();

      lblOldLevel.Text  = character.Level.ToString();
      lblOldHealth.Text = ((float)Math.Round(character.Health)).ToString();
      lblOldMana.Text   = ((float)Math.Round(character.Mana)).ToString();
      lblOldStr.Text    = ((float)Math.Round(character.Str)).ToString();
      lblOldDef.Text    = ((float)Math.Round(character.Def)).ToString();

      character.LevelUp();
      lblNewLevel.Text  = character.Level.ToString();
      lblNewHealth.Text = character.Health.ToString();
      lblNewMana.Text   = character.Mana.ToString();
      lblNewStr.Text    = character.Str.ToString();
      lblNewDef.Text    = character.Def.ToString();
    }

    private void btnClose_Click(object sender, EventArgs e) {
      // stop sound
      sp.Stop();
      Close();
    }
  }
}
