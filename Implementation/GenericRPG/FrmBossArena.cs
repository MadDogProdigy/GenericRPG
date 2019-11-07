using GameLibrary;
using GenericRPG.Properties;
using System;
using System.Drawing;
using System.Media;
using System.Threading;
using System.Windows.Forms;

namespace GenericRPG
{
    public partial class FrmBossArena : Form
    {
        private Game game;
        private Character character;
        private Boss boss;
        private Random rand;
        private SoundPlayer sp;

        public FrmBossArena()
        {
            InitializeComponent();

            // disables the [X] button
            this.ControlBox = false;
        }
        private void btnEndFight_Click(object sender, EventArgs e)
        {
            EndFight();
        }
        private void EndFight()
        {
            Game.GetGame().ChangeState(GameState.ON_MAP);
            Close();
        }
        private void FrmArena_Load(object sender, EventArgs e)
        {
            rand = new Random();

            game = Game.GetGame();
            character = game.Character;
            switch (game.Level)
            {
                case 1:
                    boss = new Boss((8), Resources.WindElemental);
                    break;
                case 2:
                    boss = new Boss((15), Resources.WaterElemental);
                    break;
                case 3:
                    boss = new Boss((22), Resources.FireElemental);
                    break;
                case 4:
                    boss = new Boss((29), Resources.EarthElemental);
                    break;
                case 5:
                    boss = new Boss((36), Resources.FinalBoss);
                    break;
            }
            // stats
            UpdateStats();

            // pictures
            picCharacter.BackgroundImage = character.Pic.BackgroundImage;
            picEnemy.BackgroundImage = boss.Img;

            // names
            lblPlayerName.Text = character.Name;
            lblEnemyName.Text = boss.Name;

            // create swing noise
            sp = new SoundPlayer(@"Resources\swing.wav");
        }
        public void UpdateStats()
        {
            lblPlayerLevel.Text = character.Level.ToString();
            lblPlayerHealth.Text = Math.Round(character.Health).ToString();
            lblPlayerStr.Text = Math.Round(character.Str).ToString();
            lblPlayerDef.Text = Math.Round(character.Def).ToString();
            lblPlayerMana.Text = Math.Round(character.Mana).ToString();
            lblPlayerXp.Text = Math.Round(character.XP).ToString();

            lblEnemyLevel.Text = boss.Level.ToString();
            lblEnemyHealth.Text = Math.Round(boss.Health).ToString();
            lblEnemyStr.Text = Math.Round(boss.Str).ToString();
            lblEnemyDef.Text = Math.Round(boss.Def).ToString();
            lblEnemyMana.Text = Math.Round(boss.Mana).ToString();

            lblPlayerHealth.Text = Math.Round(character.Health).ToString();
            lblEnemyHealth.Text = Math.Round(boss.Health).ToString();
        }
        private void btnSimpleAttack_Click(object sender, EventArgs e)
        {
            // make swing noise
            sp.Play();

            float prevEnemyHealth = boss.Health;
            character.SimpleAttack(boss);
            float enemyDamage = (float)Math.Round(prevEnemyHealth - boss.Health);
            lblEnemyDamage.Text = enemyDamage.ToString();
            lblEnemyDamage.Visible = true;
            tmrEnemyDamage.Enabled = true;
            if (boss.Health <= 0)
            {
                character.GainXP(boss.XpDropped);
                lblEndFightMessage.Text = "You Gained " + Math.Round(boss.XpDropped) + " xp!";
                lblEndFightMessage.Visible = true;
                Refresh();
                Thread.Sleep(1200);
                EndFight();
                if (character.ShouldLevelUp)
                {
                    FrmLevelUp frmLevelUp = new FrmLevelUp();
                    frmLevelUp.Show();
                }
                if (boss.CoinDropped > 0)
                {
                    FrmReward frmReward = new FrmReward();
                    frmReward.Amt = boss.CoinDropped;
                    frmReward.Show();
                }
            }
            else
            {
                float prevPlayerHealth = character.Health;
                boss.SimpleAttack(character);
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
        private void btnRun_Click(object sender, EventArgs e)
        {
            if (rand.NextDouble() < 0.05)
            {
                lblEndFightMessage.Text = "You Somehow Managed To Escape!";
                lblEndFightMessage.Visible = true;
                Refresh();
                Thread.Sleep(1200);
                EndFight();
            }
            else
            {
                // perform enemy turn
                float prevPlayerHealth = character.Health;
                boss.SimpleAttack(character);
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

        private void tmrPlayerDamage_Tick(object sender, EventArgs e)
        {
            lblPlayerDamage.Top -= 2;
            if (lblPlayerDamage.Top < 10)
            {
                lblPlayerDamage.Visible = false;
                tmrPlayerDamage.Enabled = false;
                lblPlayerDamage.Top = 52;
            }
        }

        private void tmrEnemyDamage_Tick(object sender, EventArgs e)
        {
            lblEnemyDamage.Top -= 2;
            if (lblEnemyDamage.Top < 10)
            {
                lblEnemyDamage.Visible = false;
                tmrEnemyDamage.Enabled = false;
                lblEnemyDamage.Top = 52;
            }
        }

        private void FrmArena_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    btnSimpleAttack_Click(sender, e);
                    break;
                case Keys.S:
                    FrmArena_Shortcuts_Click(sender, e);
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
            MessageBox.Show(message, "Shortcuts");
        }

        private void btnUseWeapon_Click(object sender, EventArgs e)
        {

        }
    }
}