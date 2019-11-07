namespace GenericRPG {
  partial class FrmMap {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
            this.grpMap = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // grpMap
            // 
            this.grpMap.Location = new System.Drawing.Point(33, 51);
            this.grpMap.Name = "grpMap";
            this.grpMap.Size = new System.Drawing.Size(389, 288);
            this.grpMap.TabIndex = 1;
            this.grpMap.TabStop = false;
            // 
            // FrmMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(998, 529);
            this.Controls.Add(this.grpMap);
            this.Name = "FrmMap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Map";
            this.Load += new System.EventHandler(this.FrmMap_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMap_KeyDown);
            this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.GroupBox grpMap;
  }
}

