using GameLibrary;
using GenericRPG.Properties;
using System;
using System.Drawing;
using System.Media;
using System.Threading;
using System.Windows.Forms;

namespace GenericRPG {
  public partial class FrmArena : Form {
    private Game game;
    private Character character;
    private Enemy enemy;
    private Random rand;
    private SoundPlayer sp;

    public FrmArena() {
      InitializeComponent();

      // disables the [X] button
      this.ControlBox = false;
    }
    private void btnEndFight_Click(object sender, EventArgs e) {
      EndFight();
    }
    private void EndFight() {
      Game.GetGame().ChangeState(GameState.ON_MAP);
      Close();
    }
    private void FrmArena_Load(object sender, EventArgs e) {
      rand = new Random();

      game = Game.GetGame();
      character = game.Character;
      enemy = new Enemy(rand.Next(character.Level + 1), Resources.enemy);

      // stats
      UpdateStats();

      // pictures
      picCharacter.BackgroundImage = character.Pic.BackgroundImage;
      picEnemy.BackgroundImage = enemy.Img;

      // names
      lblPlayerName.Text = character.Name;
      lblEnemyName.Text = enemy.Name;

      // create swing noise
      sp = new SoundPlayer(@"Resources\swing.wav");
    }
    public void UpdateStats() {
      lblPlayerLevel.Text = character.Level.ToString();
      lblPlayerHealth.Text = Math.Round(character.Health).ToString();
      lblPlayerStr.Text = Math.Round(character.Str).ToString();
      lblPlayerDef.Text = Math.Round(character.Def).ToString();
      lblPlayerMana.Text = Math.Round(character.Mana).ToString();
      lblPlayerXp.Text = Math.Round(character.XP).ToString();

      lblEnemyLevel.Text = enemy.Level.ToString();
      lblEnemyHealth.Text = Math.Round(enemy.Health).ToString();
      lblEnemyStr.Text = Math.Round(enemy.Str).ToString();
      lblEnemyDef.Text = Math.Round(enemy.Def).ToString();
      lblEnemyMana.Text = Math.Round(enemy.Mana).ToString();

      lblPlayerHealth.Text = Math.Round(character.Health).ToString();
      lblEnemyHealth.Text = Math.Round(enemy.Health).ToString();
    }
    private void btnSimpleAttack_Click(object sender, EventArgs e) {
      // make swing noise
      sp.Play();

      float prevEnemyHealth = enemy.Health;
      character.SimpleAttack(enemy);
      float enemyDamage = (float)Math.Round(prevEnemyHealth - enemy.Health);
      lblEnemyDamage.Text = enemyDamage.ToString();
      lblEnemyDamage.Visible = true;
      tmrEnemyDamage.Enabled = true;
      if (enemy.Health <= 0) {
        character.GainXP(enemy.XpDropped);
        lblEndFightMessage.Text = "You Gained " + Math.Round(enemy.XpDropped) + " xp!";
        lblEndFightMessage.Visible = true;
        Refresh();
        Thread.Sleep(1200);
        EndFight();
        if (character.ShouldLevelUp) {
          FrmLevelUp frmLevelUp = new FrmLevelUp();
          frmLevelUp.Show();
        }
        if(enemy.CoinDropped > 0)
        {
                    FrmReward frmReward = new FrmReward();
                    frmReward.Amt = enemy.CoinDropped;
                    character.GetMoney(enemy.CoinDropped);
                    frmReward.Show();
        }
      }
      else {
        float prevPlayerHealth = character.Health;
        enemy.SimpleAttack(character);
        float playerDamage = (float)Math.Round(prevPlayerHealth - character.Health);
        lblPlayerDamage.Text = playerDamage.ToString();
        lblPlayerDamage.Visible = true;
        tmrPlayerDamage.Enabled = true;
        if (character.Health <= 0) {
          UpdateStats();
          game.ChangeState(GameState.DEAD);
          lblEndFightMessage.Text = "You Were Defeated!";
          lblEndFightMessage.Visible = true;
          Refresh();
          Thread.Sleep(1200);
          EndFight();
          FrmGameOver frmGameOver = new FrmGameOver();
          frmGameOver.Show();
        }
        else {
          UpdateStats();
        }
      }
    }
    private void btnRun_Click(object sender, EventArgs e) {
      if (rand.NextDouble() < 0.25) {
        lblEndFightMessage.Text = "You Ran Like a Coward!";
        lblEndFightMessage.Visible = true;
        Refresh();
        Thread.Sleep(1200);
        EndFight();
      }
      else {
        // perform enemy turn
        float prevPlayerHealth = character.Health;
        enemy.SimpleAttack(character);
        float playerDamage = (float)Math.Round(prevPlayerHealth - character.Health);
        lblPlayerDamage.Text = playerDamage.ToString();
        lblPlayerDamage.Visible = true;
        tmrPlayerDamage.Enabled = true;
        if (character.Health <= 0)
        {
          UpdateStats();
          game.ChangeState(GameState.DEAD);
          lblEndFightMessage.Text = "You Were Defeated!";
          lblEndFightMessage.Visible = true;
          Refresh();
          Thread.Sleep(1200);
          EndFight();
          FrmGameOver frmGameOver = new FrmGameOver();
          frmGameOver.Show();
        }
        else
        {
          UpdateStats();
        }
      }
    }

    private void tmrPlayerDamage_Tick(object sender, EventArgs e) {
      lblPlayerDamage.Top -= 2;
      if (lblPlayerDamage.Top < 10) {
        lblPlayerDamage.Visible = false;
        tmrPlayerDamage.Enabled = false;
        lblPlayerDamage.Top = 52;
      }
    }

    private void tmrEnemyDamage_Tick(object sender, EventArgs e) {
      lblEnemyDamage.Top -= 2;
      if (lblEnemyDamage.Top < 10) {
        lblEnemyDamage.Visible = false;
        tmrEnemyDamage.Enabled = false;
        lblEnemyDamage.Top = 52;
      }
    }

    private void FrmArena_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode) {
                case Keys.A:
                    btnSimpleAttack_Click(sender, e);
                    break;
                case Keys.S:
                    FrmArena_Shortcuts_Click(sender,e);
                    break;
                case Keys.R:
                    btnRun_Click(sender, e);
                    break;
                case Keys.W:
                    btnUseWeapon_Click(sender, e);
                    break;
                ///case Keys.T:
                ///character.weapon.ViewStats();
                ///break;
            }

        }

        private void FrmArena_Shortcuts_Click(object sender, EventArgs e)
        {
            String message = "The following shortcuts are available\n" +
                             "and can be viewed by pressing S:" +
                             "\tA\tAttack\n" +
                             "\tR\tRun\n" +
                             "\tW\tUseWeapon\n"; //\tT\tView Weapon Stats\n";
            MessageBox.Show(message,"Shortcuts");
        }

        private void btnUseWeapon_Click(object sender, EventArgs e)
        {

        }
    }
}
