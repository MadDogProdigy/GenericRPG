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
            this.grpCoins = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // grpMap
            // 
            this.grpCoins.Location = new System.Drawing.Point(206, 81);
            this.grpCoins.Name = "grpMap";
            this.grpCoins.Size = new System.Drawing.Size(389, 288);
            this.grpCoins.TabIndex = 2;
            this.grpCoins.TabStop = false;
            // 
            // FrmCoinFrenzy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grpCoins);
            this.Name = "FrmCoinFrenzy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Coin Frenzy";
            this.Load += new System.EventHandler(this.FrmCoinFrenzy_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCoinFrenzy_KeyDown);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.GroupBox grpCoins;
    }
}