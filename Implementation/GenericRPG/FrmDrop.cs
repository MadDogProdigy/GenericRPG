using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameLibrary;
using System.Media;

namespace GenericRPG
{
    public partial class FrmDrop : Form
    {
        public SoundPlayer sp;
        public FrmDrop()
        {
            InitializeComponent();
            sp = new SoundPlayer(Properties.Resources.angels);
            sp.Play();
            
        }
        private void FrmDrop_Load(object sender, EventArgs e)
        {
            


        }
    }
}