using System;
using System.Windows.Forms;

namespace GenericRPG
{
    partial class FrmCoinFrenzy
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grpCoins = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.lblWallet = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // grpCoins
            // 
            this.grpCoins.BackColor = System.Drawing.Color.Transparent;
            this.grpCoins.Location = new System.Drawing.Point(2, 0);
            this.grpCoins.Name = "grpCoins";
            this.grpCoins.Size = new System.Drawing.Size(692, 407);
            this.grpCoins.TabIndex = 2;
            this.grpCoins.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Cyan;
            this.label2.Location = new System.Drawing.Point(410, 410);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Time Left:";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.BackColor = System.Drawing.Color.Transparent;
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.ForeColor = System.Drawing.Color.Red;
            this.timeLabel.Location = new System.Drawing.Point(544, 410);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(136, 29);
            this.timeLabel.TabIndex = 0;
            this.timeLabel.Text = "60 seconds";
            // 
            // lblWallet
            // 
            this.lblWallet.AutoSize = true;
            this.lblWallet.BackColor = System.Drawing.Color.Transparent;
            this.lblWallet.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWallet.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblWallet.Location = new System.Drawing.Point(111, 412);
            this.lblWallet.Name = "lblWallet";
            this.lblWallet.Size = new System.Drawing.Size(26, 29);
            this.lblWallet.TabIndex = 5;
            this.lblWallet.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Lime;
            this.label4.Location = new System.Drawing.Point(12, 412);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 29);
            this.label4.TabIndex = 6;
            this.label4.Text = "Wallet:";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmCoinFrenzy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(692, 450);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grpCoins);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblWallet);
            this.Name = "FrmCoinFrenzy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Coin Frenzy";
            this.Load += new System.EventHandler(this.FrmCoinFrenzy_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCoinFrenzy_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.GroupBox grpCoins;
        private Label label2;
        private Label timeLabel;
        private Label lblWallet;
        private Label label4;
        private Timer timer1;
    }
}