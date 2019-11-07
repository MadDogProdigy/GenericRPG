namespace GenericRPG
{
    partial class FrmReward
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
            this.btnOpenChest = new System.Windows.Forms.Button();
            this.lblRewardAmt = new System.Windows.Forms.Label();
            this.lblRewardHeader = new System.Windows.Forms.Label();
            this.pnlRewardMsg = new System.Windows.Forms.Panel();
            this.lblRewardFooter = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timerChangeImg = new System.Windows.Forms.Timer(this.components);
            this.pnlRewardMsg.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpenChest
            // 
            this.btnOpenChest.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenChest.Location = new System.Drawing.Point(190, 34);
            this.btnOpenChest.Name = "btnOpenChest";
            this.btnOpenChest.Size = new System.Drawing.Size(169, 44);
            this.btnOpenChest.TabIndex = 0;
            this.btnOpenChest.Text = "Open Chest";
            this.btnOpenChest.UseVisualStyleBackColor = true;
            this.btnOpenChest.Click += new System.EventHandler(this.btnOpenChest_Click);
            // 
            // lblRewardAmt
            // 
            this.lblRewardAmt.AutoSize = true;
            this.lblRewardAmt.BackColor = System.Drawing.Color.Transparent;
            this.lblRewardAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRewardAmt.ForeColor = System.Drawing.Color.Red;
            this.lblRewardAmt.Location = new System.Drawing.Point(197, 52);
            this.lblRewardAmt.Name = "lblRewardAmt";
            this.lblRewardAmt.Size = new System.Drawing.Size(27, 29);
            this.lblRewardAmt.TabIndex = 1;
            this.lblRewardAmt.Text = "0";
            // 
            // lblRewardHeader
            // 
            this.lblRewardHeader.AutoSize = true;
            this.lblRewardHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblRewardHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRewardHeader.Location = new System.Drawing.Point(3, 50);
            this.lblRewardHeader.Name = "lblRewardHeader";
            this.lblRewardHeader.Size = new System.Drawing.Size(189, 31);
            this.lblRewardHeader.TabIndex = 2;
            this.lblRewardHeader.Text = "You just won ";
            // 
            // pnlRewardMsg
            // 
            this.pnlRewardMsg.AutoSize = true;
            this.pnlRewardMsg.BackColor = System.Drawing.Color.Yellow;
            this.pnlRewardMsg.Controls.Add(this.lblRewardFooter);
            this.pnlRewardMsg.Controls.Add(this.label1);
            this.pnlRewardMsg.Controls.Add(this.lblRewardAmt);
            this.pnlRewardMsg.Controls.Add(this.lblRewardHeader);
            this.pnlRewardMsg.Location = new System.Drawing.Point(98, 165);
            this.pnlRewardMsg.Name = "pnlRewardMsg";
            this.pnlRewardMsg.Size = new System.Drawing.Size(342, 110);
            this.pnlRewardMsg.TabIndex = 3;
            // 
            // lblRewardFooter
            // 
            this.lblRewardFooter.AutoSize = true;
            this.lblRewardFooter.BackColor = System.Drawing.Color.Transparent;
            this.lblRewardFooter.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRewardFooter.Location = new System.Drawing.Point(238, 52);
            this.lblRewardFooter.Name = "lblRewardFooter";
            this.lblRewardFooter.Size = new System.Drawing.Size(92, 31);
            this.lblRewardFooter.TabIndex = 4;
            this.lblRewardFooter.Text = "coins!";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(64, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Congratulations!";
            // 
            // timerChangeImg
            // 
            this.timerChangeImg.Interval = 250;
            this.timerChangeImg.Tick += new System.EventHandler(this.timerChangeImg_Tick);
            // 
            // FrmReward
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::GenericRPG.Properties.Resources.openChest1b;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(511, 412);
            this.Controls.Add(this.pnlRewardMsg);
            this.Controls.Add(this.btnOpenChest);
            this.DoubleBuffered = true;
            this.Name = "FrmReward";
            this.Text = "Reward";
            this.Load += new System.EventHandler(this.FrmReward_Load);
            this.pnlRewardMsg.ResumeLayout(false);
            this.pnlRewardMsg.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenChest;
        private System.Windows.Forms.Label lblRewardAmt;
        private System.Windows.Forms.Label lblRewardHeader;
        private System.Windows.Forms.Panel pnlRewardMsg;
        private System.Windows.Forms.Label lblRewardFooter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timerChangeImg;
    }
}