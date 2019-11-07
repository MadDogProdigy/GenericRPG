using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenericRPG
{
    public partial class FrmReward : Form
    {
        private int count;
        public int Amt { get; set; }
        List<Bitmap> backgrounds;
        private SoundPlayer sp;

        public FrmReward()
        {
            InitializeComponent();
            this.pnlRewardMsg.Visible = false;
            count = 0;
            Amt = 0;
            backgrounds = new List<Bitmap>();
            //disable the [X] button
            this.ControlBox = false;
        }

        public void FrmReward_Load(object sender,EventArgs e)
        {
            //create chest opening sound effect
            sp = new SoundPlayer(Properties.Resources.openChest);
            //make more dynamic
            backgrounds.Add(Properties.Resources.openChest1b);
            backgrounds.Add(Properties.Resources.openChest2b);
            backgrounds.Add(Properties.Resources.openChest3b);
            backgrounds.Add(Properties.Resources.openChest4b);
            backgrounds.Add(Properties.Resources.openChest5b);
            backgrounds.Add(Properties.Resources.openChest6b);
        }

        private void btnOpenChest_Click(object sender, EventArgs e)
        {
            sp.Play();
            this.btnOpenChest.Hide();
            this.lblRewardAmt.Text = Amt.ToString();
            this.timerChangeImg.Start();
            
        }

        private void timerChangeImg_Tick(object sender, EventArgs e)
        {
            if(count < backgrounds.Count)
            {
                this.BackgroundImage = backgrounds[count];
                count++;
            }else
            {
                this.timerChangeImg.Stop();
                sp.Stop();
                this.pnlRewardMsg.Visible = true;
                Refresh();
                Thread.Sleep(1200);
                Close();

            }
            
        }
    }
}
