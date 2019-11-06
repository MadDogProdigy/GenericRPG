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
            //disables the [X] button
            this.ControlBox = false;
        }

        private void FrmStats_Load(object sender, EventArgs e)
        {
            Character character = Game.GetGame().Character;
            lblLevel.Text = character.Level.ToString();
            lblHealth.Text = ((float)Math.Round(character.Health)).ToString();
            lblMana.Text = ((float)Math.Round(character.Mana)).ToString();
            lblStr.Text = ((float)Math.Round(character.Str)).ToString();
            lblDef.Text = ((float)Math.Round(character.Def)).ToString();
        }
    }
}
