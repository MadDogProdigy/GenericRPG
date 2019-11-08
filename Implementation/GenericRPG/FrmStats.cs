using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameLibrary
{
    public partial class FrmStats : Form
    {
        public FrmStats()
        {
            InitializeComponent();
        }

        private void FrmStats_Load(object sender, EventArgs e)
        {
            Character character = Game.GetGame().Character;
            lblLevel.Text = character.Level.ToString();
            lblHealth.Text = ((float)Math.Round(character.Health)).ToString();
            lblMana.Text = ((float)Math.Round(character.Mana)).ToString();
            lblPlayerStr.Text = ((float)Math.Round(character.Str)).ToString();
            lblPlayerDef.Text = ((float)Math.Round(character.Def)).ToString();
            lblWeaponStr.Text = "N/A";
            lblWeaponDef.Text = "N/A";
            //lblWeaponStr.Text = character.weapon.Str.ToString();
            //lblWeaponDef.Text = character.weapon.Def.ToString();
            lblWallet.Text = character.Wallet.ToString();
        }

        private void FrmStats_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode) {
                case Keys.X:
                    Close();
                    break;
            }

        }
    }
}
