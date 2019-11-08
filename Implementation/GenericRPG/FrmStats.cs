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
            if (character.HasWeapon)
            {
                lblWeaponStr.Text = character.WeaponStr.ToString();
                lblWeaponDef.Text = character.WeaponDef.ToString();
            }
            else
            {
                lblWeaponStr.Text = "N/A";
                lblWeaponDef.Text = "N/A";

            }
            
            //lblWeaponStr.Text = character.weapon.Str.ToString();
            //lblWeaponDef.Text = character.weapon.Def.ToString();
            lblWallet.Text = character.Wallet.ToString();
        }

        private void buyStr_Click(object sender, EventArgs e)
        {
            Character character = Game.GetGame().Character;
            if (character.Wallet >= 10 & character.HasWeapon) { 
                character.GainCoin(-10);
                lblWallet.Text = character.Wallet.ToString();
                character.WeaponStr += 5;
                character.IncAtt(1); 
                lblWeaponStr.Text = character.WeaponStr.ToString();
            }
        }
        private void buyDef_Click(object sender, EventArgs e)
        {
            Character character = Game.GetGame().Character;
            if (character.Wallet >= 10 & character.HasWeapon)
            {
                character.GainCoin(-10);
                lblWallet.Text = character.Wallet.ToString();
                character.WeaponDef += 5;
                character.IncAtt(2); 
                lblWeaponDef.Text = character.WeaponDef.ToString();
            }
        }
    }
}
